using FootballPlaybookCreater;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLConnection))]

namespace FootballPlaybookCreater
{
    class SQLConnection : SQLliteConnections
    {
        private readonly string _SQLliteFileName = "Playbook.db";

        public SQLiteAsyncConnection GetConnection()
        {
            
                var baseFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var SqlPath = Path.Combine(baseFilePath, _SQLliteFileName);
                return new SQLiteAsyncConnection(SqlPath);
        }
    }            
}
