using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        foreach (var element in UiElementList)
        {
            element.Render();
        }
    
        
        while (true)
        {
            ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);


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

    
}