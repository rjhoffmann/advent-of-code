var input = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
var data = File.ReadLines(input).ToList();

var part1 = data
    .Select(d => new
    {
        x = d[..(d.Length / 2)],
        y = d[(d.Length / 2)..],
    })
    .Select(d => d.x.Intersect(d.y).Single())
    .Sum(x => char.IsLower(x) ? x - 96 : x - 38);

Console.WriteLine(part1);