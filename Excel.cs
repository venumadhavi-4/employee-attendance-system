using ClosedXML.Excel;

namespace attendence;

public class Excel
{
    public bool openFile(string enteredId, string enteredPassword)
    {
        XLWorkbook file = new XLWorkbook("Employees.xlsx");

        IXLWorksheet sheet = file.Worksheet("Employees");

        var lastRow = sheet.LastRowUsed();

if (lastRow == null)
{
    return false;
}

int rows = lastRow.RowNumber();

        for (int i = 2; i <= rows; i++)
        {
            string id = sheet.Cell(i, 1).GetString();
            string password = sheet.Cell(i, 2).GetString();

            if (id == enteredId && password == enteredPassword)
            {
                return true;
            }
        }

        return false;
    }
    public string getSingleSwipe(string empId)
{
    XLWorkbook file = new XLWorkbook("Employees.xlsx");

    IXLWorksheet sheet = file.Worksheet("Attendence");

    int totalRows = sheet.LastRowUsed()!.RowNumber();

    for (int i = 2; i <= totalRows; i++)
    {
        string id = sheet.Cell(i, 1).GetString();

        string inTime = sheet.Cell(i, 3).GetString();

        string outTime = sheet.Cell(i, 4).GetString();

        if (id == empId && inTime != "" && outTime == "")
        {
            return sheet.Cell(i, 2).GetString();
        }
    }

    return "";
}
public string getStatusUnknown(string empId)
{
    XLWorkbook file = new XLWorkbook("Employees.xlsx");

    IXLWorksheet sheet = file.Worksheet("Attendence");

    int totalRows = sheet.LastRowUsed()!.RowNumber();

    for (int i = 2; i <= totalRows; i++)
    {
        string id = sheet.Cell(i, 1).GetString();

        string inTime = sheet.Cell(i, 3).GetString();

        string outTime = sheet.Cell(i, 4).GetString();

        if (id == empId && inTime == "" && outTime == "")
        {
            return sheet.Cell(i, 2).GetString();
        }
    }

    return "";
}
    public List<string[]> getAttendance(string empId)
{
    List<string[]> records = new List<string[]>();

    XLWorkbook file = new XLWorkbook("Employees.xlsx");

    IXLWorksheet sheet = file.Worksheet("Attendence");

    int totalRows = sheet.LastRowUsed()!.RowNumber();

    for (int i = 2; i <= totalRows; i++)
    {
        string id = sheet.Cell(i, 1).GetString();

        if (id == empId)
        {
            string[] row = new string[4];

            row[0] = sheet.Cell(i, 2).GetString(); // Date
            row[1] = sheet.Cell(i, 3).GetString(); // In Time
            row[2] = sheet.Cell(i, 4).GetString(); // Out Time
            row[3] = sheet.Cell(i, 5).GetString(); // Status

            records.Add(row);
        }
    }

    return records;
}
public string getAverageHours(string empId, string year, string month)
{
    XLWorkbook file = new XLWorkbook("Employees.xlsx");

    IXLWorksheet sheet = file.Worksheet("Attendence");

    int totalRows = sheet.LastRowUsed()!.RowNumber();

    int totalMinutes = 0;
    int totalDays = 0;

    for (int i = 2; i <= totalRows; i++)
    {
        string id = sheet.Cell(i, 1).GetString();

        if (id != empId)
            continue;

        DateTime date = Convert.ToDateTime(sheet.Cell(i, 2).GetString());

        if (year == "2024-2025")
        {
            if (date.Year != 2025)
                continue;
        }
        else if (year == "2025-2026")
        {
            if (date.Year != 2026)
                continue;
        }

        if (date.ToString("MMM") != month)
            continue;

        string inTime = sheet.Cell(i, 3).GetString();
        string outTime = sheet.Cell(i, 4).GetString();

        if (inTime == "" || outTime == "")
            continue;

        DateTime inDate = Convert.ToDateTime(inTime);
        DateTime outDate = Convert.ToDateTime(outTime);

        TimeSpan hours = outDate - inDate;

        totalMinutes += (int)hours.TotalMinutes;
        totalDays++;
    }

    if (totalDays == 0)
        return "00:00";

    int averageMinutes = totalMinutes / totalDays;

    TimeSpan average = TimeSpan.FromMinutes(averageMinutes);

    return average.ToString(@"hh\:mm");
}
}