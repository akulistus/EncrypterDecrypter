using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using System.Threading.Tasks;
using System.Reflection;

namespace EncrypterDecrypter.Services
{
    public class FileIOService
    {
        public string LoadData(string fileName)
        {
            if (fileName.Contains("doc"))
            {
                Word.Application wordApp = new Word.Application();
                var wordDoc = wordApp.Documents.Open(fileName);
                string s = wordDoc.Content.Text;
                wordDoc.Close();
                wordApp.Quit();
                return s;
            }
            else
            {
                return File.ReadAllText(fileName, Encoding.UTF8);// почему encoding?
            }
        }

        public void SaveData(string data, string fileName)
        {
            if (fileName.Contains("doc"))
            {

                var app = new Word.Application();
                app.ShowAnimation = false;
                app.Visible = false;
                var doc = new Word.Document();
                doc = app.Documents.Add();
                doc.Content.Text = data;
                doc.Activate();
                object f = fileName;
                doc.SaveAs(f);
                doc.Close();
                app.Quit();
            }
            else
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        sw.WriteLine(data);
                    }
                }
            }
        }
    }
}
