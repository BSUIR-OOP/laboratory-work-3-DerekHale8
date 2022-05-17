using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3.Classes
{
    public abstract class Race
    {
        public int CurrentLevel { get; set; }

        public int Health { get; set; }

        public int Power { get; set; }

        public string DenizenName { get; set; } = string.Empty;

        public Race() { }

        public void LevelUp(int delta)
            => CurrentLevel += delta;

        public void LevelLess(int delta)
            => CurrentLevel = CurrentLevel - delta > 0 ? CurrentLevel - delta : 0;

        public string ShowInfo()
            => $"Name: {DenizenName}; Current level: {CurrentLevel}; Health: {Health}; Power: {Power}";

        public abstract string Level();
    }
}
