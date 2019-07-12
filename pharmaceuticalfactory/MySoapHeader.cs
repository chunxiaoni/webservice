using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace pharmaceuticalfactory
{
    public class MySoapHeader:SoapHeader
    {
        public string UserName;
        public string PassWord;
        public bool ValideUser(string in_UserName, string in_PassWord)
        {
            if ((in_UserName == "sr") && (in_PassWord == "190430"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}