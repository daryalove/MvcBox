using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Entities.Models.SmartBox;

namespace Entities.ViewModels.ContainerViewModels
{
    public class EditBoxViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите корректное значение открытия контейнера")]
        public bool IsOpenedBox { get; set; }

        [Required(ErrorMessage = "Введите корректное значение состояния контейнера")]
        public ContainerState BoxState { get; set; }

        [Required(ErrorMessage = "Введите корректное значение открытия дверей")]
        public bool IsOpenedDoor { get; set; }

        [Required(ErrorMessage = "Введите корректное значение веса")]

        [Range(0.0, 5000.0, ErrorMessage = "Значение веса должно быть от 0 до 5000 кг")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Введите корректное значение освещенности")]
        [Range(0, 1023, ErrorMessage = "Значение освещенности должно быть от 0 до 1023")]
        public int Light { get; set; }

        [Required(ErrorMessage = "Введите ПИН-код")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Введите значение температуры")]

        [Range(-40.0, 85.0, ErrorMessage = "Значение температуры должно быть от -40 до 85 °C")]
        public double Temperature { get; set; }

        [Required(ErrorMessage = "Введите значение влажности")]

        [Range(0.0, 100.0, ErrorMessage = "Значение влажности должно быть от 0% до 100%")]
        public double Wetness { get; set; }

        [Required(ErrorMessage = "Введите значение уровня заряда батареи")]

        [Range(0.0, 16.0, ErrorMessage = "Значение уровня заряда батареи должно быть от 0 до 16 вольт")]
        public double BatteryPower { get; set; }
    }
}
