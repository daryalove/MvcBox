using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Repository
{
    public class SeedOrderStages
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SmartBoxContext(serviceProvider.GetRequiredService<DbContextOptions<SmartBoxContext>>()))
            {
                //Look for any movies
                if (context.OrderStages.Any())
                {
                    return; //DB has been seeded
                }

                context.OrderStages.AddRange(
                        new OrderStage
                        {
                            Name = "Заявка"
                        },

                        new OrderStage
                        {
                            Name = "Ожидает оплату"
                        },

                        new OrderStage
                        {
                            Name = "Оплачен"
                        },

                        new OrderStage
                        {
                            Name = "Доставка в пункт загрузки"
                        },

                        new OrderStage
                        {
                            Name = "Ожидание загрузки"
                        },

                        new OrderStage
                        {
                            Name = "Выгрузка"
                        },

                        new OrderStage
                        {
                            Name = "Завершение"
                        },

                        new OrderStage
                        {
                            Name = "Выполнен"
                        }
                        ) ;
                context.SaveChanges();
            }
        }
    }
}
