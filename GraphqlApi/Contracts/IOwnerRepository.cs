using GraphqlApi.Entities;
using System.Collections.Generic;

namespace GraphqlApi.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
    }
}
