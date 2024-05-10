using Microsoft.EntityFrameworkCore;

namespace BudgetBills.Models
{
    public class BudgetBillsContext: DbContext
    {
        public BudgetBillsContext(DbContextOptions<BudgetBillsContext> options)
            : base(options) { }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<IncomeSource> IncomeSources { get; set; }

        //seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Description1 = "Housing/Utilities",
                    Description2 = "Needs"
                },
                new Category
                {
                    CategoryId = 2,
                    Description1 = "Transportation",
                    Description2 = "Needs"
                },
                new Category
                {
                    CategoryId = 3,
                    Description1 = "Subscriptions",
                    Description2 = "Wants"
                },
                new Category
                {
                    CategoryId = 4,
                    Description1 = "Pets",
                    Description2 = "Needs"
                },
                new Category
                {
                    CategoryId = 6,
                    Description1 = "Medical",
                    Description2 = "Needs"
                },
                new Category
                {
                    CategoryId = 7,
                    Description1 = "Personal",
                    Description2 = "Wants"
                }
            );
            modelBuilder.Entity<Bill>().HasData(
                new Bill
                {
                    BillId = 1,
                    Description = "Mortgage",
                    Amount = 1369.00,
                    DueDate = DateTime.Parse("05/01/2024"),
                    CategoryId = 1
                },
                new Bill
                {
                    BillId = 2,
                    Description = "Car Payment",
                    Amount = 267.00,
                    DueDate = DateTime.Parse("05/12/2024"),
                    CategoryId = 2
                },
                 new Bill
                 {
                     BillId = 3,
                     Description = "Car Insurance",
                     Amount = 130.00,
                     DueDate = DateTime.Parse("05/21/2024"),
                     CategoryId = 2
                 }
            );
        }
    }
}
