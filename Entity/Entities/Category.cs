using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Descreption { get; set; }

        public List<Post> Posts { get; set; }
    }
}
