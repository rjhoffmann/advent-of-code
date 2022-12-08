var input = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
var data = File.ReadLines(input).ToList();

var pairs = data
    .Select(d => new
    {
        e1 = d.Split(',')[0],
        e2 = d.Split(',')[1],
    })
    .Select(d => new
    {
        d.e1,
        e1Min = int.Parse(d.e1.Split('-')[0]),
        e1Max = int.Parse(d.e1.Split('-')[1]),
        d.e2,
        e2Min = int.Parse(d.e2.Split('-')[0]),
        e2Max = int.Parse(d.e2.Split('-')[1]),
    });
    
var part1 = pairs.Count(p => 
    (p.e1Min <= p.e2Min && p.e1Max >= p.e2Max)
        || (p.e2Min <= p.e1Min && p.e2Max >= p.e1Max));

var part2 = pairs.Count(p =>
    (p.e1Min <= p.e2Max && p.e1Max >= p.e2Min)
    || (p.e2Min <= p.e1Max && p.e2Max >= p.e1Min));
        
Console.WriteLine(part1);
Console.WriteLine(part2);