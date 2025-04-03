using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleUiMaker2.UiElement;

namespace ConsoleUiMaker2;

public static class ConsoleUi
{
    public static readonly string UiElementType = "ConsoleUi";

    public static IUiElement FocusedElement;
    public static List<IUiElement> UiElementList = new();
    
    public static List<Action<ConsoleKeyInfo>> ExternersKeyHandler;

    
    
    public static void RunUi()
    {
        if (UiElementList.Count == 0) throw new Exception("No UiElements found in UiElementList");
        
        Console.Clear();
        Console.CursorVisible = false;
        
        FocusedElement = UiElementList[0];
        
    
        
        while (true)
        {
            ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);

            foreach (var element in UiElementList)
            {
                element.Render();
                Console.SetCursorPosition(element.X, element.Y);
                Console.Write("\u25c9");
            }
            
            //Cursor management
            UpdateCursor(pressedKeyInfo);
            
            
            
            if (pressedKeyInfo.Key == ConsoleKey.Enter)
            {
                FocusedElement.Click();
            }

            foreach (var element in UiElementList)  element.HandleKey(pressedKeyInfo);
        }
 
    }
    
    private static int _cursorX = 0;
    private static int _cursorY = 0;
    public static ConsoleColor CursorColor = ConsoleColor.Yellow;
    private static void UpdateCursor(ConsoleKeyInfo keyInfo)
    {
        Console.SetCursorPosition(_cursorX, _cursorY);
        Console.Write(' ');
        switch (keyInfo.Key)
        {
            case ConsoleKey.UpArrow: 
                if(_cursorY > 0) _cursorY--; break;
            case ConsoleKey.DownArrow:
                if (_cursorY < Console.BufferHeight) _cursorY++; break;
            
            case ConsoleKey.LeftArrow:
                if (_cursorX > 0) _cursorX--; break;
            case ConsoleKey.RightArrow:
                if (_cursorX < Console.BufferWidth) _cursorX++; break;
        }

        FocusElement();
        FocusedElement.FocusOn();
        
        Console.ForegroundColor = CursorColor;
        Console.SetCursorPosition(_cursorX, _cursorY);
        Console.Write("\u27a4");
        Console.ResetColor();
    }

    private static void FocusElement()
    {
        foreach (var element in UiElementList)
        {
            if (element.X == _cursorX+1 && element.Y == _cursorY)
            {
                var pastElement = FocusedElement;
                FocusedElement =  element;
                pastElement.Render();
            }
        }
    }
}