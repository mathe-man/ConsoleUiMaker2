
using ConsoleUiMaker2.Characters;

namespace ConsoleUiMaker2.UiElement;

public class Text : IUiElement
{
    public int X {get; set;}
    public int Y {get; set;}
    
    public List<Action> ClickActions {get; set;}


    private List<string> _content;
    public List<string> Content
    {
        get { return _content;}
        set
        {
            _content = value;
            foreach (var line in value)
            {
                if (line.Length >Length) Length = line.Length;
            }
        }
    }

    public int Length;

    public Dictionary<string , char> Borders = new ();
    
    
    public Text(List<string> content, int x, int y, List<Action>? clickActions = null, string borderType = "box")
    {
        X = x;
        Y = y;
        Content = content;
        ClickActions = clickActions == null ? new List<Action>() : clickActions;
        SetBorders(borderType);
        
        ConsoleUi.UiElementList.Add(this);
    }
    
    public void SetBorders(string type)
    {
        if (type == "box")
        {
            Borders["Horizontal"] = (char)BoxCharacters.Horizontal;
            Borders["Vertical"] = (char)BoxCharacters.Vertical;
            Borders["TopLeftCorner"] = (char)BoxCharacters.TopLeftCorner;
            Borders["TopRightCorner"] = (char)BoxCharacters.TopRightCorner;
            Borders["BottomLeftCorner"] = (char)BoxCharacters.BottomLeftCorner;
            Borders["BottomRightCorner"] = (char)BoxCharacters.BottomRightCorner;
        }
        else if (type == "round")
        {
            Borders["Horizontal"] = (char)RoundCharacters.Horizontal;
            Borders["Vertical"] = (char)RoundCharacters.Vertical;
            Borders["TopLeftCorner"] = (char)RoundCharacters.TopLeftCorner;
            Borders["TopRightCorner"] = (char)RoundCharacters.TopRightCorner;
            Borders["BottomLeftCorner"] = (char)RoundCharacters.BottomLeftCorner;
            Borders["BottomRightCorner"] = (char)RoundCharacters.BottomRightCorner;
        }
    }


    public void Click()
    {
        foreach (var action in ClickActions)
        {
            action();
        }
        
    }

    public void HandleKey(ConsoleKeyInfo keyInfo)
    {
        if (keyInfo.KeyChar == Content[0].ToCharArray().First())
        {
            
            ConsoleUi.FocusOnElement(this);
        }
    }
    
    public void Render()
    {
        Console.SetCursorPosition(X, Y);
        
        for (int i = 0; i < Content.Count; i++)
        {
            Console.SetCursorPosition(X, Y + i);
            Console.Write(Content[i]);
        }
    }

    public void FocusOn()
    {
        Render();
        DrawBorder();
    }

    public void FocusOff()
    {
        Render();
        RemoveBorder();
    }

    public void DrawBorder()
    {
        string upBorder = "";
        for (int i = 0; i < Length; i++) upBorder += Borders["Horizontal"];
        
        //Sides
        try
        {
            Console.SetCursorPosition(X, Y - 1);
            Console.Write(upBorder);
        }
        catch (ArgumentOutOfRangeException e) {}
        try
        {
            
            Console.SetCursorPosition(X, Y + Content.Count);
            Console.Write(upBorder);
        }
        catch (ArgumentOutOfRangeException e) {}
        try
        {
            for (int i = 0; i < Content.Count; i++)
            {
                Console.SetCursorPosition(X - 1, Y + i);
                Console.Write(Borders["Vertical"]);
            }
        }
        catch (ArgumentOutOfRangeException e) {}
        try
        {
            for (int i = 0; i < Content.Count; i++)
            {
                Console.SetCursorPosition(X + Length, Y + i);
                Console.Write(Borders["Vertical"]);
            }
        }
        catch (ArgumentOutOfRangeException e) {}
        
        //Box corners
        try
        {
            Console.SetCursorPosition(X-1, Y-1);
            Console.Write(Borders["TopLeftCorner"]);
        }
        catch (ArgumentOutOfRangeException e) {}
        try
        {
            Console.SetCursorPosition(X-1, Y+Content.Count);
            Console.Write(Borders["BottomLeftCorner"]);
        }
        catch (ArgumentOutOfRangeException e) {}
        try
        {
            Console.SetCursorPosition(X+Length, Y-1);
            Console.Write(Borders["TopRightCorner"]);
        }
        catch (ArgumentOutOfRangeException e) {}
        try
        {
            Console.SetCursorPosition(X+Length, Y+Content.Count);
            Console.Write(Borders["BottomRightCorner"]);
        }
        catch (ArgumentOutOfRangeException e) {}

    }

    public void RemoveBorder()
    {
        string upBorder = "";
        for (int i = 0; i < Length; i++) upBorder += " ";
        
        //Box sides
        try
        {
            Console.SetCursorPosition(X, Y - 1);
            Console.Write(upBorder);
        }
        catch (ArgumentOutOfRangeException e) {}
        try
        {
            
            Console.SetCursorPosition(X, Y + Content.Count);
            Console.Write(upBorder);
        }
        catch (ArgumentOutOfRangeException e) {}
        try
        {
            for (int i = 0; i < Content.Count; i++)
            {
                Console.SetCursorPosition(X - 1, Y + i);
                Console.Write(" ");
            }
        }
        catch (ArgumentOutOfRangeException e) {}
        try
        {
            for (int i = 0; i < Content.Count; i++)
            {
                Console.SetCursorPosition(X + Length, Y + i);
                Console.Write(" ");
            }
        }
        catch (ArgumentOutOfRangeException e) {}
        
        //Box corners
        try
        {
            Console.SetCursorPosition(X-1, Y-1);
            Console.Write(" ");
        }
        catch (ArgumentOutOfRangeException e) {}
        try
        {
            Console.SetCursorPosition(X-1, Y+Content.Count);
            Console.Write(" ");
        }
        catch (ArgumentOutOfRangeException e) {}
        try
        {
            Console.SetCursorPosition(X+Length, Y-1);
            Console.Write(" ");
        }
        catch (ArgumentOutOfRangeException e) {}
        try
        {
            Console.SetCursorPosition(X+Length, Y+Content.Count);
            Console.Write(" ");
        }
        catch (ArgumentOutOfRangeException e) {}
        
    }
}




















