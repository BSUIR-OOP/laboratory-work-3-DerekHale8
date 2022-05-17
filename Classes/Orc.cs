using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3.Classes
{
    public class Orc : Race
    {
        public override string Level()
            => $"The Orc {DenizenName} returned to the Orgrimmar with {CurrentLevel} level";
    }
}
