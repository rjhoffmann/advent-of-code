fun main() {
    fun count(numbers: List<Int>) = numbers.zipWithNext().count { (x, y) -> y > x }
    fun part1(input: List<String>) = count(input.map(String::toInt))
    fun part2(input: List<String>) = count(input.map(String::toInt).windowed(3) { it.sum() })

    // test if implementation meets criteria from the description, like:
    val testInput = readInput("Day01_test")
    check(part1(testInput) == 7)

    val input = readInput("Day01")
    println("Part 1: ${part1(input)}")
    println("Part 2: ${part2(input)}")
}
