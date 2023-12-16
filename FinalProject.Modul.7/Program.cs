using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using System.Xml.Linq;

namespace FinalProject.Modul._7
{
    
    abstract class Delivery
    {
        public string Address;
    }

    abstract class DeliveryRegoin : Delivery
    {
        public string[] Region = { "Moscow region", "Yaroslavl region", "Kalininrad region" };
        
    }

    abstract class DeliveryCity : DeliveryRegoin
    {
        public string[] CityInMoscowRegion = { "Moscow" , "Himki" , "Podolsk" };
        public string[] CityInYaroslavlRegion = { "Yaroslavl", "Ribinsk", "Danilov" };
        public string[] CityInKaliningradRegion = { "Kaliningrad", "Gvardeysk", "Baltiysk" };
    }

    

    class HomeDelivery : Delivery
    {
       
    }

    class PickPointDelivery : Delivery
    {
        /* ... */
    }

    class ShopDelivery : Delivery
    {
        /* ... */
    }

    class DeliveryInfo : DeliveryCity
    {
        public DeliveryInfo()
        {
            Console.WriteLine("Добро пожаловать в магазин \n сначала посмотри  город , куда возможна доставка");
            Console.Write("Города в московской области: ");
            foreach (var CityInMoscow in CityInMoscowRegion)
            {
                Console.Write(CityInMoscow + "  ");
            }
            Console.WriteLine();
            Console.Write("Города Ярославской области: ");
            foreach (var CityInYaroslavl in CityInYaroslavlRegion)
            {
                Console.Write(CityInYaroslavl + "  ");
            }
            Console.WriteLine();
            Console.Write("Города Калиниградской области:");
            foreach (var CityInKaliningrad in CityInKaliningradRegion)
            {
                Console.Write(CityInKaliningrad + "  ");
            }




        }
    }
    class Order<TDelivery> where TDelivery : Delivery
    {
        public TDelivery Delivery;

       
        // ... Другие поля
    }

    internal class Programm
    {
        static void Main(string[] args)
        {
            DeliveryInfo CityInfo = new DeliveryInfo();
            Console.WriteLine(CityInfo);
        }
    }


}
