
using ConsoleUiMaker2;
using ConsoleUiMaker2.Characters;
using ConsoleUiMaker2.UiElement;

namespace Debug;
public static class Program
{
    public static void Main(string[] args)
    {
        //DebugCharacters();
        //DebugText();
        //DebugProgressBar();
        DebugCursor();
        
        
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

    public static void DebugProgressBar()
    {
        ProgressBar myFirstBar = new(2, 3, 10, 5);
        myFirstBar.ClickActions.Add(() => { myFirstBar.Progress(); });
        
        ProgressBar mySecondBar = new(2, 5, 15, 25);
        mySecondBar.ClickActions.Add(() => { mySecondBar.Progress(); });
        
        
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

    public static void DebugCursor()
    {
        Text myFirstText = new Text(["A text"], 4, 2, alwayShowBorder:true, borderType:"round");
        myFirstText.ClickActions.Add(() =>
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("A");
        });
        myFirstText.FocusOnColors = (ConsoleColor.Yellow, ConsoleColor.Black);
        
        
        
        Text mySecondText = new Text(["B text"], 4, 6, alwayShowBorder:true, borderType:"round");
        mySecondText.ClickActions.Add(() =>
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("B");
        });
        mySecondText.FocusOnColors = (ConsoleColor.Blue, ConsoleColor.Black);


        Text myThirdText = new Text(["Just a label"], 15, 2, alwayShowBorder: true, borderType: "round");
        myThirdText.FocusOnColors = (ConsoleColor.Magenta, ConsoleColor.Black);
        
        ConsoleUi.RunUi();
    }
}