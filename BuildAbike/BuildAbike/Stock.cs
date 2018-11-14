using System.Collections.Generic;
using System.Linq;

namespace BuildAbike
{
    public static class Stock
    {
        // Available Colours, Frame Sizes, Bike components
        private static List<string> colours = new List<string>();
        private static List<string> sizes = new List<string>();
        private static Dictionary<int, string> items = new Dictionary<int, string>();
        // Component prices and the amount on stock
        private static Dictionary<int, double> price = new Dictionary<int, double>();
        private static Dictionary<int, int> count = new Dictionary<int, int>(); // for number of items on stock

        public static List<string> Colours { get => colours; }
        public static List<string> Sizes { get => sizes; }
        public static Dictionary<int, string> Items { get => items; }

        public static void Load()
        {// Load in stock list
         // This would be stored in an external file normally
            Colours.Add("Red"); Colours.Add("Blue"); Colours.Add("Green"); Colours.Add("Black");
            Sizes.Add("Extra Small"); Sizes.Add("Small"); Sizes.Add("Medium"); Sizes.Add("Large");
            Items.Add(101, "Group Set 1 (Shimano, Shimano)");
            Items.Add(102, "Group Set 2 (SRAM, Avid)");
            Items.Add(103, "Group Set 3 (Campagnolo, Clarks)");
            Items.Add(201, "Shimano");
            Items.Add(202, "Campagnolo");
            Items.Add(203, "Zipp");
            Items.Add(204, "Cosine");
            Items.Add(205, "DT Swiss");
            Items.Add(301, "Group Set 1 (Renthal FatBar, Prologo)");
            Items.Add(302, "Group Set 2 (Race Face, Fizik Arione)");
            Items.Add(303, "Group Set 3 (Ragley Wiser, Prologo)");

            price.Add(101, 199);
            price.Add(102, 299);
            price.Add(103, 399);
            price.Add(201, 99);
            price.Add(202, 159);
            price.Add(203, 209);
            price.Add(204, 209);
            price.Add(205, 209);
            price.Add(301, 129);
            price.Add(302, 199);
            price.Add(303, 259);

            count.Add(101, 1);
            count.Add(102, 5);
            count.Add(103, 1);
            count.Add(201, 1);
            count.Add(202, 2);
            count.Add(203, 1);
            count.Add(204, 1);
            count.Add(205, 1);
            count.Add(301, 6);
            count.Add(302, 3);
            count.Add(303, 2);
        }

        public static int getItemID(string name)
        {// Return Item ID given the name
            return Items.FirstOrDefault(x => x.Value == name).Key;
        }
        public static double getItemPrice(int ID)
        {// Return Item price given the ID
            return price[ID];
        }
        public static string getItemName(int ID)
        {// Return Item name given the ID
            return items[ID];
        }
        public static int getItemCount(int ID)
        {// Return Item count given the ID
            return count[ID];
        }
        public static void decreaseItemCount(int ID)
        {// Decrease Item count given the ID
            count[ID] -= 1;
        }
    }
}
