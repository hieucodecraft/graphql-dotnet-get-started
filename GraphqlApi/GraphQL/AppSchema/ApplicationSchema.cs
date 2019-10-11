using GraphQL.Types;
using GraphQL.Utilities;
using GraphqlApi.GraphQL.Queries;
using System;

namespace GraphqlApi.GraphQL.AppSchema
{
    public class ApplicationSchema : Schema
    {
        public ApplicationSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<OwnerQuery>();
        }
    }
}
