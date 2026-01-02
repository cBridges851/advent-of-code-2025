using Day5;

var file = "puzzleInput.txt";

if (!File.Exists(file)) {
    Console.Error.WriteLine($"File not found: {file}");
    return;
}

var puzzleInput = File.ReadAllText(file);
var (freshIngredients, requestedIngredients) = new PuzzleInputParser().Parse(puzzleInput);
var numberOfFreshIngredients = new NumberOfFreshIngredientsCalculator(freshIngredients).Calculate(requestedIngredients);
Console.WriteLine($"Number of fresh ingredients: {numberOfFreshIngredients}");