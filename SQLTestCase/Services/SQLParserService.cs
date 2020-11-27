using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SQLTestCase.Data;
using SQLTestCase.Data.Entities;
using SQLTestCase.Interfaces;
using SQLTestCase.Models;

namespace SQLTestCase.Services
{
    public class SQLParserService : ISQLParserService
    {
        private readonly SQLTestCaseDbContext _context;

        public SQLParserService(SQLTestCaseDbContext context)
        {
            _context = context;
        }

        public QueryModel ExecuteSql(QueryModel queryModel)
        {
            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryModel.QueryText, connection);
                List<string> scalarCommands=new List<string>(){"MIN","MAX","COUNT","SUM","AVG"};
                Regex scalarRegex = new Regex(string.Format(@"\s*select\s+({0})\s*\(\s*[a-zA-Z@.#]+\s*\)\s*from\s+[a-zA-Z@.#]+", string.Join("|", scalarCommands)),RegexOptions.IgnoreCase);
                 
                List<string> nonQueryCommands=new List<string>(){"INSERT","UPDATE","DELETE", "CREATE","ALTER","DROP","TRUNCATE"};
                try
                {
                    if (scalarRegex.IsMatch(command.CommandText))
                    {
                        queryModel = ExecuteScalar(queryModel, command);
                    }
                    else if (nonQueryCommands.Any(s => command.CommandText.Contains(s, StringComparison.OrdinalIgnoreCase)))
                    {
                        queryModel = ExecuteNonQuery(queryModel, command);
                    }
                    else if (command.CommandText.Contains("SELECT", StringComparison.OrdinalIgnoreCase))
                    {
                        queryModel = ExecuteReader(queryModel, command);
                    }
                    else
                    {
                        queryModel.Message = "Unrecognized command";
                    }
                }
                catch (SqlException e)
                {
                    queryModel.Message = e.Message;
                }

                return queryModel;
            }
        }

        private QueryModel ExecuteNonQuery(QueryModel queryModel,SqlCommand command)
        {
            int number = command.ExecuteNonQuery();
            queryModel.Result = $"Count of processed objects: {number}";
            return queryModel;
        }
        
        private QueryModel ExecuteScalar(QueryModel queryModel,SqlCommand command)
        {
                queryModel.Result = command.ExecuteScalar().ToString();
                return queryModel;
        }

        private QueryModel ExecuteReader(QueryModel queryModel, SqlCommand command)
        {
            DbDataReader rs;
            object[] oo;
            List<Object> res= new List<Object>();
            
            rs = command.ExecuteReader();
            if (rs.HasRows)
            {
                var dt = rs.GetColumnSchema();
                queryModel.ColumnName = new List<string>();
                foreach(var col in dt)
                {
                    queryModel.ColumnName.Add(col.ColumnName);
                }
                while (rs.Read())
                {
                    oo = new Object[rs.FieldCount];
                    rs.GetValues(oo);
                    res.Add(oo);
                }    
            }
            else
            {
                queryModel.Result = "Result Is Empty";
            }
            
            rs.Close();
            queryModel.ListResult = res;
            return queryModel;
            }
    }
    
}