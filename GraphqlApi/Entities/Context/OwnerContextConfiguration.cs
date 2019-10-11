﻿using GraphqlApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GraphqlApi.Entities.Context
{
    public class OwnerContextConfiguration : IEntityTypeConfiguration<Owner>
    {
        private Guid[] _ids;

        public OwnerContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder
              .HasData(
                new Owner
                {
                    Id = _ids[0],
                    Name = "John Doe",
                    Address = "John Doe's address"
                },
                new Owner
                {
                    Id = _ids[1],
                    Name = "Johny Deep",
                    Address = "Jane Doe's address"
                }
            );
        }
    }
}
