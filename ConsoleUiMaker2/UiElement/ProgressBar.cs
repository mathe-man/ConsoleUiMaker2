using ConsoleUiMaker2.Characters;

namespace ConsoleUiMaker2.UiElement;

public class ProgressBar : IUiElement
{
    public int Length;
    public int TotalSteps;

    public ProgressBar(int length, int totalSteps)
    {
        Length = Length;
        TotalSteps = totalSteps;
    }
}