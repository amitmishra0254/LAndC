/*
 * The given program was not following the SRP principle.
 * Because the single class with name Employee was having 
 * all the methods to save, print in different formats and 
 * to terminate the employee.
 * 
 * I have updated the code with following SOLID principles and segregated the code in different parts.
 */
public class StartUp
{
    public static void Main(string[] args)
    {
        EmployeeRepository employeeRepository = new EmployeeRepositoryImp();
        Employee employee = new EmployeeImp();
        ReportPrinter xmlReportPrinter = new XMLReportPrinterImp();
        ReportPrinter csvReportPrinter = new CSVReportPrinterImp();
        EmployeeReportServices employeeReportServices = new EmployeeReportServicesImp(xmlReportPrinter, csvReportPrinter, employee);
        employeeRepository.saveEmployeeTODatabase();
        employeeReportServices.printEmployeeDetailReportXML(employee);
        employeeReportServices.printEmployeeDetailReportCSV(employee);
        employee.terminateEmployee();
        employee.isWorking();
    }
}
