using Day4;
using Day4.Part1;

var file = "puzzleInput.txt";

if (!File.Exists(file)) {
    Console.Error.WriteLine($"File not found: {file}");
    return;
}

var puzzleInput = File.ReadAllLines(file);
var puzzleInputAs2DArray = TwoDArrayConverter.ConvertTo2DArray(puzzleInput);
var maxAdjacentPaperRollsExclusive = 4;
var numberOfRollsThatCanBeReachedInPart1 = new NumberOfPaperRollLocationsPart1Calculator(maxAdjacentPaperRollsExclusive).Calculate(puzzleInputAs2DArray);
var numberOfRollsThatCanBeReachedInPart2 = new Day4.Part2.NumberOfPaperRollLocationsPart2Calculator(maxAdjacentPaperRollsExclusive).Calculate(puzzleInputAs2DArray);
Console.WriteLine($"Number of rolls that can be reached in Part 1: {numberOfRollsThatCanBeReachedInPart1}");
Console.WriteLine($"Number of rolls that can be reached in Part 2: {numberOfRollsThatCanBeReachedInPart2}");