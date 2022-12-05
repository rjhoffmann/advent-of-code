// See https://aka.ms/new-console-template for more information

var input = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
var data = File.ReadLines(input).ToList();

var part1 = data
    .Select(d => d switch
    {
        // A|X = Rock = 1
        // B|Y = Paper = 2
        // C|Z = Scissors = 3
        // Loss = 0; Draw = 3; Win = 6

        "A X" => 4, "A Y" => 8, "A Z" => 3,
        "B X" => 1, "B Y" => 5, "B Z" => 9,
        "C X" => 7, "C Y" => 2, "C Z" => 6,
        _ => throw new Exception("Kablooie")
    })
    .Sum();

var part2 = data
    .Select(d => d switch
    {
        "A X" => 3, "A Y" => 4, "A Z" => 8,
        "B X" => 1, "B Y" => 5, "B Z" => 9,
        "C X" => 2, "C Y" => 6, "C Z" => 7,
        _ => throw new Exception("Kablooie")
    })
    .Sum();

Console.WriteLine(part1);
Console.WriteLine(part2);