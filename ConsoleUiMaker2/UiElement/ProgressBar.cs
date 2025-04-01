using ConsoleUiMaker2.Characters;

namespace ConsoleUiMaker2.UiElement;

public class ProgressBar : IUiElement
{
    
    public int X { get; set; }
    public int Y { get; set; }
    
    public List<Action> ClickActions { get; set; }
    

    public int Length;
    public int TotalSteps;
    public int  Steps;
    public char Character;

    public ProgressBar(int x, int y, int length, int totalSteps, List<Action>? clickActions = null, char ? character = null)
    {
        X = x;
        Y = y;
        
        Length = length;
        TotalSteps = totalSteps;

        ClickActions = clickActions ?? new List<Action>();
        Character = character ?? (char)BoxCharacters.FilledSquare;
    }

    public bool Progress(int amount = 1)
    {
        Steps += amount;
        if (Steps >= TotalSteps)
        {
            Steps = TotalSteps;
            return true;
        }

        return false;
    }
    
    public void HandleKey(ConsoleKeyInfo keyInfo)
    {
    }

    public void Click()
    {
        foreach (var action in ClickActions) action();
    }


    public void Render()
    {
        Console.SetCursorPosition(X, Y);
        for (int i = 0; i < CalculateProgressCharNumber(); i++) Console.Write(Character);
        
        Console.SetCursorPosition(X, Y);
        Console.Write("-");
    }
    public void FocusOn()
    {}
    public void FocusOff()
    {}

    private int CalculateProgressCharNumber()
    {
        float normalized = Steps / (float)TotalSteps;
        int characters_number = (int)Math.Ceiling(normalized * Length);
        
        return characters_number;
    }
}