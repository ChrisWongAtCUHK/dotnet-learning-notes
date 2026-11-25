var array = new int[] { 1, 2, 3, 4, 5 };
var slice1 = array[2..]; // From index 2 to the end
Console.WriteLine(string.Join(", ", slice1));
var slice2 = array[..2]; // From the start to index 1
Console.WriteLine(string.Join(", ", slice2));
var slice3 = array[1..3]; // From the index 1 to index 2
Console.WriteLine(string.Join(", ", slice3));
var slice4 = array[..]; // The whole array
Console.WriteLine(string.Join(", ", slice4));
try
{
  var slice5 = array[3..1]; // Throws ArgumentOutOfRangeException
  Console.WriteLine(string.Join(", ", slice5));
}
catch (ArgumentOutOfRangeException ex)
{
  Console.WriteLine($"Error: {ex.Message}");
}