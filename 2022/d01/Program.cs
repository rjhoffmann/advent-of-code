// See https://aka.ms/new-console-template for more information

using MoreLinq;

var input = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
var data = File.ReadLines(input)
    .Split(x => x == "", y => y.Sum(int.Parse))
    .ToArray();

var max = data.Max();
var topThree = data.OrderByDescending(d => d).Take(3).Sum();

Console.WriteLine(max);
Console.WriteLine(topThree);