using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRX2Joker.Core;

namespace TRX2Joker.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
                return;

            var filename = args[0];
            var joker = args[1];

            new Executor(joker).Execute(filename);
        }
    }
}
