using Day2.Part2;

var file = "puzzleInput.txt";

if (!File.Exists(file)) {
    Console.Error.WriteLine($"File not found: {file}");
    return;
}

var puzzleInput = File.ReadAllLines(file);

var parsedPuzzleInput = new PuzzleInputParser().Parse(puzzleInput[0]); // Input is all on one line
var invalidIds = new InvalidIdFinder().GetInvalidIdsForRange(parsedPuzzleInput);
var result = new SumOfInvalidProductIdFinder().Calculate(invalidIds);
Console.WriteLine($"Sum of invalid id values: {result}");