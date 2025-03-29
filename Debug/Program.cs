using System;
using System.Data;
using ConsoleUIMaker;
using ConsoleUiMaker2;

namespace Debug;
public static class Program
{
    public static TextField title = new TextField("Yo mama", 25, 1, 15, 5);
    public static  TextField username = new TextField("Username", 50, 1, 3, 8);
    public static TextField pass = new TextField("Password", 50, 1, 3, 10, true);

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.Title = "ConsoleUiMaker Test";
        Console.Clear();
        
        

        
        UiElement.UiElementList.Add(title);
        UiElement.UiElementList.Add(username);
        UiElement.UiElementList.Add(pass);
        
        UiElement.UiElementList.Add(new Button("Connect", TryConnect, 14, 12));

        
        UiElement.RunUi();
    }

    public static void TryConnect()
    {
        if (username.content.ToString() == "mathe-man" && pass.content.ToString() == "caca")
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("utilisateur mathe-man connecté");
        }
    }
}