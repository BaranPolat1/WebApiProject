using Core.Entity;
using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Entities
{
   public class AppUser:BaseEntity
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role? Role { get; set; }
        public byte[] passwordhash { get; set; }
        public byte[] passwordsalt { get; set; }

        [NotMapped]
        public List<Post> Posts { get; set; }

    }
}
