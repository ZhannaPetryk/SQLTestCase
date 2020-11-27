using SQLTestCase.Models;

namespace SQLTestCase.Interfaces
{
    public interface ISQLParserService
    {
        QueryModel ExecuteSql(QueryModel query);
    }
}