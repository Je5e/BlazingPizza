using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BlazingPizza.Shared
{
   public class PizzaTopping
    {
        public int PizzaId { get; set; }
        public Topping Topping { get; set; }
        public int ToppingId { get; set; }
    }
}
