using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tack_Tic
{
    class Program
    {
        static void Main(string[] args)
        {
            TurnHandler game = new TurnHandler();
            game.Run();
        }
    }
}
