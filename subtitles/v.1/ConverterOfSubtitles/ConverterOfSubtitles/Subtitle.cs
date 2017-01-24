using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterOfSubtitles
{
    class Subtitle
    {
       public int number { get; set;}        
       public string time { get; set; }
       public  string subtitleEng { get; set; }
       public  string subtitleRus { get; set; }

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
                            toList.Add(new Subtitle { number = Convert.ToInt16(tempList[i]) });
                        else
                            toList[index].number = Convert.ToInt16(tempList[i]);
                    }
                    if (tempList[i].Contains("-->"))
                    {
                        toList[index].time = tempList[i];
                    }
                    if (Char.IsLetter(tempList[i], 0) || Char.IsPunctuation(tempList[i][0]) || tempList[i][0]==' ')
                    {
                        toList[index].subtitleRus +=tempList[i]+" ";
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
                    if (st1[j].number == st2[j].number && st1[j].time==st2[j].time)
                        st1[j].subtitleEng = st2[j].subtitleRus;
                }           
            return st1;
        }          
    }
}
