using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arango.Client
{
    public class ViewLink
    {
        public string[] analyzers = new string[1];
        public ViewFields fields { get; set; }
        public bool includeAllFields { set; get; }
        public string storeValues { get; set; }
        public bool trackListPositions { get; set; }
    }
}
