using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    public class TaskRepositoryPattern
    {
        SQLiteConnection database;
        public TaskRepositoryPattern(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Task>();
        }
        public IEnumerable<Task> GetItems()
        {
            return database.Table<Task>().ToList();
        }
        public Task GetItem(int id)
        {
            return database.Get<Task>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Task>(id);
        }
        public int SaveItem(Task item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
