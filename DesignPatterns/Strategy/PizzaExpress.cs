using DesignPatterns.Adapter;
using DesignPatterns.FactoryMethod.PizzaShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategy
{
    internal class PizzaExpress
    {
        // Statt einer konkreten Implementierung nutzen wir den abstrakten Typ IVehicle
        public IVehicle Vehicle { get; private set; }

        public void Order(string name, int distanceInMeters)
        {
            var pizza = FancyPizzaStore.OrderPizza(name);

            SelectDeliveryStrategy(distanceInMeters);

            Deliver(pizza);
        }

        private void SelectDeliveryStrategy(int distanceInMeters)
        {
            if (distanceInMeters < 1000)
            {
                Vehicle = new Bike();
            }
            else if (distanceInMeters < 5000)
            {
                Vehicle = new Car("Fiat Punto");
            }
            else 
            {
                Vehicle = new Drone();
            }
        }

        private void Deliver(Pizza pizza)
        {
            Console.WriteLine($"{pizza} mit {Vehicle.Name} an Kunden ausliefern.");
        }
    }
}
