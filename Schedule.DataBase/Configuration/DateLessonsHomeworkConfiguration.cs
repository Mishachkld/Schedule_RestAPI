using DateLessonsHomework.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Application.Dto;

namespace Schedule.DataBase.Configuration;

public class DateLessonsHomeworkConfiguration : IEntityTypeConfiguration<DateLessonsHomeworkDb>
{
    public void Configure(EntityTypeBuilder<DateLessonsHomeworkDb> builder)
    {
        builder.HasKey(dlh => dlh.Id);
        builder.HasIndex(dlh => dlh.Id).IsUnique();
        builder.Property(dlh => dlh.Day); // todo разобратсья с днем, он должен быть уникальным
        builder.HasMany(d => d.DataDlh)
            .WithOne(l => l.DateLessonsHomework)
            .HasForeignKey(l => l.DateId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}