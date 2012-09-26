using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TRX2Joker.Core.Generators;

namespace TRX2Joker.Core
{
    public class Executor
    {
        private IGenerator _generator;

        public Executor(string generator)
        {
            //TODO: Use reflection and find all the classes that implement IGenerator.
            //Built in list of generators.
            var generators = new List<IGenerator> 
            { 
                new TRX2Joker.Core.Generators.Text() 
            };

            //Select the generator to use.
            this._generator = generators.SingleOrDefault(x => x.Name == generator);
            if (this._generator == null)
                throw new ArgumentException("Unknown Generator", "generator");
        }

        public void Execute(string fileName)
        {
            //Suck in the file & turn it into a test run type.
            StreamReader fileStreamReader = new StreamReader(fileName);
            XmlSerializer xmlSer = new XmlSerializer(typeof(TestRunType));
            TestRunType testRunType = (TestRunType)xmlSer.Deserialize(fileStreamReader);

            //Send the test run type to the generator
            this._generator.Generate(testRunType);
        }
    }
}
