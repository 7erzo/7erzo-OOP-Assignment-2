# SRP Responsibilities

## 1. WardBoard

### Bed & Patient Assignment
Responsible for assigning patients to beds and validating bed and patient data.

### Acuity Calculation
Responsible for calculating the patient's acuity score based on vital signs.

### Handoff Note Generation
Responsible for generating handoff notes for medical staff.

### Pager Alert Management
Responsible for recording and managing pager alerts for cases that require escalation.

### Census CSV Export
Responsible for exporting bed, patient, and acuity data as CSV.

Having these responsibilities together is a problem because each one has a different reason to change. For example, changing the acuity calculation should not require changing the CSV export logic.


## 2. CheckoutBasket

### Basket Item Management
Responsible for adding products and managing the contents of the basket.

### Price Calculation
Responsible for calculating the subtotal, discounts, and final total.

### Coupon Parsing & Discount Rules
Responsible for parsing coupon text and applying coupon rules.

### Gift Wrap & Gift Message
Responsible for handling gift-wrap fees and generating the gift message.

### Payment Authorization
Responsible for generating the payment authorization code.

Having these responsibilities together is a problem because pricing, coupon rules, gift messages, and payment authorization can change independently.


## 3. SupportTicket

### Ticket Management
Responsible for managing ticket data and customer messages.

### Priority Classification
Responsible for determining the ticket priority based on its content.

### SLA Management
Responsible for calculating SLA deadlines and checking whether the SLA has been breached.

### Public Reply Generation
Responsible for generating the public response sent to the customer.

### Internal Escalation Generation
Responsible for generating internal escalation messages.

Having these responsibilities together is a problem because ticket management, priority rules, SLA rules, and message formatting have different reasons to change.


## 4. LoanDesk

### Loan Risk Assessment
Responsible for evaluating the risk of a loan application and determining applicant eligibility.

### Required Documents & Compliance
Responsible for determining which documents are required according to compliance rules.

### Decision Letter Generation
Responsible for generating approval or rejection decision letters.

### Loan Application CSV Export
Responsible for exporting loan application data for analysis.

Having these responsibilities together is a problem because risk assessment, compliance requirements, decision wording, and export formatting can change independently.


## 5. CourseEnrollmentDesk

### Course Enrollment Management
Responsible for enrolling students and managing their enrollment status.

### Waitlist Management
Responsible for managing the waitlist, student positions, and promotions when seats become available.

### Welcome Packet Generation
Responsible for generating welcome messages and onboarding information for students.

### Tuition Invoice Formatting
Responsible for calculating and formatting tuition invoice information.

Having these responsibilities together is a problem because enrollment rules, waitlist rules, welcome content, and invoice rules have different reasons to change.


## 6. KitchenTicket

### Kitchen Item Management
Responsible for managing kitchen order items and their preparation information.

### Allergen Detection
Responsible for detecting allergens in the order.

### Preparation Time Estimation
Responsible for estimating the time required to prepare the order.

### Thermal Ticket Rendering
Responsible for formatting the kitchen ticket for printing.

Having these responsibilities together is a problem because allergen rules, preparation-time rules, and printing formats can change independently.


## 7. SubscriptionBilling

### Subscription Proration
Responsible for calculating the amount owed for a subscription during a billing period.

### Invoice Number Generation
Responsible for generating invoice numbers.

### Failed Payment & Dunning
Responsible for handling failed payments and generating collection messages.

### Accounting Ledger Export
Responsible for preparing data for the accounting system.

Having these responsibilities together is a problem because billing calculations, invoice numbering, payment collection, and accounting formats have different reasons to change.


## 8. WarehousePickList

### Pick List Item Management
Responsible for managing the items required for a warehouse pick list.

### Stock Allocation
Responsible for determining how much stock can be allocated.

### Walking Order
Responsible for determining the order in which the picker should move through the warehouse.

### Picker Instructions
Responsible for generating instructions for the warehouse picker.

### WMS Integration
Responsible for preparing data for the warehouse management system.

Having these responsibilities together is a problem because stock allocation, warehouse routing, picker instructions, and external system integration can change independently.


## 9. GradeBook

### Grade Recording
Responsible for recording and storing student grades.

### Grade Calculation
Responsible for calculating the student's final grade.

### Pass / Fail Evaluation
Responsible for determining whether the student passes or fails according to academic rules.

### Grade Report Generation
Responsible for generating the student's grade report.

Having these responsibilities together is a problem because grade storage, calculation rules, passing rules, and report formatting can change independently.


## 10. AppointmentDesk

### Business Hours Policy
Responsible for defining business days, working hours, and appointment slot rules.

### Appointment Scheduling
Responsible for finding available appointments and scheduling them.

### ICS Calendar Generation
Responsible for generating calendar data for appointments.

### SMS Reminder Generation
Responsible for generating appointment reminder messages.

Having these responsibilities together is a problem because scheduling rules, calendar formatting, and reminder messages can change independently.


# Conclusion

The main problem in these classes is that each class contains multiple responsibilities with different reasons to change.

Applying the Single Responsibility Principle means splitting these responsibilities into cohesive types, where each type has one clear responsibility and one primary reason to change.