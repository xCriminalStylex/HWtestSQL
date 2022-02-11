using System;
using Xunit;
using System.Data.SqlTypes;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;


namespace HWtestSQL
{
    public static class SQLHelp
    {
        public static object SQLiteData(string connect, string command)
        {           
            SQLiteConnection db = new SQLiteConnection(connect);
            db.Open();
            SQLiteCommand cmd = db.CreateCommand();
            cmd.CommandText = command;
            return cmd.ExecuteScalar(); 
        }
    }
}
