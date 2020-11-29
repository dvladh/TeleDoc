using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<AppointmentStatus>
    {
        public void Configure(EntityTypeBuilder<AppointmentStatus> builder)
        {
            builder.HasData
            (
                new AppointmentStatus
                {
                    Id = 1,
                    Name = "Requested",
                    Code = "Req"
                },
                new AppointmentStatus
                {
                    Id = 2,
                    Name = "Accepted",
                    Code = "Acc"
                },
                new AppointmentStatus
                {
                    Id = 3,
                    Name = "Canceled",
                    Code = "Can"
                },
                new AppointmentStatus
                {
                    Id = 4,
                    Name = "Completed",
                    Code = "Com"
                });
        }
    }
}
