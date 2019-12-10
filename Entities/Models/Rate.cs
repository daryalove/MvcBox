using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Rate
    {
        public Rate()
        {
            this.RateTypes = new List<RateType>();
        }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<RateType> RateTypes { get; set; }
    }
}
