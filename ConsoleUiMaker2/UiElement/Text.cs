using System.Net;
using Microsoft.Win32.SafeHandles;

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
    
    public Text(List<string> content, int x, int y, List<Action>? clickActions = null)
    {
        X = x;
        Y = y;
        Content = content;
        ClickActions = clickActions == null ? new List<Action>() : clickActions;
        
        ConsoleUi.UiElementList.Add(this);
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
        for (int i = 0; i < Length; i++) upBorder += "\u2500";
        
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
                Console.Write("\u2502");
            }
        }
        catch (ArgumentOutOfRangeException e) {}
        try
        {
            for (int i = 0; i < Content.Count; i++)
            {
                Console.SetCursorPosition(X + Length, Y + i);
                Console.Write("\u2502");
            }
        }
        catch (ArgumentOutOfRangeException e) {}
        
        //Box corners
        try
        {
            Console.SetCursorPosition(X-1, Y-1);
            Console.Write("\u250c");
        }
        catch (ArgumentOutOfRangeException e) {}
        try
        {
            Console.SetCursorPosition(X-1, Y+Content.Count);
            Console.Write("\u2514");
        }
        catch (ArgumentOutOfRangeException e) {}
        try
        {
            Console.SetCursorPosition(X+Length, Y-1);
            Console.Write("\u2510");
        }
        catch (ArgumentOutOfRangeException e) {}
        try
        {
            Console.SetCursorPosition(X+Length, Y+Content.Count);
            Console.Write("\u2518");
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




















