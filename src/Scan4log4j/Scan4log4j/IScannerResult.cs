using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan4log4j
{
    public interface IScannerResult
    {
        bool IsLog4J { get;  }
        bool IsVulnerable { get; } 
        bool IsLog4j_2_10 { get; } 
        bool IsSafe { get;  }
    }
}
