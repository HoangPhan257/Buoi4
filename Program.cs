using System;
using System.Collections.Generic;
using System.Linq;

public class Item
{
    public int Value { get; set; }
    public int Weight { get; set; }
    public int Quantity { get; set; } // Số lượng tối đa của đồ vật
    public double Ratio { get { return (double)Value / Weight; } }
}

public class Program
{
    static void Main(string[] args)
    {
        List<Item> items = new List<Item>
        {
            new Item { Value = 60, Weight = 10, Quantity = 3 },
            new Item { Value = 100, Weight = 20, Quantity = 2 },
            new Item { Value = 120, Weight = 30, Quantity = 1 }
        };

        int capacity = 50;

        double maxValue = GreedyKnapsack(capacity, items);
        Console.WriteLine("Maximum value in Knapsack = " + maxValue);
        Console.ReadLine();
    }

    public static double GreedyKnapsack(int capacity, List<Item> items)
    {
        // Sort items by value-to-weight ratio in descending order
        items.Sort((x, y) => y.Ratio.CompareTo(x.Ratio));

        double totalValue = 0;
        int currentWeight = 0;

        foreach (var item in items)
        {
            int availableQuantity = Math.Min(item.Quantity, (capacity - currentWeight) / item.Weight);
            int addedWeight = availableQuantity * item.Weight;
            totalValue += availableQuantity * item.Value;
            currentWeight += addedWeight;

            if (currentWeight >= capacity)
            {
                break;
            }
        }

        return totalValue;
    }
}