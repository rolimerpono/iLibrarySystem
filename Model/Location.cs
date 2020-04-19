using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Location
    {
        public Location()
        {
            LOCATION_ID = string.Empty;
            LOCATION = string.Empty;
            STATUS = string.Empty;
        }

        public string LOCATION_ID { get; set; }
        public string LOCATION { get; set; }
        public string STATUS { get; set; }
    }
}
