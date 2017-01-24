using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConverterOfSubtitles
{
    class FileFlow
    {
        public string fullPathToFile { get; set; }
        public List<string> tempList;

        public FileFlow(string fullPathToFile)
        {
            this.fullPathToFile = fullPathToFile;
            this.tempList = new List<string>();
        }
        public FileFlow() { }
        public List<string> ReadFromFile()
        {
            FileStream fs = new FileStream(fullPathToFile, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(1251));
            while (sr.EndOfStream != true)  
            {
                tempList.Add(sr.ReadLine());
            }
            sr.Close();
            return tempList;
        }
        public void CreateFile(List<Subtitle> sl, string pathOfFiles, int index = 3)
        {           
            TextWriter tw = new StreamWriter(@pathOfFiles + index + ".txt", true);
            for (int i = 0; i < sl.Count; i++)
            {
                tw.WriteLine(sl[i].subtitleEng + "\r\n" + sl[i].subtitleRus+ "\r\n");
            }
            tw.Close();    
        }
        public string[] getPathes(string pathOfFolder)
        {
            string[] files = Directory.GetFiles(@pathOfFolder, "*.txt", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++)
            {               
                Console.WriteLine(files[i]);
            }
            return files; 
        }

       
    }
}
