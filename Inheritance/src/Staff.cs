namespace LibrarySystem;

public class Staff : Person
{
    protected decimal ResponsibilityAllowance { get; }
    public DateOnly HireDate { get; }
    public decimal MonthlySalary { get; private set; }
    protected Staff(string id, string name, string phone, DateOnly hireDate, decimal salary, decimal allowance = 0)
        : base(id, name, phone)
    {
        if (salary <= 0) throw new ArgumentException("Monthly salary must be greater than zero.");
        if (allowance < 0) throw new ArgumentException("Responsibility allowance cannot be negative.");
        HireDate = hireDate; MonthlySalary = salary; ResponsibilityAllowance = allowance;
    }
    public void GiveRaise(decimal percentage)
    {
        if (percentage <= 0) throw new ArgumentException("Raise percentage must be greater than zero.");
        MonthlySalary += MonthlySalary * percentage / 100m;
    }
    public decimal GetMonthlyPay() => MonthlySalary + ResponsibilityAllowance;
}
public class Librarian : Staff
{
    public Librarian(string id, string name, string phone, DateOnly hireDate, decimal salary) : base(id, name, phone, hireDate, salary) { }
    public void ProcessReturn(Loan loan, DateOnly returnDate) => loan.Return(returnDate);
    public void MarkItemAsLost(Loan loan) => loan.MarkAsLost();
}
public class Shelver : Staff
{
    public string Section { get; private set; }
    public Shelver(string id, string name, string phone, DateOnly hireDate, decimal salary, string section) : base(id, name, phone, hireDate, salary)
    {
        if (string.IsNullOrWhiteSpace(section)) throw new ArgumentException("Section cannot be empty.");
        Section = section;
    }
    public void Reassign(string newSection)
    {
        if (string.IsNullOrWhiteSpace(newSection)) throw new ArgumentException("New section cannot be empty.");
        Section = newSection;
    }
}
public class HeadLibrarian : Staff
{
    public HeadLibrarian(
        string id,
        string name,
        string phone,
        DateOnly hireDate,
        decimal salary)
        : base(id, name, phone, hireDate, salary, 400m)
    {
    }

    public void ChangeLateFee(
        LibraryItem item,
        decimal newBaseLateFee)
        => item.ChangeBaseLateFee(newBaseLateFee);

    public void WithdrawItem(
        LibraryItem item)
        => item.Withdraw();

    public void RestoreItem(
        LibraryItem item)
        => item.Restore();
}