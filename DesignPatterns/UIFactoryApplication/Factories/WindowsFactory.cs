
class WindowsFactory : IUIFactory
{
    public IButton CreateButton() 
    {
        return new WindowsButton();
    }
    public ICheckbox CreateCheckbox() 
    {
        return new WindowsCheckbox();
    }
    public ITextField CreateTextField() 
    {
        return new WindowsTextField();
    }
}
