using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3.Classes
{
    public class DenizensOfAzeroth : IEnumerable
    {
        private List<Race> Denizens = new List<Race>();

        public int Count
            => Denizens.Count;

        public void Add(Race t)
            => Denizens.Add(t);

        public void Remove(Race t)
            => Denizens.Remove(t);

        public List<Race> GetDenizens()
            => Denizens;

        public Race Get(int index)
            => Denizens[index];

        public IEnumerator GetEnumerator()
            => Denizens.GetEnumerator();
    }
}
