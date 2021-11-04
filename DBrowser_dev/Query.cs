using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBrowser_dev
{
    public class Query
    {
        public string queryString;
        public string name;
        public bool saved = false;
        public bool fileCreated = false;

        public Query()
        {
            queryString = "";
            name = "Безымянный";
        }

        public Query(string queryString, string name)
        {
            this.queryString = queryString;
            this.name = name;
        }
    }
}
