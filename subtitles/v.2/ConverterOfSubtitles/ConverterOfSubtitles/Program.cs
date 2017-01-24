using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConverterOfSubtitles
{
    class Program
    {
        static void Main(string[] args)
        {
           
            FileFlow readEng = new FileFlow("e:\\something\\1.srt");   
            List<Subtitle> subtitle1 = new List<Subtitle>();

            Subtitle temp = new Subtitle();
            subtitle1 = temp.WriteToList(readEng.ReadFromFile(), subtitle1);

            FileFlow readRus = new FileFlow("e:\\something\\12.txt");
            List<Subtitle> subtitle2 = new List<Subtitle>();
            subtitle2 = temp.WriteToList(readRus.ReadFromFile(), subtitle2);
            
            subtitle1 = temp.unionSubtitle(subtitle1, subtitle2);
            

            FileFlow ff = new FileFlow();
            ff.CreateFile(subtitle1, "E:\\path\\" );
            var arrayOfPathes = ff.SearchPair(ff.getPathes("E:\\something\\DW"));
            
           ff.InputData(arrayOfPathes[0],ff);





        }     
    }
}
