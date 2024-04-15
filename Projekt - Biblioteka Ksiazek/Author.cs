using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt___Biblioteka_Ksiazek
{
    public sealed class Author
    {
        private string name;
        private int years;
        private bool isAlive;

        public Author(string name, int years, bool isAlive)
        {
            this.name = name;
            this.years = years;
            this.isAlive = isAlive;
        }

        public string Name { get { return name; } }
        public int Years { get { return years; } }
        public bool IsAlive { get {  return isAlive; } }

        public override bool Equals(object? obj)
        {
            return obj is Author author &&
                   name == author.name &&
                   years == author.years &&
                   isAlive == author.isAlive &&
                   Name == author.Name &&
                   Years == author.Years &&
                   IsAlive == author.IsAlive;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, years, isAlive, Name, Years, IsAlive);
        }
        public override string ToString()
        {
            return $"Author: {name}, Age: {years}, Alive: {(isAlive ? "Yes" : "No")}";
        }
    }
}
