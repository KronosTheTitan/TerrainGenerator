using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainGenerator
{
    class Start
    {
        static void Main(string[] args)
        {
            Generator generator = new Generator();
            generator.GenerateTerrain();
            // Display the number of command line arguments.
            Console.WriteLine(args.Length);
            while (true) ;
        }
    }
}
