using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAndBooks
{
    [DataContract]
    public class Author
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Id { get; set; }
        public Author(string name, int i) { Name = name; Id = i; }

    }
}
