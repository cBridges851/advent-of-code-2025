using Day5;

var file = "puzzleInput.txt";

if (!File.Exists(file)) {
    Console.Error.WriteLine($"File not found: {file}");
    return;
}

var puzzleInput = File.ReadAllText(file);
var (freshIngredients, requestedIngredients) = new PuzzleInputParser().Parse(puzzleInput);
var numberOfFreshIngredientsCalculator = new NumberOfFreshIngredientsCalculator(freshIngredients);
var numberOfFreshIngredients = numberOfFreshIngredientsCalculator.CalculateNumberOfRequestedIngredientsThatAreFresh(requestedIngredients);
var totalNumberOfFreshIngredients = numberOfFreshIngredientsCalculator.TotalNumberOfFreshIngredientsInInventory();
Console.WriteLine($"Number of fresh ingredients: {numberOfFreshIngredients}");
Console.WriteLine($"Total number of fresh ingredients in inventory: {totalNumberOfFreshIngredients}");