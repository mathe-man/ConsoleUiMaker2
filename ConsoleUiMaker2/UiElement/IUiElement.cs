namespace ConsoleUiMaker2.UiElement;

public interface IUiElement
{
    public int X {get; set;}
    public int Y {get; set;}
    
    //the "Click" term is used instead of Enter button pressed 
    public List<Action> ClickActions {get; set;}


    public void HandleKey(ConsoleKeyInfo keyInfo);
    public void Click();
    
    public void Render();
    public void FocusOn();
}
