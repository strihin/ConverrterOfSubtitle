using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterOfSubtitles
{
    class Subtitle
    {
       public int Number { get; set;}        
       public string Time { get; set; }
       public  string SubtitleEng { get; set; }
       public  string SubtitleRus { get; set; }

        public List<Subtitle> WriteToList(List<string> tempList, List<Subtitle> toList, int index=0)
        {
            int m = 0;
            for (var i = 0; i < tempList.Count; i++)
            {
                if (tempList[i] != String.Empty)
                {
                    if (Int32.TryParse(tempList[i], out m))
                    {
                        if (toList.Count == 0)
                            toList.Add(new Subtitle { Number = Convert.ToInt16(tempList[i]) });
                        else
                            toList[index].Number = Convert.ToInt16(tempList[i]);
                    }
                    if (tempList[i].Contains("-->"))
                    {
                        toList[index].Time = tempList[i];
                    }
                    if (Char.IsLetter(tempList[i], 0) || Char.IsPunctuation(tempList[i][0]) || tempList[i][0]==' ')
                    {
                        toList[index].SubtitleRus +=tempList[i]+" ";
                    }
                }
                else
                {
                    toList.Add(new Subtitle { });
                    index++;
                }
            }      
            return toList;
        } 
        public List<Subtitle> unionSubtitle(List<Subtitle> st1, List<Subtitle> st2)
        { 
                for (int j = 0; j < st1.Count; j++)
                {
                    if (st1[j].Number == st2[j].Number && st1[j].Time==st2[j].Time)
                        st1[j].SubtitleEng = st2[j].SubtitleRus;
                }           
            return st1;
        }          
    }
}
