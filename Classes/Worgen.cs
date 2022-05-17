using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3.Classes
{
    public class Worgen : Race
    {
        public override string Level()
            => $"The Worgen {DenizenName} returned to the Gilneas with {CurrentLevel} level";
    }
}
