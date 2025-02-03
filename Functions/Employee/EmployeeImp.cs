public class EmployeeImp : Employee
{
    public int id;
    private string name;
    private string department;
    private bool working;


    public bool isWorking()
    {
        return this.working;
    }

    public void terminateEmployee()
    {
        Console.WriteLine("Employee Terminated Successfully.");
    }

    public string getEmployeeDetail()
    {
        return this.id.ToString() + "|" + this.name + "|" + this.department + "|" + this.working.ToString();
    }
};
