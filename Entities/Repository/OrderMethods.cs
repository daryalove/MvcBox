using Entities.Models;
using Entities.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Repository
{
    public class OrderMethods
    {
        public List<Rate> Rates { get; set; }
        public OrderMethods()
        {
            this.Rates = new List<Rate>();
            Rates.Add(new Rate { Name = "Способ погрузки" });
            Rates.Add(new Rate { Name = "Класс опасности" });
            Rates.Add(new Rate { Name = "Страховой коэффициент" });

            Rates[0].RateTypes.Add(new RateType { Name = "Тарно-штучные", Price = 0.01, RateId = Rates[0].Id });
            Rates[0].RateTypes.Add(new RateType { Name = "Жидкие", Price = 0.011, RateId = Rates[0].Id });
            Rates[0].RateTypes.Add(new RateType { Name = "Насыпные", Price = 0.012, RateId = Rates[0].Id });

            Rates[1].RateTypes.Add(new RateType { Name = "0_класс", Index = 1, RateId = Rates[1].Id });
            Rates[1].RateTypes.Add(new RateType { Name = "1_класс", Index = 1.25, RateId = Rates[1].Id });
            Rates[1].RateTypes.Add(new RateType { Name = "2_класс", Index = 1.29, RateId = Rates[1].Id });
            Rates[1].RateTypes.Add(new RateType { Name = "3_класс", Index = 1.4, RateId = Rates[1].Id });
            Rates[1].RateTypes.Add(new RateType { Name = "4.1_класс", Index = 1.5, RateId = Rates[1].Id });
            Rates[1].RateTypes.Add(new RateType { Name = "4.2_класс", Index = 1.8, RateId = Rates[1].Id });
            Rates[1].RateTypes.Add(new RateType { Name = "4.3_класс", Index = 2.2, RateId = Rates[1].Id });
            Rates[1].RateTypes.Add(new RateType { Name = "5.1_класс", Index = 2.1, RateId = Rates[1].Id });
            Rates[1].RateTypes.Add(new RateType { Name = "5.2_класс", Index = 1.6, RateId = Rates[1].Id });
            Rates[1].RateTypes.Add(new RateType { Name = "6.1_класс", Index = 1.25, RateId = Rates[1].Id });
            Rates[1].RateTypes.Add(new RateType { Name = "6.2_класс", Index = 2.7, RateId = Rates[1].Id });
            Rates[1].RateTypes.Add(new RateType { Name = "7_класс", Index = 1.34, RateId = Rates[1].Id });
            Rates[1].RateTypes.Add(new RateType { Name = "8_класс", Index = 1.89, RateId = Rates[1].Id });
            Rates[1].RateTypes.Add(new RateType { Name = "9_класс", Index = 1.1, RateId = Rates[1].Id });

            Rates[2].RateTypes.Add(new RateType { Name = "Страхование", Index = 0.0012, RateId = Rates[2].Id });
        }

        public double PriceComputation(PriceComputationViewModel model)
        {
            try
            {
                var dangerClass = Rates[1].RateTypes.Find(f => f.Name == model.DangerClassType);
                var carge = Rates[0].RateTypes.Find(f => f.Name == model.CargeType) ;

                var price = model.Length * model.Weight * (carge.Price) * (dangerClass.Index);
                if (model.IsInsured)
                {
                    price += (Rates[2].RateTypes[0].Index) * model.CargeValue;
                }

                //var result = Math.Ceiling(price);
                return price;
            }
            catch (Exception)
            {
                return 0.00;
            }
        }
    }
}
