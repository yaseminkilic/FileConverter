using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConverter.Entities
{
    public class Worksheet
    {
        public string fileName { get; set; }
        public string directoryName { get; set; }
        public string fullPath { get; set; }
        public string name { get; set; }
        public Dictionary<int, List<string>> rowDataWithHeader { get; set; }
    }
}
