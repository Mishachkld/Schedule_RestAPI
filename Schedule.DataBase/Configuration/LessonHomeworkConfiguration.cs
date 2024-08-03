using DateLessonsHomework.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Application.Dto;

namespace Schedule.DataBase.Configuration;

public class LessonHomeworkConfiguration : IEntityTypeConfiguration<LessonHomeworkDto>
{
    public void Configure(EntityTypeBuilder<LessonHomeworkDto> builder)
    {
        builder.HasKey(ls => ls.Id);
        builder.HasIndex(ls => ls.Id).IsUnique();
        builder.Property(lh => lh.Homework);
        builder.Property(lh => lh.Lesson);
        builder.Property(lh => lh.NumberLesson);
        builder.HasOne(lh => lh.DateLessonsHomework)
            .WithMany(dlh => dlh.DataDlh)
            .HasForeignKey(lh => lh.DateId);
    }
}