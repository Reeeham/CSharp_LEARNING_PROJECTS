using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIndexer
{
    class SomeClass : IStringContainer
    {
        List<string> myStrings = new List<string>();
        public string this[int index] { get => myStrings[index]; set => myStrings.Insert(index,value); }
    }
}
