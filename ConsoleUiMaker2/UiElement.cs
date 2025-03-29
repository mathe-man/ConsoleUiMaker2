namespace ConsoleUiMaker2;

public interface IUiElement
{
    public int X {get; set;}
    public int Y {get; set;}
    
    //the "Click" term is used instead of Enter button pressed 
    public List<Action> OnClick {get; set;}
}
