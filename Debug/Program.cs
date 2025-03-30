using System;
using System.Data;
using ConsoleUiMaker2;
using ConsoleUiMaker2.Characters;
using ConsoleUiMaker2.UiElement;

namespace Debug;
public static class Program
{
    public static void Main(string[] args)
    {
        DebugCharacters();
    }


    public static void DebugUi()
    {
        Text myFirstText = new Text(["One line"], 4, 2);
        Text mySecondText = new Text(["Two", "lines"], 1, 4);

        myFirstText.Length = 30;
        ConsoleUi.RunUi();
    }

    public static void DebugCharacters()
    {
        Console.WriteLine("Box characters: " + (char)BoxCharacters.TopLeftCorner);
        foreach (var character in Enum.GetValues(typeof(BoxCharacters)))
        {
            Console.WriteLine($"{character}: {(char)character}");
        }
        
        Console.WriteLine("Round characters: ");
        foreach (var character in Enum.GetValues(typeof(RoundCharacters)))
        {
            Console.Write(character);
        }
    }
}