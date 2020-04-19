using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public abstract class NameStructure
    {

        public NameStructure()
        {
            PERSON_ID = string.Empty;
            FIRST_NAME = string.Empty;
            MIDDLE_NAME = string.Empty;
            LAST_NAME = string.Empty;
        }


        public string PERSON_ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string MIDDLE_NAME { get; set; }
        public string LAST_NAME { get; set; }

        public string GetFullName
        {
            get
            {
                return FIRST_NAME + " " + MIDDLE_NAME + " " + LAST_NAME;
            }
        }
        

    }
}
