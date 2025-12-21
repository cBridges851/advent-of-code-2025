using Day3;

var file = "puzzleInput.txt";

if (!File.Exists(file)) {
    Console.Error.WriteLine($"File not found: {file}");
    return;
}

var puzzleInput = File.ReadAllLines(file);

var result = JoltageCalculator.CalculateAllPacks(puzzleInput);
Console.WriteLine($"Largest possible joltage: {result}");