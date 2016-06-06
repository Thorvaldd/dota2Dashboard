using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Import
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // ImportDota2Entities.ImportHeroes();
              //  ImportDota2Entities.ImportSmallHeroIcons();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message);
            }
           
        }
    }
}
