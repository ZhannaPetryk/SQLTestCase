using System.Collections.Generic;

namespace SQLTestCase.Models
{
    public class QueryModel
    {
        public string QueryText { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public List<object> ListResult { get; set; }
        public List<string> ColumnName { get; set; }
    }
}