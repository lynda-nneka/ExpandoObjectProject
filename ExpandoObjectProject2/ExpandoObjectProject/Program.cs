using System;
using ExpandoObjectProject;

public static class Program
{
    public static void Main(string[] args)
    {
        
        // This is for selecting the properties
        Console.WriteLine("Please enter the properties you want separated by a comma\nEnter a blank input to get every property");
        var userInput = Console.ReadLine();
       
        List<string> commaSeparatedProperties = userInput.ToLower().Split(',').ToList();

        if (userInput == "")
        {
            commaSeparatedProperties = null;
        }

        

        ProductsStore store = new();
        var listOfSelectiveProducts = store.ProductsList(commaSeparatedProperties);

        foreach (dynamic product in listOfSelectiveProducts)
        {
            var dynamicDictionary = product as IDictionary<string, object>;

            foreach (KeyValuePair<string, object> property in dynamicDictionary)
            {
                Console.WriteLine("{0}: {1}", property.Key.ToUpper(), property.Value.ToString());
            }

            Console.WriteLine();
        }

        Console.ReadKey();
    }
}