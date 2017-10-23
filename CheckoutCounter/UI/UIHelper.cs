using System;

namespace CheckoutCounter.UI
{
    public static class UIHelper
    {
        public static void PrintOrderDetailsToConsole(this Order order)
        {

            Console.WriteLine($"Order Information for Order: {order.Id }");
            Console.WriteLine($"Placed at: {order.OrderDate}");
            Console.WriteLine();


            PrintLine();
            PrintRow("Name", "Quantity", "Unit Price","Amount", "Tax");
            PrintLine();
            
            try
            {
                foreach (var item in order.OrderDetails)
                {
                    PrintRow(item.Item.Name, item.Quantity.ToString(), item.Item.Price.ToString(),item.Total.ToString(), item.Tax.ToString());
                }
            }
            catch (Exception ex)
            {
                PrintRow("No items ordered.");
            }

            PrintLine();

            PrintRow("Total", "", "",order.SumTotal.ToString(), order.TaxTotal.ToString());
            
            PrintLine();
            Console.WriteLine();
            Console.Write($"Total Payable = {order.Total}/-");
        }

        static int tableWidth = 77;

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
