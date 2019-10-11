using GraphQL.Types;
using GraphqlApi.Contracts;
using GraphqlApi.GraphQL.Types;

namespace GraphqlApi.GraphQL.Queries
{
    public class Query : ObjectGraphType
    {
        public Query(IOwnerRepository ownerRepository)
        {
            Field<ListGraphType<OwnerType>>("owners", resolve: context => ownerRepository.GetAll());
        }
    }
}
