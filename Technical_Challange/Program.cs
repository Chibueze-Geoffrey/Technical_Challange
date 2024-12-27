using System;
using System.IO;
using System.Collections.Generic;


        Console.WriteLine("Running Challenge 1: File Scanner");
        FileScanner.SearchFiles("C:\\TestFolder", "sample");

        Console.WriteLine("\nRunning Challenge 2: Duplicate Identifier");
        var collectionA = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        var collectionS = new List<int> { 5, 15, 3, 19, 35, 50, -1, 0 };
        DuplicateIdentifier<int>.IdentifyDuplicates(collectionA, collectionS);
   
public class FileScanner
{
    public static void SearchFiles(string folderPath, string searchString)
    {
        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine("Folder does not exist.");
            return;
        }

        var files = Directory.GetFiles(folderPath);
        foreach (var file in files)
        {
            string fileName = Path.GetFileName(file);
            string content = File.ReadAllText(file);

            if (content.Contains(searchString))
            {
                Console.WriteLine($"Present: {fileName}");
            }
            else
            {
                Console.WriteLine($"Absent: {fileName}");
            }
        }
    }
}

public class DuplicateIdentifier<T> where T : IEquatable<T>
{
    public static void IdentifyDuplicates(List<T> collectionA, List<T> collectionS)
    {
        var results = new Dictionary<T, bool>();

        foreach (var item in collectionS)
        {
            results[item] = collectionA.Contains(item);
        }

        foreach (var result in results)
        {
            Console.WriteLine($"{result.Key}:{result.Value.ToString().ToLower()}");
        }
    }
}
