#nullable disable
using System;
using System.Collections.Generic;

namespace Correspondence.Models
{
    public partial class Place
    {
        public Place()
        {
            Mains = new HashSet<Main>();
        }

        public int Id { get; set; }
        public string FullPlace { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Owner { get; set; }

        public virtual ICollection<Main> Mains { get; set; }
    }
}