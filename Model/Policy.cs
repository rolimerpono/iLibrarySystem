using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Policy
    {
        public string DUE_INTEREST { get; set; }
        public string LOST_DAMAGE_INTEREST { get; set; }
        public string DAYS_LIMIT { get; set; }
        public string BOOK_LIMIT { get; set; }

    }
}
