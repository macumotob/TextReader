

using System;
//using SQLite;
using System.Data.SQLite;
namespace Baybak.TextReader
{
  public class Link
  {
   // [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Href { get; set; }
    public string Desc { get; set; }
  }
  public class Database
  {

    static public Database Instance = new Database();

    public Database()
    {
    }
    private string _dbname = "textreader.sqlite";
    public void CreateDatabase()
    {
      SQLiteConnection.CreateFile(_dbname);

      SQLiteConnection cnn = new SQLiteConnection("Data Source=" + _dbname +";Version=3;");
      cnn.Open();

      string sql = "create table links (href varchar(1024), description varchar(250),id int)";

      SQLiteCommand command = new SQLiteCommand(sql, cnn);
      command.ExecuteNonQuery();

      cnn.Close();
    }
    public void InsertLinks(string sqConnectionString)
    {
      // If the connection string is empty, use default. 
      SQLiteConnection cnn = new SQLiteConnection(sqConnectionString);
      string myInsertQuery = "CREATE TABLE LINKS(DeptNo, DName) Values(50, 'DEVELOPMENT')";
      SQLiteCommand sqCommand = new SQLiteCommand(myInsertQuery);
      sqCommand.Connection = cnn;
      cnn.Open();
      try
      {
        sqCommand.ExecuteNonQuery();
      }
      finally
      {
        cnn.Close();
      }
    } 
  }//
}

