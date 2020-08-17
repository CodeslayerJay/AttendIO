using AttendIO.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendIO.Data.Entity
{
    public class EntityBase : IEntity
    {
        public int Id { get; set; }
    }
}
