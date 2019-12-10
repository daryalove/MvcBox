using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class RateType
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public double Price { get; set; }
        public double Index { get; set; }
        public Guid RateId { get; set; }
    }
}
