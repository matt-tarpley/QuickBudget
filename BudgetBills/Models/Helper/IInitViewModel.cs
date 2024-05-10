namespace BudgetBills.Models.Helper
{
    public interface IInitViewModel<T> where T : class
    {
        //define generic at the class level so every member using type T must be the same
        //also ensure T is a class
        T BuildViewModel(BudgetBillsContext db);
    }
}
