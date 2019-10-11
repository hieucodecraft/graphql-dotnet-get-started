using GraphqlApi.Contracts;
using GraphqlApi.Entities.Context;

namespace GraphqlApi.Contracts.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _context;

        public AccountRepository(ApplicationContext context)
        {
            _context = context;
        }
    }
}
