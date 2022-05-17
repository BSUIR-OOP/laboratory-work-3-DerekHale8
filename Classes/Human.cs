using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3.Classes
{
    public class Human : Race
    {
        public override string Level()
            => $"A Human {DenizenName}  returned to the Stormgrad with {CurrentLevel} level";
    }
}
