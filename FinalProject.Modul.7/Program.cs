using System.Globalization;

namespace FinalProject.Modul._7
{

    abstract class DeliveryInfo
    {
        public string Adress;
        public string CityAdress;
        public string[] CartAdd;
       
        public static string[] City = { "Moscow", "Kaluga", "Kaliningrad" };
        public static string[] Cart = { "Mouse", "KeyBoard", "MotherBoard", "Computer" };
       
    }
    abstract class Delivery : DeliveryInfo
    {
        public abstract void DeliveryToAdress(in int adress, out bool IsDelivery);
        public bool IsDelivery;
    }
    abstract class DeliveryCartInfo : DeliveryInfo
    {
         public string[] CartInfo;
        bool IsAddCart= false;
        

        public void InfoFromConsole()
        {
            if (CartInfo == null)
            {
                Console.WriteLine("Ваша корзина пуста , хотите что-то добвить?\nYes or No...");
                var YesOrNo = Console.ReadLine();
                if (YesOrNo == "Yes")
                {

                    Console.WriteLine("Что добавляем из предлоденого?");
                    foreach (var item in Cart)
                    {
                        Console.WriteLine(item);
                    }
                    var NewCart = Console.ReadLine();

                    do
                    {
                        NewCart = Console.ReadLine();
                        if (CartInfo.Contains(NewCart))
                        {
                            IsAddCart = false;
                        }
                        else 
                        {
                            Console.WriteLine("Введите название товара коректно");
                            IsAddCart = true; 
                        }
                    }
                    while (IsAddCart);

                }

            }
            else
            {
                Console.WriteLine("В вашей крзине следующие товары:");
                foreach (var item in CartInfo)
                {
                    Console.WriteLine(item);
                }
            }

        }
    }
   
    class HomeDelivery : Delivery
    {
        public override void DeliveryToAdress(in int adress, out bool IsDelivery)
        {
            if (City.Contains(CityAdress))
            {
                Console.WriteLine("Доставка в ваш город возможна\nНачинаем оформление и доставку заказа");
                IsDelivery = true;
                
            }
            else
            {
                Console.WriteLine("Мы не сможем доставить в ваш город");
                IsDelivery = false;
            }
        }
    }

    class PickPointDelivery : Delivery
    {
        
        
        public override void DeliveryToAdress(in int adress, out bool IsDelivery)
        {
          
            if (City.Contains(CityAdress))
            {
                Console.WriteLine("Доставка в ваш город возможна\nНачинаем оформление и доставку заказа");
                IsDelivery = true;        
            }
            else
            {
                Console.WriteLine("Мы не сможем доставить в ваш город");
                IsDelivery = false;
            }
        }
    }

    class ShopDelivery : Delivery
    {
        private string[] DeliveryShop = { "Moscow", "Sankt-Peterburg", "Yaroslavl" };
        public override void DeliveryToAdress(in int adress, out bool IsDelivery)
        {
            if (DeliveryShop.Contains(CityAdress))
            {
                Console.WriteLine("Доставка в ваш город возможна\nНачинаем оформление и доставку заказа");
                IsDelivery = true;
            }
            else
            {
                Console.WriteLine("Мы не сможем доставить в ваш город");
                IsDelivery = false;
            }
        }
    }
    

    class Order<TDelivery,
    TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int Number;

        public string Description;

        public string[] CityAdress;

        public void DipslpayInfo()
        {
            Console.WriteLine(Delivery.Adress);
        }
         
    }

    internal class Programm
    {
        static void Main(string[] args)
        {
          HomeDelivery homeDelivery = new HomeDelivery();
            homeDelivery.CityAdress = "Moscow";
            homeDelivery.Adress = "Pushkina 10";

            PickPointDelivery pickPointDelivery = new PickPointDelivery();
            pickPointDelivery.CityAdress = "Kazan";
            homeDelivery.Adress = "Gagarina 2";

            ShopDelivery shopDelivery = new ShopDelivery();
            shopDelivery.CityAdress = "Sankt-Peterburg";
            shopDelivery.Adress = "Moskovskiy prospekt 49";

            Order<HomeDelivery , string> order1 = new Order<HomeDelivery , string>();
            order1.Delivery = homeDelivery;
            order1.Number = 1;
            order1.Description = "ABC";

            order1.Display

        }
    }


}
