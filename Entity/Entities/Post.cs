using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
   public class Post:BaseEntity
    {
        public string Header { get; set; }
        public string Content { get; set; }

        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
