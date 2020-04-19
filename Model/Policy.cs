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
        public string MAX_DAYS_BORROW { get; set; }
        public string MAX_BOOK_BORROW { get; set; }

    }
}
