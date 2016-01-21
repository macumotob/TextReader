using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Baybak.TextReader
{
  public partial class UserControlSpeeker : UserControl
  {
    public delegate string EventTextToSpeechNeeded();

    public event EventTextToSpeechNeeded _OnTextToSpeechNeeded;
    System.Speech.Synthesis.SpeechSynthesizer ss;

    public string _SourceText;
    public UserControlSpeeker()
    {
      InitializeComponent();
      _cmdPlay.Click +=new EventHandler(_cmdPlay_Click);
      _cmdStop.Click += new EventHandler(_cmdStop_Click);
      _Volume.ValueChanged += new EventHandler(_Volume_ValueChanged);
      _Rate.ValueChanged += new EventHandler(_Rate_ValueChanged);
    }

    void _Rate_ValueChanged(object sender, EventArgs e)
    {
      if (ss != null)
      {
        ss.Rate = _rate;
      }
    }

    void _Volume_ValueChanged(object sender, EventArgs e)
    {
      if (ss != null)
      {
        ss.Volume = _volume;
      }
    }

    void _cmdStop_Click(object sender, EventArgs e)
    {
      if (ss != null)
      {
        ss.Pause();
        ss.Dispose();
        ss = null;
      }
    }

    void _cmdPlay_Click(object sender, EventArgs e)
    {
      ss = new System.Speech.Synthesis.SpeechSynthesizer();
      ss.Volume = _volume;
      ss.Rate = _rate;
      if (_OnTextToSpeechNeeded != null)
      {
        _SourceText = _OnTextToSpeechNeeded();
      }
      ss.SpeakAsync(_SourceText);
    }
    public void _Speak(string word)
    {
      if (ss == null)
      {
        ss = new System.Speech.Synthesis.SpeechSynthesizer();
        ss.Volume = _volume;
        ss.Rate = _rate;
      }
      ss.SpeakAsync(word);
    }
    private int _volume
    {
      get
      {
        return _Volume.Value;
      }
    }
    private int _rate
    {
      get
      {
        return _Rate.Value;
      }
    }

  }
}
