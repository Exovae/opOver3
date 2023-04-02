using System;

namespace OperatorOverloadingEx2
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public InventoryItem(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        // Unary operator overloading
        public static InventoryItem operator +(InventoryItem item)
        {
            item.Price++;
            return item;
        }

        public static InventoryItem operator -(InventoryItem item)
        {
            item.Price--;
            return item;
        }

        public static InventoryItem operator !(InventoryItem item)
        {
            item.Price = -item.Price;
            return item;
        }

        public static InventoryItem operator ~(InventoryItem item)
        {
            item.Id = -item.Id;
            return item;
        }

        public static InventoryItem operator ++(InventoryItem item)
        {
            item.Id++;
            return item;
        }

        public static InventoryItem operator --(InventoryItem item)
        {
            item.Id--;
            return item;
        }

        // Comparison operator overloading
        public static bool operator ==(InventoryItem item1, InventoryItem item2)
        {
            return item1.Id == item2.Id && item1.Name == item2.Name && item1.Price == item2.Price;
        }

        public static bool operator !=(InventoryItem item1, InventoryItem item2)
        {
            return !(item1 == item2);
        }

        public static bool operator >(InventoryItem item1, InventoryItem item2)
        {
            return item1.Price > item2.Price;
        }

        public static bool operator <(InventoryItem item1, InventoryItem item2)
        {
            return item1.Price < item2.Price;
        }

        // Binary operator overloading
        public static InventoryItem operator +(InventoryItem item1, double amount)
        {
            return new InventoryItem(item1.Id, item1.Name, item1.Price + amount);
        }

        public static InventoryItem operator -(InventoryItem item1, double amount)
        {
            return new InventoryItem(item1.Id, item1.Name, item1.Price - amount);
        }

        public static InventoryItem operator *(InventoryItem item1, double amount)
        {
            return new InventoryItem(item1.Id, item1.Name, item1.Price * amount);
        }

        public static InventoryItem operator /(InventoryItem item1, double amount)
        {
            return new InventoryItem(item1.Id, item1.Name, item1.Price / amount);
        }

        public static InventoryItem operator %(InventoryItem item1, double amount)
        {
            return new InventoryItem(item1.Id, item1.Name, item1.Price % amount);
        }

        class Program
        {
            static void Main(string[] args)
            {
                // create two inventory objects
                Inventory inv1 = new Inventory("Apples", 10, 1.99);
                Inventory inv2 = new Inventory("Oranges", 20, 2.99);

                // display initial inventory information
                Console.WriteLine($"Initial Inventory:\n{inv1}\n{inv2}");

                // use unary overloaded operators to increment and decrement inventory
                ++inv1;
                --inv2;
                Console.WriteLine($"\nAfter incrementing Apples and decrementing Oranges:\n{inv1}\n{inv2}");

                // use comparison overloaded operators to compare inventory
                if (inv1 > inv2)
                {
                    Console.WriteLine("\nThere are more Apples than Oranges.");
                }
                else if (inv1 < inv2)
                {
                    Console.WriteLine("\nThere are more Oranges than Apples.");
                }
                else
                {
                    Console.WriteLine("\nThere are an equal number of Apples and Oranges.");
                }

                // use binary overloaded operators to combine inventory
                Inventory inv3 = inv1 + inv2;
                Console.WriteLine($"\nAfter combining inventory:\n{inv3}");

                // use binary overloaded operator to subtract inventory
                Inventory inv4 = inv3 - 5;
                Console.WriteLine($"\nAfter subtracting 5 from inventory:\n{inv4}");
            }
        }

        public class Inventory
        {
            // properties
            public string Name { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }

            // constructor
            public Inventory(string name, int quantity, double price)
            {
                Name = name;
                Quantity = quantity;
                Price = price;
            }

            // unary overloaded operators
            public static Inventory operator ++(Inventory inv)
            {
                inv.Quantity++;
                return inv;
            }

            public static Inventory operator --(Inventory inv)
            {
                inv.Quantity--;
                return inv;
            }

            // comparison overloaded operators
            public static bool operator >(Inventory inv1, Inventory inv2)
            {
                return inv1.Quantity > inv2.Quantity;
            }

            public static bool operator <(Inventory inv1, Inventory inv2)
            {
                return inv1.Quantity < inv2.Quantity;
            }

            // binary overloaded operators
            public static Inventory operator +(Inventory inv1, Inventory inv2)
            {
                string name = inv1.Name + " & " + inv2.Name;
                int quantity = inv1.Quantity + inv2.Quantity;
                double price = Math.Round((inv1.Price + inv2.Price) / 2, 2);
                return new Inventory(name, quantity, price);
            }

            public static Inventory operator -(Inventory inv, int quantity)
            {
                inv.Quantity -= quantity;
                return inv;
            }

            // ToString method
            public override string ToString()
            {
                return $"{Name} - {Quantity} in stock, ${Price} each";
            }
        }
    }
}
