using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Schedule.Application.Dto;
using Schedule.Application.Interfaces;
using Schedule.Application.Schedule.Mapper;
using Schedule.Application.Schedule.VM;
using Schedule.DataBase;

namespace Schedule.Test;

public class ScheduleRepositoryFactory
{
    public static Guid IdForDelete = Guid.NewGuid();
    public static Guid IdForUpdate = Guid.NewGuid();

    /*public static IRepository CreateRepository()
    {
        var db = CreateDbContext();
        var mapper = CreateMapper();

        return new ScheduleRepository(db, mapper);
    }*/

    internal static IDateLessonsHomeworkDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<ScheduleDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString() + 1)
            .Options;
        var db = new ScheduleDbContext(options);
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
        db.Dates.AddRange(                          // заполнение БД данными 
            new DateLessonsHomeworkDb()
            {
                Id = IdForDelete,
                Day = DateTime.Today,
                DataDlh = new List<LessonHomeworkDb>()
                {
                    new LessonHomeworkDb()
                    {
                        Id = Guid.NewGuid(),
                        DateId = IdForDelete,
                        Lesson = "Lesson 2",
                        Homework = "HomeWork 2",
                        NumberLesson = 2
                    },
                    new LessonHomeworkDb()
                    {
                        Id = Guid.NewGuid(),
                        DateId = IdForDelete,
                        Lesson = "Lesson 3",
                        Homework = "HomeWork 3",
                        NumberLesson = 3
                    },
                    new LessonHomeworkDb()
                    {
                        Id = Guid.NewGuid(),
                        DateId = IdForDelete,
                        Lesson = "Lesson 4",
                        Homework = "HomeWork 4",
                        NumberLesson = 4
                    }
                }
            }, new DateLessonsHomeworkDb()
            {
                Id = IdForUpdate,
                Day = DateTime.Today,
                DataDlh = new List<LessonHomeworkDb>()
                {
                    new LessonHomeworkDb()
                    {
                        Id = Guid.NewGuid(),
                        DateId = IdForUpdate,
                        Lesson = "Lesson 2",
                        Homework = "HomeWork 2",
                        NumberLesson = 2
                    },
                    new LessonHomeworkDb()
                    {
                        Id = Guid.NewGuid(),
                        DateId = IdForUpdate,
                        Lesson = "Lesson 3",
                        Homework = "HomeWork 3",
                        NumberLesson = 3
                    },
                    new LessonHomeworkDb()
                    {
                        Id = Guid.NewGuid(),
                        DateId = IdForUpdate,
                        Lesson = "Lesson 4",
                        Homework = "HomeWork 4",
                        NumberLesson = 4
                    }
                }
            },
            new DateLessonsHomeworkDb()
            {
                Id = Guid.Parse("e1164ea2-64b3-4486-90e6-34ae28423226"),
                Day = DateTime.Today,
                DataDlh = new List<LessonHomeworkDb>()
                {
                    new LessonHomeworkDb()
                    {
                        Id = Guid.NewGuid(),
                        DateId = Guid.Parse("e1164ea2-64b3-4486-90e6-34ae28423226"),
                        Lesson = "Lesson 2",
                        Homework = "HomeWork 2",
                        NumberLesson = 2
                    }
                }
            }, 
            new DateLessonsHomeworkDb()
            {
                Id = Guid.Parse("26e40f10-d23d-4f1b-a884-68d9d92aa24b"),
                Day = DateTime.Today,
                DataDlh = new List<LessonHomeworkDb>()
                {
                    new LessonHomeworkDb()
                    {
                        Id = Guid.NewGuid(),
                        DateId = Guid.Parse("26e40f10-d23d-4f1b-a884-68d9d92aa24b"),
                        Lesson = "Lesson 2",
                        Homework = "HomeWork 2",
                        NumberLesson = 2
                    },
                    new LessonHomeworkDb()
                    {
                        Id = Guid.NewGuid(),
                        DateId = Guid.Parse("26e40f10-d23d-4f1b-a884-68d9d92aa24b"),
                        Lesson = "Lesson 5",
                        Homework = "HomeWork 5",
                        NumberLesson = 5
                    }
                }
            });
        db.SaveChanges();
        return db;
    }

    internal static IMapper CreateMapper()
    {
        var mapper = new MapperConfiguration(config =>
        {
            config.AddProfile(new ScheduleDlhDtoMapperProfile());
            config.AddProfile(new ScheduleDlDtoMapperProfile());
        });
        return mapper.CreateMapper();
    }
}