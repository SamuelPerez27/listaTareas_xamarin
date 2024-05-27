using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace taskList.models
{
    public class taskListItems
    {
        [AutoIncrement, PrimaryKey]
        public int idTaskList { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
