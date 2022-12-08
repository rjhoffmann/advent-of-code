var input = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
var data = File.ReadLines(input).ToList();

var buckets = data
    .Take(9)
    .Reverse()
    .First()
    .Select((c, i) => new { c, i })
    .Where(d => char.IsDigit(d.c))
    .Select(d => new
    {
        number = int.Parse(d.c.ToString()),
        stack = data
            .Take(9)
            .Reverse()
            .Skip(1)
            .Aggregate(new Stack<char>(), (chars, s) =>
            {
                if (char.IsLetter(s[d.i])) chars.Push(s[d.i]);
                return chars;
            }),
    })
    .ToList();

Console.WriteLine("Initial Buckets");
Console.WriteLine("---------------");
foreach (var bucket in buckets)
{
    Console.WriteLine($"Bucket {bucket.number}: {string.Concat(bucket.stack)}");
}
Console.WriteLine("---------------");
Console.WriteLine();

var moves = data
    .Skip(10)
    .Select(l => new
    {
        move = int.Parse(l.Split(' ')[1]),
        from = int.Parse(l.Split(' ')[3]),
        to = int.Parse(l.Split(' ')[5]),
    })
    .ToList();

foreach (var move in moves)
{
    var fromBucket = buckets.ElementAt(move.from - 1);
    var toBucket = buckets.ElementAt(move.to - 1);
    
    Console.WriteLine($"Moving {move.move} items from bucket {fromBucket.number} to bucket {toBucket.number}");
    
    fromBucket.stack
        .Take(move.move)
        .Reverse()
        .ToList()
        .ForEach(c =>
        {
            var popped = fromBucket.stack.Pop();
            Console.WriteLine($"Popped: {popped}, Pushed: {c}");
            toBucket.stack.Push(c);
        });
    
    Console.WriteLine("---------------");
    foreach (var bucket in buckets)
    {
        Console.WriteLine($"Bucket {bucket.number}: {string.Concat(bucket.stack)}");
    }
    Console.WriteLine("---------------");
    Console.WriteLine();
}

var result = string.Concat(buckets.Select(b => b.stack.First()));

Console.WriteLine(result);



// var part1Buckets = buckets.ToList();
// foreach (var move in moves)
// {
//     var fromBucket = part1Buckets.ElementAt(move.from - 1);
//     var toBucket = part1Buckets.ElementAt(move.to - 1);
//     
//     fromBucket.stack
//         .Take(move.move)
//         .ToList()
//         .ForEach(c =>
//         {
//             fromBucket.stack.Pop();
//             toBucket.stack.Push(c);
//         });
// }
//
// Console.WriteLine(string.Concat(part1Buckets
//     .Select(bucket => bucket.stack.First())));
//
// var part2Buckets = buckets.ToList();
// foreach (var bucket in part2Buckets)
// {
//     Console.WriteLine($"Bucket {bucket.number}: {string.Concat(bucket.stack)}");
// }
// foreach (var move in moves)
// {
//     var fromBucket = part2Buckets.ElementAt(move.from - 1);
//     var toBucket = part2Buckets.ElementAt(move.to - 1);
//
//     Console.Write($"Moving {move.move} items from bucket {fromBucket.number} to {toBucket.number}: ");
//
//     var take = fromBucket.stack.Reverse().Take(move.move).Reverse().ToList();
//     Console.WriteLine(string.Concat(take));
//     foreach (var c in take)
//     {
//         fromBucket.stack.Pop();
//         toBucket.stack.Push(c);
//     }
//     
//     Console.WriteLine();
//
//     // fromBucket.stack
//     //     .Take(move.move)
//     //     .Reverse()
//     //     .ToList()
//     //     .ForEach(c =>
//     //     {
//     //         fromBucket.stack.Pop();
//     //         toBucket.stack.Push(c);
//     //     });
// }
//
// Console.WriteLine(string.Concat(part2Buckets
//     .Select(bucket => bucket.stack.First())));