using Day4;

var file = "puzzleInput.txt";

if (!File.Exists(file)) {
    Console.Error.WriteLine($"File not found: {file}");
    return;
}

var puzzleInput = File.ReadAllLines(file);
var puzzleInputAs2DArray = TwoDArrayConverter.ConvertTo2DArray(puzzleInput);
var maxAdjacentPaperRollsExclusive = 4;
var numberOfRollsThatCanBeReached = new NumberOfPaperRollLocationsCalculator(maxAdjacentPaperRollsExclusive).Calculate(puzzleInputAs2DArray);
Console.WriteLine($"Number of rolls that can be reached: {numberOfRollsThatCanBeReached}");