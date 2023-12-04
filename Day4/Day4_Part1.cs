string filename = "input.txt";
StreamReader sr = new StreamReader(filename);

double sum = 0;

while (!sr.EndOfStream)
{
    string line = sr.ReadLine();
    
    int countMatchingNumbers = 0;   

    string[] splitCard = SplitCard(line);
    List<int> listWinningNumbers = SplitNumbers(splitCard[0]);
    List<int> listMyNumbers = SplitNumbers(splitCard[1]);

    foreach (int number in listWinningNumbers)
    {
        foreach (int number2 in listMyNumbers)
        {
            if (number == number2)
            {
                countMatchingNumbers++;
            }
        }
    }

    sum += CalculatePoints(countMatchingNumbers);
}

Console.WriteLine(sum);


string[] SplitCard(string line)
{
    string[] removeCardTag = line.Split(":");

    string[] dividedCard = removeCardTag[1].Split("|");
    return dividedCard;
}

List<int> SplitNumbers(string line)
{
    string[] numbersTemp = line.Split(" ");
    List<int> numbers = new List<int>();

    foreach (string word in numbersTemp)
    {
        if (int.TryParse(word, out int number))
        {
            numbers.Add(number);
        }
       
    }

    return numbers;
}

double CalculatePoints(int matches)
{
    if (matches == 0) //Catch if there is no matching numbers
    {
        return 0;
    }
    
    double points = Math.Pow(2, (matches - 1));
    return points;
}