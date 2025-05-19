using UIFactoryApplication.Enums;

public static class UIFactoryProvider
{
    public static IUIFactory GetFactory(int choice)
    {
        switch (choice)
        {
            case (int)PlatformType.Windows:
                return new WindowsFactory();
            case (int)PlatformType.MacOS:
                return new MacOSFactory();
            default:
                throw new ArgumentException("Invalid platform choice");
        }
    }
}
