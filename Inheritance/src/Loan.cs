namespace LibrarySystem;
public enum LoanStatus { Borrowed, Returned, Lost }
public class Loan
{
    private static readonly HashSet<string> UsedLoanIds = new();
    public string LoanId { get; }
    public DateOnly BorrowDate { get; }
    public Member Member { get; }
    public LibraryItem Item { get; }
    public LoanStatus Status { get; private set; }
    public DateOnly DueDate=>BorrowDate.AddDays(Item.LoanPeriodDays);
    public DateOnly? ReturnDate { get; private set; }
    public decimal LateFee
    {
        get
        {
            if(!ReturnDate.HasValue || ReturnDate.Value<=DueDate) return 0;
            int lateDays=ReturnDate.Value.DayNumber-DueDate.DayNumber;
            decimal gross=lateDays*Item.GetDailyLateFee();
            return gross-(gross*Member.LateFeeDiscountPercent/100m);
        }
    }
    public Loan(string loanId,Member member,LibraryItem item,DateOnly borrowDate)
    {
        if(string.IsNullOrWhiteSpace(loanId)) throw new ArgumentException("Loan ID cannot be empty.");
        ArgumentNullException.ThrowIfNull(member); ArgumentNullException.ThrowIfNull(item);
        if (!UsedLoanIds.Add(loanId))
            throw new InvalidOperationException($"Loan ID {loanId} already exists.");
        member.EnsureCanBorrow(); item.EnsureCanBorrow();
        LoanId=loanId; Member=member; Item=item; BorrowDate=borrowDate; Status=LoanStatus.Borrowed;
        member.AddLoan(this); item.MarkBorrowed();
    }
    public void Return(DateOnly returnDate)
    {
        if(Status!=LoanStatus.Borrowed) throw new InvalidOperationException($"Loan {LoanId} cannot be returned because its status is {Status}.");
        if(returnDate<BorrowDate) throw new ArgumentException("Return date cannot be earlier than the borrow date.");
        ReturnDate=returnDate; Status=LoanStatus.Returned; Item.MarkReturned();
    }
    public void MarkAsLost()
    {
        if(Status!=LoanStatus.Borrowed) throw new InvalidOperationException($"Loan {LoanId} cannot be marked as lost because its status is {Status}.");
        Status=LoanStatus.Lost; Item.MarkReturned();
    }
}
