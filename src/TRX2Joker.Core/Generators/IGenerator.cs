using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRX2Joker.Core.Generators
{
    public interface IGenerator
    {
        string Name { get; }

        void Generate(TestRunType testRunType);
    }
}
