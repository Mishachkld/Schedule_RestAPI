using DateLessonsHomework.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Application.Dto;

namespace Schedule.DataBase.Configuration;

public class DateLessonsHomeworkConfiguration : IEntityTypeConfiguration<DateLessonsHomeworkDto>
{
    public void Configure(EntityTypeBuilder<DateLessonsHomeworkDto> builder)
    {
        builder.HasKey(dlh => dlh.Id);
        builder.HasIndex(dlh => dlh.Id).IsUnique();
        builder.Property(dlh => dlh.Day);
        builder.HasMany(d => d.DataDLH)
            .WithOne(l => l.DateLessonsHomework)
            .HasForeignKey(l => l.DateId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}