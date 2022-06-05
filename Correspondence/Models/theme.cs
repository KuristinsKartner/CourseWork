﻿#nullable disable
using System;
using System.Collections.Generic;

namespace Correspondence.Models
{
    public partial class Theme
    {
        public Theme()
        {
            Mains = new HashSet<Main>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Main> Mains { get; set; }
    }
}