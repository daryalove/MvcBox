using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Entities.Models
{
    public class SmartBox
    {
        
        public enum ContainerState
        {
            //сложенный, то есть контейнер закрыт

            onBase = 1, //на складе
            onCar,//на автомобиле
            onShipper, //выгружен у грузоотправителя
            onConsignee//разгружен у грузополучателя
        }
        public SmartBox()
        {
            Locations = new HashSet<Location>();
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public bool IsOpenedBox { get; set; }
        public ContainerState BoxState { get; set; }
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
        public ICollection<Location> Locations { get; set; }
    }
}
