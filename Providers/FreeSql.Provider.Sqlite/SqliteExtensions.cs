using System;
using System.Data.SQLite;

public static partial class FreeSqlSqliteGlobalExtensions
{

    /// <summary>
    /// 特殊处理类似 string.Format 的使用方法，防止注入，以及 IS NULL 转换
    /// </summary>
    /// <param name="that"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static string FormatSqlite(this string that, params object[] args) => _sqliteAdo.Addslashes(that, args);
    static FreeSql.Sqlite.SqliteAdo _sqliteAdo = new FreeSql.Sqlite.SqliteAdo();
    public static void SetPassword(this SQLiteConnection connection, string password)
    {
        if (connection.State != System.Data.ConnectionState.Open)
            throw new Exception("Open database first.");

        var cmd = connection.CreateCommand();
        cmd.CommandText = string.Format("PRAGMA key = '{0}'", password);
        cmd.ExecuteNonQuery();
    }
}
