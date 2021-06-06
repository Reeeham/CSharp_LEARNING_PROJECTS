using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesWithNonGenericCollections
{
    public class IntCollection : IEnumerable
    {

        ArrayList arInts = new ArrayList();

        //unboxing
        public int GetInt(int pos) => (int)arInts[pos];

        public void AddInt(int i) { arInts.Add(i); }

        public void ClearInts() { arInts.Clear(); }

        public int Count => arInts.Count;

        IEnumerator IEnumerable.GetEnumerator() => arInts.GetEnumerator();

    }
}
