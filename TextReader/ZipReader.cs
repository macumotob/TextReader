using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace Baybak.TextReader
{
  class BibInfo
  {
    public string Author;
    public string Title;
    public string Genre;
    public string FileId;
    public string FileId2;
    public string FileId3;
    public string FileName;

  }
  class ZipReader
  {
    private List<BibInfo> _list;
    private string path2reading = @"E:\Books\fb2\reading\";
    public void Load()
    {
      string zipFile = @"E:\Books\fb2\librus\librusec_local_fb2.inpx";
      _list = new List<BibInfo>();

      string ar = path2reading + @"ar1.txt";
      using (ZipArchive zip = ZipFile.Open(zipFile, ZipArchiveMode.Read))
      {
        foreach (ZipArchiveEntry entry in zip.Entries)
        {
          if (entry.Name == "collection.info" || entry.Name == "version.info") continue;
          if (System.IO.File.Exists(ar))
          {
            System.IO.File.Delete(ar);
          }
           entry.ExtractToFile(ar);
           string [] lines =System.IO.File.ReadAllLines(ar, Encoding.UTF8);
           foreach (string s in lines)
           {
             string[] data = s.Split((char)4);
             BibInfo info = new BibInfo() { Author = data[0], Title=data[2],
               Genre = data[1] , FileId = data[5], FileId2=data[6],FileId3=data[7],FileName =entry.Name};
             _list.Add(info);
           }
        }
      }
    }
    public bool OpenFromZip(string zipFile, string file)
    {
      string path = @"E:\Books\fb2\librus\lib.rus.ec\" + zipFile.ToLower().Replace(".inp", ".zip"); ;
 
      using (ZipArchive zip = ZipFile.Open(path, ZipArchiveMode.Read))
      {
        file =  file + ".fb2";
        foreach (ZipArchiveEntry entry in zip.Entries)
        {
          if (entry.Name == file)
          {
            string output = path2reading + file;
            if (System.IO.File.Exists(output))
            {
              System.IO.File.Delete(output);
            }
            entry.ExtractToFile(output);
            RunManager.Manager.RunApplication(output);
            return true;
          }
        }        
      }
      return false;
    }
    public List<BibInfo> GetBooks(char c)
    {
      List<BibInfo> list = new List<BibInfo>();
      foreach (BibInfo info in _list)
      {
        if(c == info.Author[0])
        {
          list.Add(info);
        }
      }
     return  list.OrderBy((a) => { return a.Author; }).ToList();
     
    }
    public Dictionary<char,int> GetChars()
    {
      Dictionary<char, int> dic = new Dictionary<char, int>();
      foreach(BibInfo info in _list)
      {
        char c = info.Author[0];
        if(dic.ContainsKey(c))
        {
          dic[c]++;
        }
        else
        {
          dic[c] = 1;
        }
      }
   //   var sortedDict = from entry in dic orderby entry.Key ascending select entry;
      dic = dic.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
      return dic;
    }
    
  }//
}
