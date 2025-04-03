using ConsoleUiMaker2.Characters;

namespace ConsoleUiMaker2.UiElement;

public class TextField : IUiElement
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public List<Action> ClickActions { get; set; }

    private bool _haveBorder;

    public bool HaveBorder
    {
        get { return _haveBorder;}
        set
        {
            _haveBorder = value;
            if (_haveBorder) DrawBorder();
            else RemoveBorder();
        }
    }
    public bool FixedBorder { get; set; }
    
    public int Length { get; set; }
    public int MaxLines { get; set; }
    public bool IsWriting { get; set; }
    public List<string> PlaceHolder { get; set; }
    public List<string> Content { get; set; }
    
    public TextField(int x, int y, int length, int lines, List<string>? placeHolder, bool haveBorder = true, bool startWriting = false, bool fixedBorder = false)
    {
        X = x;
        Y = y;

        placeHolder ??= [""];
        PlaceHolder = placeHolder;
        
        HaveBorder = haveBorder;
        FixedBorder = fixedBorder;
        
        IsWriting = startWriting;
        ClickActions = new List<Action>();
        Content = new List<string>(MaxLines);
        for (int i = 0; i < MaxLines; i++)  Content[i] = "";
        
        
        
        Length = length;
        MaxLines = lines;
    }

    public void HandleKey(ConsoleKeyInfo keyInfo)
    {
        if (keyInfo.Key == ConsoleKey.Enter) IsWriting = false;
        if (IsWriting)
        {
            Content[Console.GetCursorPosition().Top - Y] += keyInfo.KeyChar;
        }
    }



    public void Render()
    {
        if (HaveBorder) DrawBorder();
        for (int i = 0; i < Content.Count; i++)
        {
            Console.SetCursorPosition(X, Y + i);
            Console.Write(Content[i]);
        }
    }

    public void Click()
    {
        IsWriting = true;
    }

    public void FocusOn()
    {
        
    }
    
    
    public Dictionary<string , char> Borders = new ();
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
        catch (ArgumentOutOfRangeException) {}
        try
        {
            
            Console.SetCursorPosition(X, Y + Content.Count);
            Console.Write(upBorder);
        }
        catch (ArgumentOutOfRangeException) {}
        try
        {
            for (int i = 0; i < (FixedBorder ? MaxLines : Content.Count); i++)
            {
                Console.SetCursorPosition(X - 1, Y + i);
                Console.Write(Borders["Vertical"]);
            }
        }
        catch (ArgumentOutOfRangeException) {}
        try
        {
            for (int i = 0; i < (FixedBorder ? MaxLines : Content.Count); i++)
            {
                Console.SetCursorPosition(X + Length, Y + i);
                Console.Write(Borders["Vertical"]);
            }
        }
        catch (ArgumentOutOfRangeException) {}
        
        //Box corners
        try
        {
            Console.SetCursorPosition(X-1, Y-1);
            Console.Write(Borders["TopLeftCorner"]);
        }
        catch (ArgumentOutOfRangeException) {}
        try
        {
            Console.SetCursorPosition(X-1, Y+(FixedBorder ? MaxLines : Content.Count));
            Console.Write(Borders["BottomLeftCorner"]);
        }
        catch (ArgumentOutOfRangeException) {}
        try
        {
            Console.SetCursorPosition(X+Length, Y-1);
            Console.Write(Borders["TopRightCorner"]);
        }
        catch (ArgumentOutOfRangeException) {}
        try
        {
            Console.SetCursorPosition(X+Length, Y+(FixedBorder ? MaxLines : Content.Count));
            Console.Write(Borders["BottomRightCorner"]);
        }
        catch (ArgumentOutOfRangeException) {}

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
        catch (ArgumentOutOfRangeException) {}
        try
        {
            
            Console.SetCursorPosition(X, Y + (FixedBorder ? MaxLines : Content.Count));
            Console.Write(upBorder);
        }
        catch (ArgumentOutOfRangeException) {}
        try
        {
            for (int i = 0; i < Content.Count; i++)
            {
                Console.SetCursorPosition(X - 1, Y + i);
                Console.Write(" ");
            }
        }
        catch (ArgumentOutOfRangeException) {}
        try
        {
            for (int i = 0; i < (FixedBorder ? MaxLines : Content.Count); i++)
            {
                Console.SetCursorPosition(X + Length, Y + i);
                Console.Write(" ");
            }
        }
        catch (ArgumentOutOfRangeException) {}
        
        //Box corners
        try
        {
            Console.SetCursorPosition(X-1, Y-1);
            Console.Write(" ");
        }
        catch (ArgumentOutOfRangeException) {}
        try
        {
            Console.SetCursorPosition(X-1, Y+(FixedBorder ? MaxLines : Content.Count));
            Console.Write(" ");
        }
        catch (ArgumentOutOfRangeException) {}
        try
        {
            Console.SetCursorPosition(X+Length, Y-1);
            Console.Write(" ");
        }
        catch (ArgumentOutOfRangeException) {}
        try
        {
            Console.SetCursorPosition(X+Length, Y+(FixedBorder ? MaxLines : Content.Count));
            Console.Write(" ");
        }
        catch (ArgumentOutOfRangeException) {}
        
    }

}