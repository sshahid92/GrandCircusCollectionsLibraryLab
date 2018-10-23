using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusCollections_Library
{
    class Library : IComparable<Library>
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public bool CheckedOut { get; set; }


        public int CompareTo(Library that)
        {
            int result = this.Author.CompareTo(that.Author);

            return result;
        }


    }
}
