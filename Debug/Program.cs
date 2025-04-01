
using ConsoleUiMaker2;
using ConsoleUiMaker2.Characters;
using ConsoleUiMaker2.UiElement;

namespace Debug;
public static class Program
{
    public static void Main(string[] args)
    {
        //DebugCharacters();
        
        
        DebugText();
        Console.Read();
    }


    public static void DebugText()
    {
        Text myFirstText = new Text(["One line"], 4, 2);
        Text mySecondText = new Text(["Two", "lines", "and more"], 2, 5, borderType:"round");

        myFirstText.Length = 30;
        
        myFirstText.ClickActions.Add(() =>
        {
            myFirstText.PermanentBorder = !myFirstText.PermanentBorder;
            if (myFirstText.PermanentBorder) myFirstText.Content = ["Border is permanent"];
            else myFirstText.Content = ["Border isn't permanent       "];
            myFirstText.Render();
        });
        
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