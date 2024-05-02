namespace BudgetBills.Models.Helper
{
    public class Filter
    {
        public Filter(int[] filters) 
        {
            NecessityLevelId = filters[0];
            CategoryId = filters[1];
        }

        public int? NecessityLevelId { get; set; }
        public int? CategoryId { get; set; }


        public bool HasNecessityLevel => NecessityLevelId!= 0;
        public bool HasCategory => CategoryId != 0;
    }
}
