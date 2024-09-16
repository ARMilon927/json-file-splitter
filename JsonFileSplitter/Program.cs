// Path to the input JSON file
using Newtonsoft.Json;
using System.Xml;

string inputFilePath = @"C:\pathfrom\fileName.json";

// Path to the folder where split JSON files will be saved
string outputFolderPath = @"C:\pathto\Output";

// Read the JSON file content
string jsonContent = File.ReadAllText(inputFilePath);

try
{
    // Deserialize JSON content into a list of objects
    var dataList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonContent);

    // Ensure the output folder exists
    if (!Directory.Exists(outputFolderPath))
    {
        Directory.CreateDirectory(outputFolderPath);
    }

    // Loop through each object in the list and save it as a separate JSON file
    for (int i = 0; i < dataList.Count; i++)
    {
        // Convert the object back to JSON format
        string splitJson = JsonConvert.SerializeObject(dataList[i], Newtonsoft.Json.Formatting.Indented);

        // Create a unique file name for each split JSON file
        string outputFilePath = Path.Combine(outputFolderPath, $"data_{i + 1}.json");

        // Write the JSON content to the file
        File.WriteAllText(outputFilePath, splitJson);
    }

    Console.WriteLine("JSON files split and saved successfully!");
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}
