using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsUI
{
    public partial class Phrases
    {
        private static Dictionary<string, string> _englishDictionary;

        public static Dictionary<string, string> EnglishDictionary
        {
            get
            {
                if (_englishDictionary == null)
                {
                    _englishDictionary = new Dictionary<string, string>();


                    _englishDictionary.Add("EXIT", "Exit");
                    _englishDictionary.Add("DASHBOARD", "Dashboard");
                    _englishDictionary.Add("ABOUT", "About");
                    _englishDictionary.Add("VIEWWINDOW", "View Window");
                    _englishDictionary.Add("VIEWFULLSCREEN", "View Full screen");
                    _englishDictionary.Add("PAGE1", "Page 1");
                    _englishDictionary.Add("PAGE2", "Page 2");
                    _englishDictionary.Add("PAGE3", "Page 3");
                    _englishDictionary.Add("BACK", "Back");
                    _englishDictionary.Add("STEP1", "Step 1");

                    _englishDictionary.Add("YNQUIT", "Do You Want To Quit?");
                    _englishDictionary.Add("ENGLISH", "Croatian");
                    _englishDictionary.Add("CROATIAN", "English");
                }

                return _englishDictionary;
            }
        }

    }
}
