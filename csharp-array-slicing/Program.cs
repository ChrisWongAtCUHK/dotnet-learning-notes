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

var posts = new string[] { "post1", "post2", "post3", "post4", "post5", "post6", "post7", "post8",
    "post9", "post10" };
var slicedPosts = posts.Skip(0).Take(5);
foreach (var post in slicedPosts)
  Console.WriteLine(post); // Outputs the first 5 posts

var copiedPosts = new string[5];
Array.Copy(posts, 0, copiedPosts, 0, 5);
foreach (var post in copiedPosts)
  Console.WriteLine(post); // Outputs the first 5 posts

var data = new Tuple<int, bool>[] {
    new(20, true),
    new(50, true),
    new(35, false),
    new(55, true),
    new(16, false)
};

var trainingData = new ArraySegment<Tuple<int, bool>>(data, 0, 3);
var testingData = new ArraySegment<Tuple<int, bool>>(data, 3, 2);

Console.WriteLine("Training Data:");
foreach (var record in trainingData)
  Console.WriteLine(record);

Console.WriteLine();
Console.WriteLine("Testing Data:");
foreach (var record in testingData)
  Console.WriteLine(record);

/** The same thing can be achieved using the ArraySegment<T>.Slice() method:
 * ...
 * var arraySegment = new ArraySegment<Tuple<int, bool>>(data);
 * var trainingData = arraySegment.Slice(0, 3);
 * var testingData = arraySegment.Slice(3, 2);
 * ...
 */