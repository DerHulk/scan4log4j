using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scan4log4j
{
    internal class Scanner
    {
        private static string FILE_LOG4J_1 = "core/logevent.class";
        private static string FILE_LOG4J_2 = "core/appender.class";
        private static string FILE_LOG4J_3 = "core/filter.class";
        private static string FILE_LOG4J_4 = "core/layout.class";
        private static string FILE_LOG4J_5 = "core/loggercontext.class";
        private static string FILE_LOG4J_2_10 = "appender/nosql/nosqlappender.class";
        private static string FILE_LOG4J_VULNERABLE = "jndilookup.class";
        private static string FILE_LOG4J_SAFE_CONDITION1 = "JndiManager.class";

        public Task Run(IDirectoryInfo startDir )
        {
            foreach(var file in startDir.GetFiles())
            {
                if (file.Exists)
                {
                    return Task.CompletedTask;
                }
            }
            return Task.CompletedTask;
        }

        internal IScannerResult Analyse(string[] paths)
        {
            var result = new ScannResult();

            if(paths.Any(x=> x.EndsWith(FILE_LOG4J_1)) && 
                paths.Any(x=> x.EndsWith(FILE_LOG4J_2)) && 
                paths.Any(x=> x.EndsWith(FILE_LOG4J_3)) && 
                paths.Any(x=> x.EndsWith(FILE_LOG4J_4)) && 
                paths.Any(x=> x.EndsWith(FILE_LOG4J_5)))
            {
                result.IsLog4J = true;

                if (paths.Any(x=> x.EndsWith(FILE_LOG4J_VULNERABLE)))
                {
                    result.IsVulnerable = true;

                    if (paths.Any(x=> x.EndsWith(FILE_LOG4J_2_10)))
                        result.IsLog4j_2_10 = true;
                }
            }            

            return result;
        }
    }
}
