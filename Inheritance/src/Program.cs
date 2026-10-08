using LibrarySystem;
Console.WriteLine("=== INHERITANCE / LIBRARY SYSTEM ===\n");
// These must NOT compile if uncommented:
// var person = new Person("P1", "Ali", "01000000000");
// var member = new Member("M1", "Ali", "01000000000", 3, 0);
// var staff = new Staff("S1", "Ali", "01000000000", DateOnly.FromDateTime(DateTime.Today), 5000);
// var item = new LibraryItem("I1", "Book", 21, 10, 1);
// member.FullName = "Changed";
// member.Loans.Add(null!);
// item.IsOnLoan = true;
Console.WriteLine("=== STAFF POLYMORPHISM ===");
var staffMembers = new List<Staff>{
 new Librarian("ST-01","Librarian Ali","01011111111",new DateOnly(2025,1,10),7000),
 new HeadLibrarian("ST-02","Head Sara","01022222222",new DateOnly(2024,5,15),9000),
 new Shelver("ST-03","Shelver Omar","01033333333",new DateOnly(2026,2,1),5000,"Fiction")};
foreach (var staff in staffMembers) Console.WriteLine($"{staff.FullName}: monthly pay = {staff.GetMonthlyPay():0.00}");
staffMembers[0].GiveRaise(10); Console.WriteLine($"After 10% raise: {staffMembers[0].FullName} = {staffMembers[0].GetMonthlyPay():0.00}");
var shelver = (Shelver)staffMembers[2]; shelver.Reassign("Children"); Console.WriteLine($"Shelver new section: {shelver.Section}");
Console.WriteLine("\n=== LIBRARY ITEMS ===");
var book = new Book("B-001", "Clean Code", 10m); var dvd = new DVD("D-001", "Inception", 10m); var magazine = new Magazine("M-001", "Tech Monthly", 10m);
var items = new List<LibraryItem> { book, dvd, magazine }; foreach (var item in items) Console.WriteLine($"{item.Title}: loan period = {item.LoanPeriodDays} days, daily late fee = {item.GetDailyLateFee():0.00}");
Console.WriteLine("\n=== WITHDRAWN ITEM RULE ===");
var withdrawnBook = new Book("B-002", "Withdrawn Book", 10m); withdrawnBook.Withdraw();
try { var student = new StudentMember("M-01", "Student Ahmed", "01044444444"); _ = new Loan("L-01", student, withdrawnBook, new DateOnly(2026, 10, 1)); } catch (Exception ex) { Console.WriteLine($"Rejected: {ex.Message}"); }
Console.WriteLine("\n=== DOUBLE LOAN RULE ===");
var doubleLoanItem = new Book("B-003", "Shared Book", 10m); var studentA = new StudentMember("M-02", "Student A", "01055555555"); var studentB = new StudentMember("M-03", "Student B", "01066666666");
_ = new Loan("L-02", studentA, doubleLoanItem, new DateOnly(2026, 10, 1)); try { _ = new Loan("L-03", studentB, doubleLoanItem, new DateOnly(2026, 10, 1)); } catch (Exception ex) { Console.WriteLine($"Rejected: {ex.Message}"); }
Console.WriteLine("\n=== STUDENT LOAN LIMIT ===");
var limitStudent = new StudentMember("M-04", "Student Limit", "01077777777"); var limitItem1 = new Book("B-101", "Book 1", 5m); var limitItem2 = new Book("B-102", "Book 2", 5m); var limitItem3 = new Book("B-103", "Book 3", 5m); var limitItem4 = new Book("B-104", "Book 4", 5m);
_ = new Loan("L-101", limitStudent, limitItem1, new DateOnly(2026, 10, 1)); _ = new Loan("L-102", limitStudent, limitItem2, new DateOnly(2026, 10, 1)); _ = new Loan("L-103", limitStudent, limitItem3, new DateOnly(2026, 10, 1));
try { _ = new Loan("L-104", limitStudent, limitItem4, new DateOnly(2026, 10, 1)); } catch (Exception ex) { Console.WriteLine($"Rejected: {ex.Message}"); }
Console.WriteLine("\n=== PREMIUM LATE FEE / READING POINTS ===");
var premium = new PremiumMember("M-05", "Premium Member", "01088888888", 20m); var premiumDvd = new DVD("D-005", "Premium DVD", 10m); var premiumLoan = new Loan("L-201", premium, premiumDvd, new DateOnly(2026, 10, 1));
Console.WriteLine($"Due date: {premiumLoan.DueDate:yyyy-MM-dd}"); var fiveDaysLate = premiumLoan.DueDate.AddDays(5); premiumLoan.Return(fiveDaysLate); Console.WriteLine($"Return date: {premiumLoan.ReturnDate:yyyy-MM-dd}"); Console.WriteLine($"Late fee: {premiumLoan.LateFee:0.00}"); Console.WriteLine($"Reading points: {premium.ReadingPoints}");
Console.WriteLine("\n=== LEGAL STATUS TRANSITIONS ===");
try { premiumLoan.Return(fiveDaysLate.AddDays(1)); } catch (Exception ex) { Console.WriteLine($"Second return rejected: {ex.Message}"); }
try { premiumLoan.MarkAsLost(); } catch (Exception ex) { Console.WriteLine($"Mark returned loan as lost rejected: {ex.Message}"); }
Console.WriteLine("\n=== INVALID RETURN DATE ===");
var dateMember = new StudentMember("M-06", "Date Tester", "01099999999"); var dateBook = new Book("B-201", "Date Book", 10m); var dateLoan = new Loan("L-301", dateMember, dateBook, new DateOnly(2026, 10, 10)); try { dateLoan.Return(new DateOnly(2026, 10, 9)); } catch (Exception ex) { Console.WriteLine($"Rejected: {ex.Message}"); }
Console.WriteLine("\n=== LATE FEE PRICING ===");
var head = new HeadLibrarian("ST-04", "Head Pricing", "01100000000", new DateOnly(2023, 1, 1), 10000); head.ChangeLateFee(book, 20m); Console.WriteLine($"New book base fee: {book.BaseLateFee:0.00}, daily late fee: {book.GetDailyLateFee():0.00}");

Console.WriteLine("\n=== POSITIVE VALUE / IDENTITY VALIDATION ===");
try { _ = new StudentMember("", "Invalid", "01000000000"); }
catch (Exception ex) { Console.WriteLine($"Invalid identity rejected: {ex.Message}"); }
try { staffMembers[0].GiveRaise(0); }
catch (Exception ex) { Console.WriteLine($"Invalid raise rejected: {ex.Message}"); }
try { book.ChangeBaseLateFee(0); }
catch (Exception ex) { Console.WriteLine($"Invalid late fee rejected: {ex.Message}"); }

Console.WriteLine("\n=== MEMBER LOAN HISTORY ==="); Console.WriteLine($"Premium loans: {premium.Loans.Count}, reading points: {premium.ReadingPoints}"); Console.WriteLine("\nDone.");
