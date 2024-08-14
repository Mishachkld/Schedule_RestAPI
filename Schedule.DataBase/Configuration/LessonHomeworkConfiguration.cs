using DateLessonsHomework.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedule.Application.Dto;

namespace Schedule.DataBase.Configuration;

public class LessonHomeworkConfiguration : IEntityTypeConfiguration<LessonHomeworkDb>
{
    public void Configure(EntityTypeBuilder<LessonHomeworkDb> builder)
    {
        builder.HasKey(ls => ls.Id);
        builder.HasIndex(ls => ls.Id).IsUnique();
        builder.Property(lh => lh.Homework);
        builder.Property(lh => lh.Lesson); 
        builder.Property(lh => lh.NumberLesson); // todo номер урока 1-10
        // todo 1. убрать отношение, т.к. оно уже определено в главной таблице
        builder.HasOne(lh => lh.DateLessonsHomework) 
            .WithMany(dlh => dlh.DataDlh)
            .HasForeignKey(lh => lh.DateId);
    }
}