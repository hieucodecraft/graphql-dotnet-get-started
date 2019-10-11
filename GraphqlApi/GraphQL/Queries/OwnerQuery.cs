using GraphQL.Types;
using GraphqlApi.Contracts;
using GraphqlApi.GraphQL.Types;

namespace GraphqlApi.GraphQL.Queries
{
    public class OwnerQuery : ObjectGraphType
    {
        public OwnerQuery(IOwnerRepository ownerRepository)
        {
            Field<ListGraphType<OwnerType>>("owners", resolve: context => ownerRepository.GetAll());
        }
    }
}
