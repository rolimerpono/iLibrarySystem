using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonFunction;

namespace iLibrarySystem.DefaultLogin
{
    [Serializable]
    public class User
    {

        CommonFunction.CommonFunction oCommonFunction =new CommonFunction.CommonFunction();

        public User()
        {
            USERNAME = oCommonFunction.Encrypt("admin");
            PASSWORD = oCommonFunction.Encrypt("rolly");
            FULLNAME = oCommonFunction.Encrypt("Rolimer Pono");
            ROLE = oCommonFunction.Encrypt("SysAdmin");
        }

        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string FULLNAME { get; set; }
        public string ROLE { get; set; }
        

    }
}
