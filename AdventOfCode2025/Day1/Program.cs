using Day1;

var file = "puzzleInput.txt";

if (!File.Exists(file)) { 
    Console.Error.WriteLine($"File not found: {file}");
    return;
}

var puzzleInput = File.ReadAllLines(file);

var result = new RotationsCalculator().CalculateNumberOfTimesZeroWasHit(puzzleInput);
Console.WriteLine(result);