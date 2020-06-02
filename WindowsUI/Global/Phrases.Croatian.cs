using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsUI
{
    public partial class Phrases
    {
        private static Dictionary<string, string> _croatianDictionary;

        public static Dictionary<string, string> CroatianDictionary
        {
            get
            {
                if (_croatianDictionary == null)
                {
                    _croatianDictionary = new Dictionary<string, string>();
                    _croatianDictionary.Add("DASHBOARD", "Kontrolna ploča");
                    _croatianDictionary.Add("ABOUT", "Informacije");
                    _croatianDictionary.Add("VIEWWINDOW", "Pogled prozor");
                    _croatianDictionary.Add("VIEWFULLSCREEN", "Pogled puni zaslon");
                    _croatianDictionary.Add("EXIT", "Izlaz");
                    _croatianDictionary.Add("PAGE1", "Stranica 1");
                    _croatianDictionary.Add("PAGE2", "Stranica 2");
                    _croatianDictionary.Add("PAGE3", "Stranica 3");
                    _croatianDictionary.Add("BACK", "Natrag");
                    _croatianDictionary.Add("STEP1", "Naprijed");

                    _croatianDictionary.Add("YNQUIT", "Da li želite izaći iz aplikacije?");
                    _croatianDictionary.Add("ENGLISH", "Hrvatski");
                    _croatianDictionary.Add("CROATIAN", "Engleski");
                }

                return _croatianDictionary;
            }
        }


    }
}
