using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using taskList.models;

namespace taskList.data
{
    public class databaseContext
    {
        public SQLiteAsyncConnection Connection { get; set; }

        public databaseContext(string dbPath) { 
        
           Connection = new SQLiteAsyncConnection(dbPath);
           Connection.CreateTableAsync<taskListItems>().Wait();
        
        }

        public async Task<int> insertItem(taskListItems item)
        {

            return await Connection.InsertAsync(item);
        }
        public async Task<List<taskListItems>> getTaskList()
        {
            return await Connection.Table<taskListItems>().ToListAsync();

        }
        public async Task<int> deleteTaskList(taskListItems taskListItems)
        {
            return await Connection.DeleteAsync(taskListItems);
        }
        public async Task<int> editItem(taskListItems item)
        {
            return await Connection.UpdateAsync(item);
        }
    }
}
