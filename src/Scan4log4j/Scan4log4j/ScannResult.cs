using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan4log4j
{
    internal class ScannResult : IScannerResult
    {
        public bool IsLog4J { get; set; } = false;
        public bool IsVulnerable { get; set; } = false;
        public bool IsLog4j_2_10 { get; set; } = false; 
        public bool IsSafe { get; set; } = false;
    }
}
