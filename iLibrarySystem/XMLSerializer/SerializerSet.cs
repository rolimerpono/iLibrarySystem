using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace iLibrarySystem.XMLSerializer
{
    public class Serializerset : XMLSet<DefaultLogin.User>
    {
        public Serializerset(string P_sPath)
        {
            if ((P_sPath != string.Empty) && !File.Exists(P_sPath))
            {
                DefaultLogin.User set = new DefaultLogin.User();
                this.UpdateXmlSerialize(set, P_sPath);
            }
        }
    }
}
