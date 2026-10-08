namespace LibrarySystem;
public class Member : Person
{
    private readonly List<Loan> _loans = new();
    public IReadOnlyList<Loan> Loans => _loans.AsReadOnly();
    public int MaxLoans { get; }
    public decimal LateFeeDiscountPercent { get; }
    protected Member(string personId,string fullName,string phone,int maxLoans,decimal discount)
        : base(personId,fullName,phone)
    {
        if (maxLoans <= 0) throw new ArgumentException("Maximum loans must be greater than zero.");
        if (discount < 0 || discount > 100) throw new ArgumentException("Discount percentage must be between 0 and 100.");
        MaxLoans=maxLoans; LateFeeDiscountPercent=discount;
    }
    internal void AddLoan(Loan loan)=>_loans.Add(loan);
    internal void EnsureCanBorrow()
    {
        int active=0; foreach(var loan in _loans) if(loan.Status==LoanStatus.Borrowed) active++;
        if(active>=MaxLoans) throw new InvalidOperationException($"Member {PersonId} cannot borrow more than {MaxLoans} active loans.");
    }
}
public class StudentMember : Member
{
    public StudentMember(string id,string name,string phone):base(id,name,phone,3,0){}
}
public class PremiumMember : Member
{
    public int ReadingPoints { get { int count=0; foreach(var loan in Loans) if(loan.Status==LoanStatus.Returned) count++; return count*5; } }
    public PremiumMember(string id,string name,string phone,decimal discount):base(id,name,phone,10,discount){}
}
