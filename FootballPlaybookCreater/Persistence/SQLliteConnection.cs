using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FootballPlaybookCreater
{
    public interface SQLliteConnections
    {
        SQLiteAsyncConnection GetConnection(); 
    }
}
