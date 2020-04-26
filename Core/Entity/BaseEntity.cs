using Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
       
        private DateTime _addedDate = DateTime.Now;
        public DateTime AddedDate { get { return _addedDate; } set { _addedDate = value; } }

        public DateTime? ModifiedDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get { return _status; } set { _status = value; } }
    }
}
