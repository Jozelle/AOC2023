//Part 2
StreamReader sr = new StreamReader("input.txt");

int sum = 0;

while (!sr.EndOfStream)
{
    int maxRed = 0;
    int maxGreen = 0;
    int maxBlue = 0;

    string line = sr.ReadLine();

    string[] firstSplit = line.Split(": ");

    int gameNr = int.Parse(firstSplit[0].Split(' ')[1]);

    string[] secondSplit = firstSplit[1].Split("; ");

    foreach (string s in secondSplit)
    {
        string[] thirdSplit = s.Split(", ");

        foreach (string s2 in thirdSplit)
        {
            if (s2.Contains("red"))
            {
                int sumRed = int.Parse(s2.Split(' ')[0]);

                if (sumRed > maxRed)
                {
                    maxRed = sumRed;
                }
            }
            else if (s2.Contains("green"))
            {
                int sumGreen = int.Parse(s2.Split(' ')[0]);

                if (sumGreen > maxGreen)
                {
                    maxGreen = sumGreen;
                }
            }
            else if (s2.Contains("blue"))
            {
                int sumBlue = int.Parse(s2.Split(' ')[0]);

                if (sumBlue > maxBlue)
                {
                    maxBlue = sumBlue;
                }
            }
        }
    }

    int total = maxRed * maxGreen * maxBlue;
    sum += total;
}

Console.WriteLine(sum);