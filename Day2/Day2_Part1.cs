//Part 1
StreamReader sr = new StreamReader("input.txt");
int maxRed = 12;
int maxGreen = 13;
int maxBlue = 14;

int sum = 0;

while (!sr.EndOfStream)
{
    string line = sr.ReadLine();

    string[] firstSplit = line.Split(": ");

    int gameNr = int.Parse(firstSplit[0].Split(' ')[1]);

    string[] secondSplit = firstSplit[1].Split("; ");

    bool impossible = false;

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
                    impossible = true;
                }
            }
            else if (s2.Contains("green"))
            {
                int sumGreen = int.Parse(s2.Split(' ')[0]);

                if (sumGreen > maxGreen)
                {
                    impossible = true;
                }
            }
            else if (s2.Contains("blue"))
            {
                int sumBlue = int.Parse(s2.Split(' ')[0]);

                if (sumBlue > maxBlue)
                {
                    impossible = true;
                }
            }
        }
    }

    if (impossible == false)
    {
        sum += gameNr;
    }
}

Console.WriteLine(sum);






