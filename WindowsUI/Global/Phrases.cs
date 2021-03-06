﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsUI
{
    public partial class Phrases
    {
        public static String GetPhrase(string value)
        {
            string msg = "";

            Dictionary<string, string> languageDictionary = new Dictionary<string, string>();

            switch(GlobalConfig.LANGUAGE)
            {
                case GlobalConfig.ENGLISH:
                    languageDictionary = Phrases.EnglishDictionary;
                    break;
                case GlobalConfig.CROATIAN:
                    languageDictionary = Phrases.CroatianDictionary;
                    break;
                default:
                    break;
            }

            if (languageDictionary.Count > 0)
            {
                languageDictionary.TryGetValue(value, out msg);
            }

            return msg;
        }
    }
}
