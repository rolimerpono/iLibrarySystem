using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    [Serializable]
    public class Role
    {
        public Role()
        {
            ID = string.Empty;
            ROLE = "Administrator";
            STATUS = "ACTIVE";
        }

        public string ID { get; set; }
        public string ROLE { get; set; }
        public string STATUS { get; set; }
    }
}
