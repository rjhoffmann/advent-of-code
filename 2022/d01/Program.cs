using MoreLinq;

var input = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
var data = File.ReadLines(input)
    .Split(x => x == "", y => y.Sum(int.Parse))
    .ToArray();

var part1 = data.Max();
var part2 = data.OrderByDescending(d => d).Take(3).Sum();

Console.WriteLine(part1);
Console.WriteLine(part2);