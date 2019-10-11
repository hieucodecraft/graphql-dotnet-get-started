using GraphqlApi.Entities;
using GraphqlApi.Entities.Context;
using System.Collections.Generic;
using System.Linq;

namespace GraphqlApi.Contracts.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationContext _context;

        public OwnerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Owner> GetAll() => _context.Owners.ToList();
    }
}
