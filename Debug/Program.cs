using System;
using System.Data;
using ConsoleUiMaker2;
using ConsoleUiMaker2.UiElement;

namespace Debug;
public static class Program
{
    public static void Main(string[] args)
    {
        Text myFirstText = new Text(["One line"], 4, 2);
        Text mySecondText = new Text(["Two", "lines"], 1, 4);

        myFirstText.Length = 30;
        ConsoleUi.RunUi();
    }
}