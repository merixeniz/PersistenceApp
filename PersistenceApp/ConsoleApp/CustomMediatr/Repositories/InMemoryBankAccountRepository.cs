using ConsoleApp.CustomMediatr.Entities;
using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Repositories
{
    public class InMemoryBankAccountRepository : IBankAccountRepository
    {
        private readonly Dictionary<Guid, BankAccount> _accounts = new Dictionary<Guid, BankAccount>();

        public async Task<BankAccount> GetByIdAsync(Guid accountId)
        {
            _accounts.TryGetValue(accountId, out var account);
            return await Task.FromResult(account);
        }

        public bool Add(BankAccount account)
        {
            _accounts[account.Id] = account;
            return true;
        }
    }

}
