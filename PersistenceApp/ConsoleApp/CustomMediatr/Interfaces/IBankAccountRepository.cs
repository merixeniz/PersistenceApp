using ConsoleApp.CustomMediatr.Entities;

namespace ConsoleApp.CustomMediatr.Interfaces
{
    public interface IBankAccountRepository
    {
        Task<BankAccount> GetByIdAsync(Guid accountId);
        bool Add(BankAccount account);
    }

}
