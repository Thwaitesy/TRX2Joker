using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TRX2Joker.Core.Jokers;

namespace TRX2Joker.Core
{
    public class Executor
    {
        private IJoker _joker;

        public Executor(string joker)
        {
            //TODO: Use reflection and find all the classes that implement IJoker.
            //Built in list of jokers.
            var jokers = new List<IJoker> 
            { 
                new TRX2Joker.Core.Jokers.TextFile() 
            };

            //Select the joker to use.
            this._joker = jokers.SingleOrDefault(x => x.Name == joker);
            if (this._joker == null)
                throw new ArgumentException("Unknown Joker", "joker");
        }

        public void Execute(string fileName)
        {
            //Suck in the file & turn it into a test run type.
            StreamReader fileStreamReader = new StreamReader(fileName);
            XmlSerializer xmlSer = new XmlSerializer(typeof(TestRunType));
            TestRunType testRunType = (TestRunType)xmlSer.Deserialize(fileStreamReader);

            //Send the test run type to the joker
            this._joker.Generate(testRunType);
        }
    }
}
