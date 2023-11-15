using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    public class Task
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date_Time { get; set; }
        public string Status { get; set; }
        public string Importance { get; set; }
        public string Decription { get; set; }
        public bool Completed { get; set; }

    }
}
