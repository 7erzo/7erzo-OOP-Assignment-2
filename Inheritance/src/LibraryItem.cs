namespace LibrarySystem;
public class LibraryItem
{
    public string CatalogNumber { get; }
    public string Title { get; }
    public int LoanPeriodDays { get; }
    public decimal BaseLateFee { get; private set; }
    public decimal LateFeeMultiplier { get; }
    public bool IsWithdrawn { get; private set; }
    public bool IsOnLoan { get; private set; }
    protected LibraryItem(string catalogNumber,string title,int loanPeriodDays,decimal baseLateFee,decimal multiplier)
    {
        if(string.IsNullOrWhiteSpace(catalogNumber)) throw new ArgumentException("Catalog number cannot be empty.");
        if(string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title cannot be empty.");
        if(loanPeriodDays<=0) throw new ArgumentException("Loan period must be greater than zero.");
        if(baseLateFee<=0) throw new ArgumentException("Base late fee must be greater than zero.");
        if(multiplier<=0) throw new ArgumentException("Late-fee multiplier must be greater than zero.");
        CatalogNumber=catalogNumber; Title=title; LoanPeriodDays=loanPeriodDays; BaseLateFee=baseLateFee; LateFeeMultiplier=multiplier;
    }
    public decimal GetDailyLateFee()=>BaseLateFee*LateFeeMultiplier;
    internal void EnsureCanBorrow()
    {
        if(IsWithdrawn) throw new InvalidOperationException($"Item {CatalogNumber} is withdrawn and cannot be borrowed.");
        if(IsOnLoan) throw new InvalidOperationException($"Item {CatalogNumber} is already on loan.");
    }
    internal void MarkBorrowed(){EnsureCanBorrow(); IsOnLoan=true;}
    internal void MarkReturned(){if(!IsOnLoan) throw new InvalidOperationException($"Item {CatalogNumber} is not currently on loan."); IsOnLoan=false;}
    public void ChangeBaseLateFee(decimal newBaseLateFee){if(newBaseLateFee<=0) throw new ArgumentException("New late fee must be greater than zero."); BaseLateFee=newBaseLateFee;}
    public void Withdraw(){if(IsOnLoan) throw new InvalidOperationException("An item currently on loan cannot be withdrawn."); IsWithdrawn=true;}
    public void Restore()=>IsWithdrawn=false;
}
public class Book:LibraryItem{public Book(string number,string title,decimal fee):base(number,title,21,fee,1m){}}
public class DVD:LibraryItem{public DVD(string number,string title,decimal fee):base(number,title,7,fee,2m){}}
public class Magazine:LibraryItem{public Magazine(string number,string title,decimal fee):base(number,title,3,fee,.5m){}}
