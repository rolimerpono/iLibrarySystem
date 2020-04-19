using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Borrower : NameStructure
    {

        public Borrower()
        {                        
            DOB = string.Empty;
            AGE = String.Empty ;
            CONTACT_NO = string.Empty;
            ADDRESS = string.Empty;            
            ADDED_DATE = string.Empty;
            MODIFIED_DATE = string.Empty;
            ADDED_BY = string.Empty;
            MODIFIED_BY = string.Empty;
            PROFILE_PIC = string.Empty;
            STATUS = "ACTIVE";              
        }        
   
        public string DOB { get; set; }
        public string AGE { get; set; }
        public string CONTACT_NO { get; set; }
        public string ADDRESS { get; set; }        
        public string ADDED_DATE { get; set; }
        public string ADDED_BY { get; set; }
        public string MODIFIED_DATE { get; set; }        
        public string MODIFIED_BY {get;set;}   
        public string PROFILE_PIC { get; set; }
        public string STATUS { get; set; }           
    }
  
}
