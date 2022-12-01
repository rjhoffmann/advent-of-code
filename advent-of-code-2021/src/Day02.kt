enum class Direction { UP, DOWN, FORWARD }
class Movement(val direction: Direction, val units: Int)

fun main() {
    fun List<String>.toMovement(): List<Movement> {
        return this.map { x ->
            val (a, b) = x.split(" ")
            val direction = when(a) {
                "up" -> Direction.UP
                "down" -> Direction.DOWN
                "forward" -> Direction.FORWARD
                else -> throw IllegalArgumentException("Invalid Direction")
            }

            Movement(direction, b.toInt())
        }
    }

    fun part1(input: List<String>): Int {
        val (position, depth) = input.toMovement().fold(Pair(0,0)) { acc, movement ->
            when(movement.direction) {
                Direction.UP -> Pair(acc.first, acc.second - movement.units)
                Direction.DOWN -> Pair(acc.first, acc.second + movement.units)
                Direction.FORWARD -> Pair(acc.first + movement.units, acc.second)
            }
        }

        return depth * position
    }

    fun part2(input: List<String>): Int {
        val (aim, position, depth) = input.toMovement().fold(Triple(0, 0, 0)) { acc, movement ->
            when(movement.direction) {
                Direction.UP -> Triple(acc.first - movement.units, acc.second, acc.third)
                Direction.DOWN -> Triple(acc.first + movement.units, acc.second, acc.third)
                Direction.FORWARD -> Triple(acc.first, acc.second + movement.units, acc.third + (acc.first * movement.units))
            }
        }

        return depth * position
    }

    val testInput = readInput("Day02_test")
    check(part1(testInput) == 150)

    val input = readInput("Day02")

    println("Part 1: ${part1(input)}")
    println("Part 2: ${part2(input)}")
}