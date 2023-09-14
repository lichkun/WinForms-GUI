using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAndBooks
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int AuthorId { get; set; }
        public Book(string t, int a)
        {
            this.Title = t;
            this.AuthorId = a;
        }
    }
}
