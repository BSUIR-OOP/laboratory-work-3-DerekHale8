using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3.Classes
{
    public class Troll : Race
    {
        public override string Level()
            => $"The Troll {DenizenName} returned to the South Seas with {CurrentLevel} level";
    }
}
