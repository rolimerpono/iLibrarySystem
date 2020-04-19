using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Category
    {

        public Category()
        {
            CATEGORY_ID = string.Empty;
            CATEGORY = string.Empty;
            STATUS = string.Empty;
        }
        public string CATEGORY_ID { get; set; }
        public string CATEGORY { get; set; }
        public string STATUS { get; set; }


    }
}
