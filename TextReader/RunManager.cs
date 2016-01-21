﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baybak.TextReader
{
  class RunManager
  {
    static public RunManager Manager = new RunManager();
    public void RunApplication(string file)
    {
      Process process = new Process();

      process.StartInfo = new ProcessStartInfo(file);
      process.StartInfo.CreateNoWindow = true;
      process.StartInfo.UseShellExecute = true;
      process.Start();
    }

    string _path2pdfConverter = @"E:\Develops\pdf\Baybak.Pdf\bin\Debug\Baybak.Pdf.exe";
    public string ConverPdf2Txt(string file)
    {
      Process process = new Process();
      
      process.StartInfo = new ProcessStartInfo();
      process.StartInfo.FileName = _path2pdfConverter;
      process.StartInfo.Arguments = "\"" + file + "\""; 
      process.StartInfo.CreateNoWindow = true;
      process.StartInfo.UseShellExecute = true;
      process.Start();
      int time = 0;
      const int waitTime = 5000;
      const int maxWaitTime = waitTime * 20;
      while( time < maxWaitTime && !process.WaitForExit(waitTime))
      {
        time += waitTime;
      }
      if (time >= maxWaitTime) return null;
      string txtfile = file.ToLower().Replace(".pdf", ".txt");
      return txtfile;
    }
  }
}
