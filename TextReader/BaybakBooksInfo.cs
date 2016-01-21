using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

namespace Baybak.TextReader
{
  public class BaybakBooksInfo_OLD
  {
    static public BaybakBooksInfo_OLD BooksInfo = new BaybakBooksInfo_OLD();

    public DataTable DataSource
    {
      get
      {
        return this._ds.Tables["BooksInfo"];
      }
    }
    private DataSet _ds = new DataSet();

    private string _AppPath;

    public string AppPath
    {
      get { return _AppPath; }
      set 
      {
        _AppPath = value;
        this.ValidateDataSet();
        this.Load();
      }
    }
    private string XmlFile
    {
      get
      {
        return AppPath + "\\booksInfo.xml";
      }
    }
    private string XmlFileSchema
    {
      get
      {
        return AppPath + "\\booksInfo.schema.xml";
      }
    }
    public void Load()
    {
      this._ds.Clear();
      this._ds.ReadXmlSchema(this.XmlFileSchema);
      this._ds.ReadXml(this.XmlFile);
    }
    public void Save()
    {
      this._ds.WriteXmlSchema(this.XmlFileSchema);
      this._ds.WriteXml(this.XmlFile);
    }
    public void AddBookInfo(string title, string authors, string location, string notes)
    {

      DataTable tb = this._ds.Tables["BooksInfo"];
      DataRow row = tb.NewRow();

      row["Id"] = Guid.NewGuid();
      row["Title"] = title;
      row["Authors"] = authors;
      row["Location"] = location;
      row["Notes"] = notes;
      row["Exists"] = System.IO.File.Exists(location);
      row["WordIndex"] = 0;
      row["LastOpenDate"] = DateTime.Now;

      tb.Rows.Add(row);
      this.Save();
    }
    private void ValidateStruct()
    {
      this.Load();
      int i = 0;
      string columnName = "WordIndex";
      if (!this.DataSource.Columns.Contains(columnName))
      {
        this.DataSource.Columns.Add(columnName, typeof(int));
        for (i = 0; i < this.DataSource.Rows.Count; i++)
        {
          this.DataSource.Rows[i][columnName] = 0;
        }
      }
      columnName = "LastOpenDate";
      if (!this.DataSource.Columns.Contains(columnName))
      {
        this.DataSource.Columns.Add(columnName, typeof(DateTime));
        for (i = 0; i < this.DataSource.Rows.Count; i++)
        {
          this.DataSource.Rows[i][columnName] = DateTime.Now;
        }
      }
      i = 0;

      while(i < this.DataSource.Rows.Count)
      {
        DataRow row = this.DataSource.Rows[i];
        string location = row["location"].ToString();
        row["Exists"] = System.IO.File.Exists(location);
        //if (System.IO.File.Exists(location))
        //{
        //  row["Exists"] = System.IO.File.Exists(location);
        //}
        //else
        //{
        //  this.DataSource.Rows.Remove(row);
        //  continue;
        //}

        columnName = "LastOpenDate";
        object value = row[columnName];
        if (System.DBNull.Value.Equals(value))
        {
          row[columnName] = DateTime.Now;
        }
        columnName = "WordIndex";
        value = row[columnName];
        if (System.DBNull.Value.Equals(value))
        {
          row[columnName] = 0;
        }
        i++;
      }

      this.Save();
    }
    public void SaveBookInfo(BookInfo book)
    {
      DataRow[] rows = this.DataSource.Select("id='" + book.Id.ToString() + "'");
      if (rows.Length == 1)
      {
        rows[0]["WordIndex"] = book.WordIndex;
        rows[0]["LastOpenDate"] = DateTime.Now;
        this.Save();
      }
    }
    public BookInfo this[Guid idBook]
    {
      get
      {
        return GetBookInfo(idBook);
      }
    }
    public BookInfo GetBookInfo(Guid idBook)
    {
      BookInfo book = new BookInfo();
      DataRow[] rows = this.DataSource.Select("id='" + idBook.ToString() + "'");
      if (rows.Length == 1)
      {
        book.Id = idBook;
        book.WordIndex = (int)rows[0]["WordIndex"];
        book.Location = (string)rows[0]["Location"];
      }
      return book;
    }
    private void ValidateDataSet()
    {
      if (System.IO.File.Exists(this.XmlFile))
      {
        ValidateStruct();
        return;
      }
      this._ds.DataSetName = "BooksList";
      DataTable tb = new DataTable("BooksInfo");
      tb.Columns.Add("Id",typeof(Guid));
      tb.Columns.Add("Title");
      tb.Columns.Add("Authors");
      tb.Columns.Add("Location");
      tb.Columns.Add("Notes");
      tb.Columns.Add("Exists",typeof(bool));
      tb.Columns.Add("WordIndex",typeof(int));
      tb.Columns.Add("LastOpenDate",typeof(DateTime));

      this._ds.Tables.Add(tb);

      this.AddBookInfo("The Game", "Jack London", "\\\\MARS\\BIBLIO\\Library\\Gutenberg\\7\\1160.txt", "");
    }
  }
}
