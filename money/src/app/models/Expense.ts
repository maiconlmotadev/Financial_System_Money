
export class Expense {
    Id: number;
    Name: string;
    Price: number;
    Month: number;
    Year: number;
    TypeExpense: number;
    RegistrationDate: Date;
    ChangeDate: Date;
    PaymentDate: Date;
    DueDate: Date;
    Paid: boolean;
    DelayedExpense: boolean;
    CategoryId: number;
}