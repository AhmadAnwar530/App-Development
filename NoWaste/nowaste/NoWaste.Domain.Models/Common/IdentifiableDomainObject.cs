using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoWaste.Domain.Models.Common
{
    public class IdentifiableDomainObject
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
    }
}
