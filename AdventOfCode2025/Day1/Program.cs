using Day1;

var file = "puzzleInput.txt";
var puzzleInput = File.ReadAllLines(file);

var result = new RotationsCalculator().CalculateNumberOfTimesZeroWasHit(puzzleInput);
Console.WriteLine(result);