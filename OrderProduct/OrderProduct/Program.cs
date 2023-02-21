using OrderProduct.Entities;
using OrderProduct.Entities.Enums;
using System.Globalization;


namespace OrderProduct
{
    class Program
    {
        static void Main(String[] Args)
        {
            Console.WriteLine("Enter client data");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Birth date: ");
            DateTime dateBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data: ");
            Console.Write("Enter status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.WriteLine();

            Client client = new Client(name, email, dateBirth );
            Order order1 = new Order(DateTime.Now,status, client);

            Console.Write("How many items to this order? ");
            int n=int.Parse(Console.ReadLine());

            for(int i = 1; i<= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string nameP=Console.ReadLine();
                Console.Write("Product price: ");
                double priceP = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product=new Product(nameP, priceP);

                Console.Write("Quantity: ");
                int quantityP= int.Parse(Console.ReadLine());

                OrderItem orderItem = new OrderItem(quantityP, priceP, product);

                order1.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order1);

        }



    }



}