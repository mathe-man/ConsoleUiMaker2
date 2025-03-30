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
        //DebugCharacters();
        
        
        DebugUi();
        Console.Read();
    }


    public static void DebugUi()
    {
        Text myFirstText = new Text(["One line"], 4, 2);
        Text mySecondText = new Text(["Two", "lines", "and more"], 2, 4, borderType:"round");

        myFirstText.Length = 30;
        
        myFirstText.ClickActions.Add(() => { myFirstText.Content = ["A été clické"];  myFirstText.Render();});
        
        
        ConsoleUi.RunUi();
    }

    public static void DebugCharacters()
    {
        Console.WriteLine("Box characters: ");
        foreach (BoxCharacters character in Enum.GetValues(typeof(BoxCharacters)))
        {
            Console.WriteLine($"{character}: {(char)character}");
        }
        
        Console.WriteLine("Round characters: ");
        foreach (RoundCharacters character in Enum.GetValues(typeof(RoundCharacters)))
        {
            Console.WriteLine($"{character}: {(char)character}");
        }
    }
}