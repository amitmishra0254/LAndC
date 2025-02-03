public class EmployeeReportServicesImp : EmployeeReportServices
{
    private ReportPrinter xmlReportPrinter;
    private ReportPrinter csvReportPrinter;
    private Employee employee;
    public EmployeeReportServicesImp(ReportPrinter xmlReportPrinter, ReportPrinter csvReportPrinter, Employee employee)
    {
        this.xmlReportPrinter = xmlReportPrinter;
        this.csvReportPrinter = csvReportPrinter;
        this.employee = employee;
    }
    public void printEmployeeDetailReportCSV(Employee employee)
    {
        xmlReportPrinter.printReport(employee.getEmployeeDetail());
    }

    public void printEmployeeDetailReportXML(Employee employee)
    {
        csvReportPrinter.printReport(employee.getEmployeeDetail());
    }
}
