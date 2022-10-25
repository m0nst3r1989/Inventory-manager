using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Component_finder
{
    internal static class Program
    {
        class driver
        {
            static void Main()
            {
                Item comp1 = new Item("Resistor", .50, 50);
                Item comp2 = new Item("Capacitor", .30, 45);
                Item comp3 = new Item("Transistor", .20, 35);

                InventoryManager im = new InventoryManager();
                im.addItem(comp1);
                im.addItem(comp2);
                im.addItem(comp3);

                im.displayItems();

                Console.WriteLine("\nFound Item:");
                im.searchByPrice(.50);
            }
            class InventoryManager
            {
                private Item[] inventory;
                private int count;

                public InventoryManager()
                {
                    this.inventory = new Item[50];
                    this.count = 0;
                }

                public void addItem(Item newItem)
                {
                    if (this.count < 50)
                    {
                        this.inventory[this.count] = newItem;
                        this.count += 1;
                    }
                }

                public void removeItem(int indexToDelete)
                {
                    if (indexToDelete < this.count)
                    {
                        this.inventory = this.inventory.Where((source, index) => index != indexToDelete).ToArray();
                        this.count -= 1;
                    }
                }

                public void reStock(Item item, int quantity)
                {
                    for (int i = 0; i < this.count; i++)
                    {
                        if (this.inventory[i].name.Equals(item.name))
                        {
                            this.inventory[i].quantity = quantity;
                        }
                    }
                }

                public void displayItems()
                {
                    for (int i = 0; i < this.count; i++)
                    {
                        Console.WriteLine(this.inventory[i]);
                    }
                }

                public void searchByName(string itemName)
                {
                    Item found = null;

                    for (int i = 0; i < this.count; i++)
                    {
                        if (this.inventory[i].name.Equals(itemName))
                        {
                            found = this.inventory[i];
                            break;
                        }
                    }

                    if (found != null)
                    {
                        Console.WriteLine(found);
                    }
                    else
                    {
                        Console.WriteLine("No Item Found!");
                    }
                }

                public void searchByPrice(double itemPrice)
                {
                    Item found = null;

                    for (int i = 0; i < this.count; i++)
                    {
                        if (this.inventory[i].price == itemPrice)
                        {
                            found = this.inventory[i];
                            break;
                        }
                    }

                    if (found != null)
                    {
                        Console.WriteLine(found);
                    }
                    else
                    {
                        Console.WriteLine("No Item Found!");
                    }
                }
            }

            class Item
            {
                public string name { get; set; }
                public double price { get; set; }
                public int quantity { get; set; }

                public Item()
                {
                    this.name = "";
                    this.price = 0.0;
                    this.quantity = 0;
                }

                public Item(string name, double price, int quantity)
                {
                    this.name = name;
                    this.price = price;
                    this.quantity = quantity;
                }

                public override string ToString()
                {
                    return this.name + " " + this.price + " " + this.quantity;
                }

            }
        }

    }
}

