using System;

class SQLExpression
{
    static void Main(string[] args)
    {
        string[] name = {"Tan Dai","Tan Vy","Huy Hoang"};
        var items = from word in name where word.Contains("Dai") select word;
        foreach(var item in items)
        {
            Console.WriteLine(item);
        }
        Console.ReadLine();
    }
}