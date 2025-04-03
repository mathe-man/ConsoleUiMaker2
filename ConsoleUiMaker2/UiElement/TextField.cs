using ConsoleUiMaker2.Characters;

namespace ConsoleUiMaker2.UiElement;

public class TextField : IUiElement
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public List<Action> ClickActions { get; set; }
    
    private bool _haveBorder = true;

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
    public bool IsWriting { get; set; }
    public string PlaceHolder { get; set; }
    public string Content { get; set; } = "";
    
    public TextField(int x, int y, int length, string? placeHolder = null, bool haveBorder = true, bool startWriting = false, bool fixedBorder = false, string borderType = "round")
    {
        X = x;
        Y = y;
        Length = length;
        PlaceHolder = placeHolder ?? "";
        IsWriting = startWriting;
        ClickActions = new List<Action>();
        Content = "";
        
        SetBorders(borderType);
        HaveBorder = haveBorder;
        FixedBorder = fixedBorder;
        
        ConsoleUi.UiElementList.Add(this);
    }

    public void HandleKey(ConsoleKeyInfo keyInfo)
    {
        if (keyInfo.Key == ConsoleKey.Enter) IsWriting = false;
        if (ConsoleUi.FocusedElement == this)
        {
            if (keyInfo.Key == ConsoleKey.Backspace && Content.Length > 0)
                Content = Content[..^1];
            else if (Content.Length < Length && !char.IsControl(keyInfo.KeyChar))
                Content += keyInfo.KeyChar;
        }
        Render();
    }

    public void Render()
    {

        if (ConsoleUi.FocusedElement == this) Console.ForegroundColor = ConsoleColor.Red;
        
        if (HaveBorder) DrawBorder();
        Console.SetCursorPosition(X, Y);
        Console.Write(Content.PadRight(Length));
        
        
        Console.SetCursorPosition(X-1, Y);
        Console.Write("\u29eb");
        Console.ResetColor();
    }

    public void Click()
    {
        IsWriting = true;
    }

    public void FocusOn()
    {
        Render();
        
        Click();
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
        string upBorder = new string(Borders["Horizontal"], Length);
        //Sides
        try
        {
            Console.SetCursorPosition(X, Y-1);
            Console.Write(upBorder);
        }
        catch (ArgumentOutOfRangeException) {}
        try
        {
            
            Console.SetCursorPosition(X, Y+1);
            Console.Write(upBorder);
        }
        catch (ArgumentOutOfRangeException) {}
        try
        {
            Console.SetCursorPosition(X + Length, Y);
            Console.Write(Borders["Vertical"]);
        }
        catch (ArgumentOutOfRangeException) {}
        try
        {
            Console.SetCursorPosition(X -1, Y);
            Console.Write(Borders["Vertical"]);
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
            Console.SetCursorPosition(X-1, Y+1);
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
            Console.SetCursorPosition(X+Length, Y+1);
            Console.Write(Borders["BottomRightCorner"]);
        }
        catch (ArgumentOutOfRangeException) {}

    }

    public void RemoveBorder()
    {
        string upBorder = new string(Borders["Horizontal"], Length);
        
        //Box sides
        try
        {
            Console.SetCursorPosition(X, Y - 1);
            Console.Write(upBorder);
        }
        catch (ArgumentOutOfRangeException) {}
        try
        {
            
            Console.SetCursorPosition(X, Y + 1);
            Console.Write(upBorder);
        }
        catch (ArgumentOutOfRangeException) {}
        try
        {
            Console.SetCursorPosition(X - 1, Y);
            Console.Write(" ");
        }
        catch (ArgumentOutOfRangeException) {}
        try
        {
            Console.SetCursorPosition(X + Length, Y);
            Console.Write(" ");
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
            Console.SetCursorPosition(X-1, Y+1);
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
            Console.SetCursorPosition(X+Length, Y+1);
            Console.Write(" ");
        }
        catch (ArgumentOutOfRangeException) {}
        
    }

}