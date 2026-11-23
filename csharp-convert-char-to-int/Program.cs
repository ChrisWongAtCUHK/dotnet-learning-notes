var a = '1';

int i = (int)a;
Console.WriteLine(i);

i = Convert.ToInt32(a);
Console.WriteLine(i);

i = int.Parse(a.ToString());
Console.WriteLine(i);

i = (int)Char.GetNumericValue(a);
Console.WriteLine(i);

i = (a - '0');
Console.WriteLine(i);