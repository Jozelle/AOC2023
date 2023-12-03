List<char[]> engineSchematic = ReadFromFile();

int sumParts = 0;

for (int i = 0; i < engineSchematic.Count; i++)
{
    for (int j = 0; j < engineSchematic[i].Length; j++)
    {
        if (char.IsDigit(engineSchematic[i][j]) && CheckAdjacentChars(engineSchematic, i, j))
        {
            int result = LocateNumber(engineSchematic, i, j);
            sumParts += result;
        }
    }
}
Console.WriteLine(sumParts);

List<char[]> ReadFromFile()
{
    string filename = "input.txt";
    StreamReader sr = new StreamReader(filename);

    List<char[]> engineSchematic = new List<char[]>();

    while (!sr.EndOfStream)
    {
        string lineFromFile = sr.ReadLine();
        char[] lineFromFileAsArray = lineFromFile.ToCharArray();

        engineSchematic.Add(lineFromFileAsArray);
    }

    sr.Close();

    return engineSchematic;
}

bool CheckIfSymbol(char c)
{
    return !char.IsDigit(c) && c != '.';
}
bool CheckAdjacentChars(List<char[]> engineSchematic, int y, int x) //x = horizontal, y = vertical
{
    bool symbolFound = false;

    //Check row over.
    if (y > 0)
    {
        if (x > 0 && CheckIfSymbol(engineSchematic[y - 1][x - 1]))
        {
            symbolFound = true;
        }
        else if (CheckIfSymbol(engineSchematic[y - 1][x]))
        {
            symbolFound = true;
        }
        else if ((x < engineSchematic[y].Length - 2) && (CheckIfSymbol(engineSchematic[y - 1][x + 1])))
        {
            symbolFound = true;
        }
    }

    //Check before on same row.
    if (x > 0)
    {
        if (CheckIfSymbol(engineSchematic[y][x - 1]))
        {
            symbolFound = true;
        }
    }

    //Check after on same row
    if (x < engineSchematic[y].Length - 2)
    {
        if (CheckIfSymbol(engineSchematic[y][x + 1]))
        {
            symbolFound = true;
        }
    }

    //Check row below
    if (y < engineSchematic.Count - 2)
    {
        if (x > 0 && (CheckIfSymbol(engineSchematic[y + 1][x - 1])))
        {
            symbolFound = true;
        }
        else if (CheckIfSymbol(engineSchematic[y + 1][x]))
        {
            symbolFound = true;
        }
        else if ((x < engineSchematic[y + 1].Length - 2) && (CheckIfSymbol(engineSchematic[y + 1][x + 1])))
        {
            symbolFound = true;
        }
    }

    return symbolFound; //true if a symbol was found adjacent
}

int LocateNumber(List<char[]> engineSchematic, int y, int x)
{
    int start = x;
    int end = x;

    //Check to find the first digit in the number
    while (true)
    {
        if (start > 0)
        {
            if (char.IsDigit(engineSchematic[y][start - 1]))
            {
                start--;
            }
            else if (engineSchematic[y][start - 1] == '.' || CheckIfSymbol(engineSchematic[y][start - 1]))
            {
                break;
            }
        }
        else 
        { 
            break; 
        }
    }

    //Check to find the last digit in the number
    while (true)
    {
        if (end < engineSchematic[y].Length - 1)
        {
            if (char.IsDigit(engineSchematic[y][end + 1]))
            {
                end++;
            }
            else if (engineSchematic[y][end + 1] == '.' || CheckIfSymbol(engineSchematic[y][end + 1]))
            {
                break;
            }
        }
        else
        {
            break;
        }
    }

    string result = "";

    //Iterate from first digit to last
    for (int i = start; i <= end; i++)
    {
        //Save the digit to result
        result += engineSchematic[y][i];

        //Replace the found numbers with dots to remove duplicates.
        engineSchematic[y][i] = '.';
    }

    return int.Parse(result);
}