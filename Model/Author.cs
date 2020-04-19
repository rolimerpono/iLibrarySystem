using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Author : NameStructure
    {

        public Author()
        {       
            STATUS = string.Empty;
        }
   
        public string STATUS { get; set; }
        
    }
}
