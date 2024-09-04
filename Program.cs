using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static string[] lines;

    static void Main()
    {
        string filePath = "input.csv";
        lines = File.ReadAllLines(filePath);

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Display Characters");
            Console.WriteLine("2. Add Character");
            Console.WriteLine("3. Level Up Character");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayAllCharacters(lines);
                    break;
                case "2":
                    AddCharacter(ref lines);
                    break;
                case "3":
                    LevelUpCharacter(lines);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void DisplayAllCharacters(string[] lines)
    {
        // Skip the header row
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            string name;
            int commaIndex;

            // Check if the name is quoted
            if (line.StartsWith("\""))
            {
                // TODO: Find the closing quote and the comma right after it
                
                commaIndex = line.IndexOf(',');
                name = line.Substring(0, commaIndex);
                int pos = name.Length + 1;

                var line2 = line.Substring(pos);

                int commaIndex2 = line2.IndexOf(',');

                int nameEndsIndex = pos + commaIndex2;

                // TODO: Remove quotes from the name if present and parse the name
                // name = ...
                name = line.Substring(0,nameEndsIndex);
                line = line.Substring(nameEndsIndex);
                name = name.Replace("\"","");
            }
            else
            {
                // TODO: Name is not quoted, so store the name up to the first comma
                commaIndex = line.IndexOf(',');
                name = line.Substring(0,commaIndex);
                line = line.Substring(commaIndex);
            }

            // TODO: Parse characterClass, level, hitPoints, and equipment

            string[] otherFields = line.Split(','); 
               
            var heroClass = otherFields[1];
            var heroLevel = otherFields[2];
            var hitPoints = otherFields[3];
            
            // TODO: Parse equipment noting that it contains multiple items separated by '|'
            var heroEquipmentString = otherFields[4];                
            string[] heroEquipmentArray = heroEquipmentString.Split('|');

            // Display character information
            Console.WriteLine($"Name: {name}; Class: {heroClass}; Level: {heroLevel}; HP: {hitPoints}; Equipment: {string.Join(", ", heroEquipmentArray)}");
        }
    }

    static void AddCharacter(ref string[] lines)
    {
        // TODO: Implement logic to add a new character
        // Prompt for character details (name, class, level, hit points, equipment)
        // DO NOT just ask the user to enter a new line of CSV data or enter the pipe-separated equipment string
        // Append the new character to the lines array
    }

    static void LevelUpCharacter(string[] lines)
    {
        Console.Write("Enter the name of the character to level up: ");
        string nameToLevelUp = Console.ReadLine();

        // Loop through characters to find the one to level up
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            // TODO: Check if the name matches the one to level up
            // Do not worry about case sensitivity at this point
            if (line.Contains(nameToLevelUp))
            {

                // TODO: Split the rest of the fields locating the level field
                // string[] fields = ...
                // int level = ...

                // TODO: Level up the character
                // level++;
                // Console.WriteLine($"Character {name} leveled up to level {level}!");

                // TODO: Update the line with the new level
                // lines[i] = ...
                break;
            }
        }
    }
}