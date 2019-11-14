using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.ViewModels.ContainerViewModels
{
    public class EditBoxViewModel
    {
        public bool IsOpenedBox { get; set; }
        public bool IsOpenedDoor { get; set; }

        [Range(0.0, 5000.0)]
        public double Weight { get; set; }

        [Range(0, 1023)]
        public int Light { get; set; }
        public string Code { get; set; }

        [Range(-40.0, 85.0)]
        public double Temperature { get; set; }

        [Range(0.0, 100.0)]
        public double Wetness { get; set; }

        [Range(0.0, 16.0)]
        public double BatteryPower { get; set; }
    }
}
