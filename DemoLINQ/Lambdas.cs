using System.Linq;

class Lambdas
{
    static void Main(string[] args)
    {
        string[] names = {"David","Jane","Peter","bao ngu"};
        foreach(string item in names.OrderBy(s => s)){
            Console.WriteLine(item);
        }
        Console.ReadLine();
    }
}
