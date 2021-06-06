using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIndexer
{
    public class PersonCollection : IEnumerable
    {
        // private ArrayList arPeople = new ArrayList();
        private Dictionary<string, Person> arPeople = new Dictionary<string, Person>();
        // Custom indexer for this class.
        public Person this[string name]
        { get => (Person)arPeople[name];
          set => arPeople[name]=value; }

        // Cast for caller.
        public Person GetPerson(int pos) => (Person)arPeople[pos];

        

        public void ClearPeople()
        { arPeople.Clear(); }

        public int Count => arPeople.Count;

        // Foreach enumeration support.
        IEnumerator IEnumerable.GetEnumerator() => arPeople.GetEnumerator();
    }
}
