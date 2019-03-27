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
        CalculateAndPrintVerticalNumberInGraphWithoutHashing(root);
        Console.ReadKey();
    }
    public static void calculateMaxMinHorizontalValueInTree(MaxMin maxmin, Node root, int currectDistance)
    {
        if (root == null) return;
        if (maxmin.min > currectDistance)
            maxmin.min = currectDistance;
        else if (maxmin.max < currectDistance)
            maxmin.max = currectDistance;
        calculateMaxMinHorizontalValueInTree(maxmin, root.Left, currectDistance - 1);
        calculateMaxMinHorizontalValueInTree(maxmin, root.Right, currectDistance + 1);
    }
    public static void CalculateAndPrintVerticalNumberInGraphWithoutHashing(Node root)
    {
        MaxMin maxMin = new MaxMin();
        maxMin.max = maxMin.min = 0;
        calculateMaxMinHorizontalValueInTree(maxMin, root, 0);

        for (int i = maxMin.min; i < maxMin.max; i++)
        {
            CalculateHorizontalDistance(root, i, 0);

            Console.WriteLine();
        }
    }

    public static void CalculateHorizontalDistance(Node root, int horizontalValue, int currentValue)
    {
        if (root == null)
            return;

        if (horizontalValue == currentValue)
            Console.Write(root.data);
        CalculateHorizontalDistance(root.Left, horizontalValue, currentValue - 1);
        CalculateHorizontalDistance(root.Right, horizontalValue, currentValue + 1);

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

public class MaxMin
{
    public int max { get; set; }
    public int min { get; set; }
}