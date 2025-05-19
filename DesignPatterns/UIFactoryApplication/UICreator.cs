using UIFactoryApplication.Constants;
using UIFactoryApplication.Enums;

public class UICreator
{
    static void Main(string[] args)
    {
        int choice = ShowMenuAndGetChoice();
        IUIFactory factory = CreateFactory(choice);
        RenderUIComponents(factory);
    }

    private static int ShowMenuAndGetChoice()
    {
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine(ApplicationConstants.Menu + "Enter your choice (1-2): ");

        if (int.TryParse(Console.ReadLine(), out int choice) &&
            (choice == (int)PlatformType.Windows || choice == (int)PlatformType.MacOS))
        {
            return choice;
        }
        Console.WriteLine(ApplicationConstants.InvalidUserInput);
        return ShowMenuAndGetChoice();
    }

    private static IUIFactory CreateFactory(int choice)
    {
        return UIFactoryProvider.GetFactory(choice);
    }

    private static void RenderUIComponents(IUIFactory factory)
    {
        IButton button = factory.CreateButton();
        ICheckbox checkbox = factory.CreateCheckbox();
        ITextField textField = factory.CreateTextField();

        Console.WriteLine("\nRendering UI Components:");
        button.Render();
        checkbox.Render();
        textField.Render();
    }
}
