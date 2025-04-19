string inputFilePath = "C:\\Users\\ser20\\RiderProjects\\Lab2\\Lab2\\numbers.txt";
CreateInputFile(inputFilePath);
string outputFilePath = "C:\\Users\\ser20\\RiderProjects\\Lab2\\Lab2\\output1.txt";
ProcessFile(inputFilePath, outputFilePath);
static void CreateInputFile(string filePath)    
{
    Random random = new Random();
    using (StreamWriter writer = new StreamWriter(filePath))
    {
        for (int i = 0; i < 20; i++)
        {
            int number = random.Next(-100, 101);
            writer.WriteLine(number);
        }
    }
}

static void ProcessFile(string inputPath, string outputPath)
{
    int[] numbers = File.ReadAllLines(inputPath).Select(int.Parse).ToArray();
    int firstNegative = numbers.FirstOrDefault(n => n < 0);

    using (StreamWriter writer = new StreamWriter(outputPath))
    {
        foreach (int number in numbers)
        {
            if (number % 2 == 0)
            {
                int result = number * firstNegative;
                writer.WriteLine(result);
            }
            else
            {
                writer.WriteLine(number);
            }
        }
    }
}