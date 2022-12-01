fun main() {
    fun List<String>.groupCount(index: Int): Map<Char, Int> = this
        .map { it.toCharArray() }
        .groupingBy { it[index] }
        .eachCount()

    fun IntRange.getMaxByInput(input: List<String>): Int = this
        .mapIndexed { i, _ -> input.groupCount(i).maxByOrNull { it.value }?.key }
        .joinToString("")
        .toInt(2)

    fun IntRange.getMinByInput(input: List<String>): Int = this
        .mapIndexed { i, _ -> input.groupCount(i).minByOrNull { it.value }?.key }
        .joinToString("")
        .toInt()

    fun part1(input: List<String>): Int {
        val bits = 0 until input.first().length
        val gamma = bits.getMaxByInput(input)
        val epsilon = bits.getMinByInput(input)

        return epsilon * gamma
    }

    fun part2(input: List<String>): Int = input.size

    val testInput = readInput("Day03_test")
    check(part1(testInput) == 198)

    val input = readInput("Day03")

    println("Part 1: ${part1(input)}")
    println("Part 2: ${part2(input)}")
}