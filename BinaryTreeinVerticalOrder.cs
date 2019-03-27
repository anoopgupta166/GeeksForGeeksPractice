using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
public class HelloWorld
{
    static public void Main()
    {
        Node root = new Node(1);
        root.Left = new Node(2);
        root.Right = new Node(3);
        root.Left.Left = new Node(4);
        root.Left.Right = new Node(5);
        root.Right.Left = new Node(6);
        root.Right.Right = new Node(7);
        root.Right.Right.Left = new Node(8);
        root.Right.Right.Right = new Node(9);
        CalculateAndPrintVerticalNumberInGraph(root);
        Console.ReadKey();
    }

    public static void CalculateAndPrintVerticalNumberInGraph(Node root)
    {
        SortedDictionary<int, List<int>> HorizontalScale = new SortedDictionary<int, List<int>>();
        CalculateHorizontalDistance(root, 0, HorizontalScale);
        
        foreach (var item in HorizontalScale)
        {
            foreach (var node in item.Value)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
        }
    }

    public static void CalculateHorizontalDistance(Node root, int horizontalValue, SortedDictionary<int, List<int>> scale)
    {
        if (root == null)
            return;
        if (!scale.ContainsKey(horizontalValue))
            scale.Add(horizontalValue, new List<int>());
        scale[horizontalValue].Add(root.data);
        CalculateHorizontalDistance(root.Left, horizontalValue - 1, scale);
        CalculateHorizontalDistance(root.Right, horizontalValue + 1, scale);
    }
}

public class Node
{
    public int data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int val)
    {
        this.data = val;
    }
}