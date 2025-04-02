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
            }

            UpdateCursor(pressedKeyInfo);
            
            
            if (pressedKeyInfo.Key == ConsoleKey.Tab)
            {
                FocusOnElement();
            }
            else if (pressedKeyInfo.Key == ConsoleKey.Enter)
            {
                FocusedElement.Click();
            }

            foreach (var element in UiElementList)  element.HandleKey(pressedKeyInfo);
        }
 
    }

    public static void FocusOnElement(IUiElement? element = null)
    {
        if (element != null)
        {
            FocusedElement.FocusOff();
            FocusedElement = element;
            FocusedElement.FocusOn();
        }
        else if (UiElementList.Contains(FocusedElement))
        {
            FocusedElement.FocusOff();
            if (UiElementList.IndexOf(FocusedElement) == UiElementList.Count - 1) FocusedElement = UiElementList[0];
            else FocusedElement = UiElementList[UiElementList.IndexOf(FocusedElement) + 1];
            FocusedElement.FocusOn();   
        }
        else
        {
            FocusedElement.FocusOff();
            FocusedElement = UiElementList[0];
            FocusedElement.FocusOn();
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

        Console.ForegroundColor = CursorColor;
        Console.SetCursorPosition(_cursorX, _cursorY);
        Console.Write("\u27a4");
        Console.ResetColor();
    }
}