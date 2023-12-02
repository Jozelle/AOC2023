string[] numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", };
string[] numbers2 = { "one1one", "two2two", "three3three", "four4four", "five5five", "six6six", "seven7seven", "eight8eight", "nine9nine" };

string filepath = "input.txt";
StreamReader sr = new StreamReader(filepath);

int sum = 0;

while (!sr.EndOfStream)
{
    string line = sr.ReadLine();

    for (int i = 0; i < numbers.Length; i++)
    {
        line = line.Replace(numbers[i], numbers2[i]);
    }

    char[] lineArray = line.ToCharArray();
    string first = "";
    string last = "";

    foreach (char c in lineArray)
    {
        if (Char.IsDigit(c))
        {
            first = c.ToString();
            break;
        }
    }

    char[] lineArrayBackwards = lineArray.Reverse().ToArray();

    foreach (char c in lineArrayBackwards)
    {
        if (Char.IsDigit(c))
        {
            last = c.ToString();
            break;
        }
    }

    string total = string.Concat(first, last);
    int rowResult = int.Parse(total);
    sum += rowResult;
}

Console.WriteLine(sum);