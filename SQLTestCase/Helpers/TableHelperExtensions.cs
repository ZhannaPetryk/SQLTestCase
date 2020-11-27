using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SQLTestCase.Helpers
{
    public static class TableHelperExtensions
    {
        public static string BuildTr(ICollection header, object[] row)
        {
            var tr = "<tr>";
            
            for (int i = 0; i <= header.Count - 1; i++) {
                tr += String.Format("<td>{0}</td>", row[i]);
            }

            tr += "</tr>";

            return (tr);
        }

        public static string BuildTrHeader(IEnumerable header)
        {
            var tr = "<tr>";

            foreach (var item in header)
            {
                tr += String.Format("<th>{0}</th>", item);
            }

            tr += "</tr>";

            return (tr);
        }

        public static IHtmlContent TableHelper(this IHtmlHelper helper, ICollection header, ICollection body)
        {
            var tableStart = String.Format(@"<table class='table table-striped table-bordered'>
                            <thead class='thead-dark'>
                                {0}
                            </thead>
                            <tbody>", BuildTrHeader(header));

            var tableBody = String.Empty;
            
            foreach(var row in body)
            {
                tableBody += BuildTr(header, (object[]) row);
            }
            
            var tableEnd = @"
                            </tbody>
                        </table>";;

            return new HtmlString(tableStart + tableBody + tableEnd);
        }

        static bool IsCollection(Type type)
        {
            return type.GetInterface(typeof(IEnumerable<>).FullName) != null;
        } 
    }
}