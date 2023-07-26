using System;
using NoWaste.Domain.Models.Common;

namespace NoWaste.Domain.Models.Aggregates
{
    public class Category : IdentifiableDomainObject
    {
        public string Name { get; set; }
    
    }
}
