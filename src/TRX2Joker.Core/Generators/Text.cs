using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRX2Joker.Core.Generators
{
    public class Text : IGenerator
    {
        public void Generate(TestRunType testRunType)
        {
            //Output a file with the details of the test run.
        }

        public string Name
        {
            get { return "Text"; }
        }
    }
}
