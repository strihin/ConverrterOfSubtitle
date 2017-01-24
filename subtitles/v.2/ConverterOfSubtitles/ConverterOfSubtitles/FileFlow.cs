using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConverterOfSubtitles
{
    class FileFlow
    {
        public string fullPathToFile { get; set; }
        public string fullPathToFolder { get; set; }
        public List<string> tempList;

        public FileFlow(string fullPathToFile)
        {
            this.fullPathToFile = fullPathToFile;
            this.tempList = new List<string>();
        }
        public FileFlow(string fullPathToFile, string fullPathToFolder)
        {
            this.fullPathToFile = fullPathToFile;
            this.fullPathToFolder = fullPathToFolder;
            this.tempList = new List<string>();
        }
        public FileFlow() { }
        public List<string> ReadFromFile()
        {
            FileStream fs = new FileStream(@fullPathToFile, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(1251));
            while (sr.EndOfStream != true)  
            {
                tempList.Add(sr.ReadLine());
            }
            sr.Close();
            return tempList;
        }
        public void CreateFile(List<Subtitle> sl, string pathOfFiles, int index = 3) //create file by subtitle
        {           
            TextWriter tw = new StreamWriter(@pathOfFiles + index + ".txt", true);
            for (int i = 0; i < sl.Count; i++)
            {
                tw.WriteLine(sl[i].SubtitleEng + "\r\n" + sl[i].SubtitleRus+ "\r\n");
            }
            tw.Close();    
        }
        public string[] getPathes(string pathOfFolder) // get pathes from folder
        {
            string[] files = Directory.GetFiles(@pathOfFolder, "*.srt", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++)
            {               
                Console.WriteLine(files[i]);
            }
            return files; 
        }
        public List<string[]> SearchPair(string[] arrOfPath)//List of pairs 
        {
            List<FileFlow> ff = new List<FileFlow>();
            List<string[]> array = new List<string[]>();
           
            foreach (var pathes in arrOfPath)   //
            {
                ff.Add(new FileFlow { fullPathToFile = pathes, fullPathToFolder = Path.GetDirectoryName(pathes)});
            }

            List<string[]> qw = new List<string[]>(); 

           for(int i=0;i<ff.Count;i++)
            {
                for (int j = i+1; j < ff.Count; j++)
                    if (ff[i].fullPathToFolder==ff[j].fullPathToFolder && i!=j && ff[i].fullPathToFile!=ff[j].fullPathToFile)
                    {
                        array.Add(new string[] { ff[i].fullPathToFile, ff[j].fullPathToFile });
                        break;
                    }
            }            
            return array;
        }
        public void InputData(string[] pathes, FileFlow ff)
        {
            FileFlow readEng = new FileFlow(pathes[0]);
            List<Subtitle> subtitle1 = new List<Subtitle>();

            Subtitle temp = new Subtitle();
            subtitle1 = temp.WriteToList(readEng.ReadFromFile(), subtitle1);

            FileFlow readRus = new FileFlow(pathes[1]);
            List<Subtitle> subtitle2 = new List<Subtitle>();
            subtitle2 = temp.WriteToList(readRus.ReadFromFile(), subtitle2);
            subtitle1 = temp.unionSubtitle(subtitle1, subtitle2);
            ff.CreateFile(subtitle1, "E:\\path\\");
        }
    }
}
