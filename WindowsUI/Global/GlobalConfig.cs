using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsUI
{
    class GlobalConfig
    {
        #region variables & constants

        public static string LANGUAGE = "";

        public const string ENGLISH = "English";
        public const string CROATIAN = "Croatian";

        public static string DASHBOARD = "Dashboard";
        public static string PAGE = "Page";



        #endregion  

        #region events

        public static event EventHandler LanguageChanged;

        public static void LanguageChangedFunction()
        {
            if (LanguageChanged != null)
                LanguageChanged(new object(), new EventArgs());
        }

        #endregion  
    }
}
