using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CustomModelBinder
{
    public class PizzaDelivery
    {
        public string Destination { get; set; }
        [ModelBinder(BinderType = typeof(JoinDateTimeModelBinder))]
        public DateTime RequestedDeliveryDate { get; set; }
    }
}
