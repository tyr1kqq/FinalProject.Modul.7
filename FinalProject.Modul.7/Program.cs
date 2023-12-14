using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace FinalProject.Modul._7
{
    internal class Programm
    {
        static void Main(string[] args)
        {
                        
           
        }
    }
    abstract class Delivery 
    {
        public string Address;

        public string NameProduct;

        public string[] IsAdress = { "Moscow", "Kalinigrad", "Sankt-Peterburg" };

        public string[] NameProductInMagazine = { "Computer" , "Game" , "Mouse"};
        public virtual bool IsDelivery { get; set; }

        public virtual string IsProduct { get; set; }

        
    }

    class HomeDelivery : Delivery
    {
        private bool Courier;
        public override bool IsDelivery
        {
            get { return Courier; }
            set 
            {
                if (IsAdress.Contains(Address))
                    Console.WriteLine("Заказ принят в работу");
                
                else
                    Console.WriteLine("Нет курьра в данном регионе");

                Courier = value;
            }
        }
    }

    class PickPointDelivery : Delivery
    {
        private bool PickPoint;
        public override bool IsDelivery
        {
            get { return PickPoint; }
            set
            {
                if (IsAdress.Contains(Address))
                    Console.WriteLine("Заказ принят в работу");

                else
                    Console.WriteLine("Нет пункта выдачи в данном регионе");

                PickPoint = value;
            }
        }
    }

    class ShopDelivery : Delivery
    {

        private string Product;
        public override string IsProduct 
        {
        get
            { return Product; }

            set
            {
                if (NameProductInMagazine.Contains(NameProduct))
                    Console.WriteLine("Вы добавили {0} в корзину" , NameProduct);
                NameProduct = value;
            }
        
        }

    }

    class Order<TDelivery,
    TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int Number;

        public string Description;

        

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }
       
        

        
    }
}