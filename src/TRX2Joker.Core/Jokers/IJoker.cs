using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRX2Joker.Core.Jokers
{
    public interface IJoker
    {
        string Name { get; }

        void Generate(TestRunType testRunType);
    }
}
