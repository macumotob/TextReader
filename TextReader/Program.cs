using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;

namespace Baybak.TextReader
{
  //using Baybak.Data.Broker;
  class Program
  {
    [STAThread]
    static void Main()
    {
 //     TestVoices();
 //     return;
  //    LoadMuller();
//      GutenbergBooks();
//      return;

      //_Statments();
      //return;

//      BaybakText txt = new BaybakText();
//      txt.LoadFromFile("D:\\Books\\philos_eng_txt\\russel.txt");
     // Database.Instance.AddLink(dbname, "https://adm.tools/hosting/account/ufm/?accid=170536", "сайт maxbuk");
      Words.LoadMullerDictionary();
      BooksBroker.Instance.LoadHistory();
//      ConnectInfo.Default.ReadSettings();

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
      Application.Run(new frmMain());

    }
    static void TestVoices()
    {
      using ( SpeechSynthesizer synth = new SpeechSynthesizer())
      {

        // Output information about all of the installed voices. 
       
        foreach (InstalledVoice voice in synth.GetInstalledVoices())
        {
          VoiceInfo info = voice.VoiceInfo;
          string AudioFormats = "";
          foreach (SpeechAudioFormatInfo fmt in info.SupportedAudioFormats)
          {
            AudioFormats += String.Format("{0}\n",
            fmt.EncodingFormat.ToString());
          }

          Console.WriteLine(" Name:          " + info.Name);
          Console.WriteLine(" Culture:       " + info.Culture);
          Console.WriteLine(" Age:           " + info.Age);
          Console.WriteLine(" Gender:        " + info.Gender);
          Console.WriteLine(" Description:   " + info.Description);
          Console.WriteLine(" ID:            " + info.Id);
          Console.WriteLine(" Enabled:       " + voice.Enabled);
          if (info.SupportedAudioFormats.Count != 0)
          {
            Console.WriteLine(" Audio formats: " + AudioFormats);
          }
          else
          {
            Console.WriteLine(" No supported audio formats found");
          }

          string AdditionalInfo = "";
          foreach (string key in info.AdditionalInfo.Keys)
          {
            AdditionalInfo += String.Format("  {0}: {1}\n", key, info.AdditionalInfo[key]);
          }

          Console.WriteLine(" Additional Info - " + AdditionalInfo);
          Console.WriteLine();
        }
      }
    }
    //static void LoadMuller()
    //{

    //  ScoBroker broker = new ScoBroker();
    //  broker.Open("46.118.208.104,1430", "salesctrl", "sales2000ctrl!@#$","ww_english");
    //  broker.Execute("DELETE FROM [WORDS]");
      
    //  string file = Application.StartupPath + "\\aemuller.txt";
    //  Words.LoadMuller(file);
    //  foreach (string key in Words.Dictionary.Keys)
    //  {
    //    Word word = Words.Dictionary[key];
    //    broker.Execute("INSERT INTO [WORDS] (WORD) VALUES(@WORD)",new ScoParams("WORD",word.Russian));
    //    if (word.Variants != null)
    //    {
    //      word.Variants.ForEach(s =>
    //        {
    //          broker.Execute("INSERT INTO [WORDS] (WORD) VALUES(@WORD)", new ScoParams("WORD", s));
    //        }
    //        );
    //    }
    //  }
    //  //broker.CreateDatabase("ww_english",false);
    //  broker.Close();

    //}
    static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
    {
      MessageBox.Show(e.Exception.Message, "ERROR");
    }
    static void GutenbergBooks()
    {
      string gutenfolder = //@"K:\Library\Gutenberg\";
      @"C:\ww\DownLoads\";
      string[] folders = { "7\\", "9\\" };
      string infofile = gutenfolder + "gutenberg.txt";
      using (System.IO.StreamWriter sw = new System.IO.StreamWriter(infofile))
      {
        for (int k = 0; k < folders.Length; k++)
        {
          string folder = gutenfolder + folders[k];
          string[] files = System.IO.Directory.GetFiles(folder, "*.txt");

          for (int i = 0; i < files.Length; i++)
          {
            string file = files[i];
            sw.Write(folders[k] + System.IO.Path.GetFileName(file) + (char)1);
            using (System.IO.StreamReader sr = new System.IO.StreamReader(file))
            {
              while (true)
              {
                string text = sr.ReadLine();
                if (text == null)
                {
                  sw.WriteLine((char)1);
                  break;
                }
                string s = text.ToLower();
                if (s.IndexOf("title") != -1)
                {
                  sw.Write(text + (char)1);
                }
                else if (s.IndexOf("author") != -1)
                {
                  sw.Write(text + (char)1);
                }
                else if (s.IndexOf("***") != -1)
                {
                  sw.WriteLine((char)1);
                  break;
                }
              }
              sr.Close();
            }
          }
        } // folders
        sw.Close();
      }
    }
    //static void GetAllWords()
    //{
    //  string path = @"C:\ww\DownLoads\7\";
    //  string[] files = System.IO.Directory.GetFiles(path, "*.txt");

    //  string dic = AppDomain.CurrentDomain.BaseDirectory + "\\mywords.txt";
    //  Words.Load(dic);

    //  Parser parser = new Parser();
    //  for (int i = 0; i < files.Length; i++)
    //  {
    //    string file = files[i];
    //    parser.Parse(file);
    //    Console.WriteLine("Total : " + Words.AllWords.Count.ToString());
    //  }
    //}

    static void _Statments()
    {
      string file = @"C:\ww\DownLoads\9\30908.txt";
      string s = "";
      string text="";//, rest = "";
      using (System.IO.StreamReader sr = new System.IO.StreamReader(file))
      {
        while ((s = sr.ReadLine()) != null)
        {
          if (s.Length == 0)
          {
            text = "";
          }
          else
          {
            s = s.Replace('\t', ' ').Trim();
            int i = s.IndexOf('.');
            if (i == -1)
            {
              text += " " + s;
            }
            else
            {
              text += " " + s.Substring(0,i+1);
              List<string> words = Parser.GetAllWords(text);
              int k = 0;
              while (k < words.Count)
              {
                words[k] = words[k].Trim();
                if (words[k].Length == 0)
                {
                  words.RemoveAt(k);
                  continue;
                }
                k++;
              }
              text = s.Substring(i + 1);
            }

          }
        }
      }
    }
  }
}
