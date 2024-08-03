using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schedule.Application.Dto;

[Table("lesson_homework")]
public class LessonHomeworkDto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Column("lesson")]
    public string Lesson { get; set; }
    [Column("homework")]
    public string Homework { get; set; }
    [Column("number_lesson")]
    public int NumberLesson { get; set; }
    [ForeignKey("Id")]
    public Guid DateId { get; set; }
    public DateLessonsHomeworkDto DateLessonsHomework { get; set; }

    public override string ToString()
    {
        var str = "{" +
                  $@"""lesson"" : ""{Lesson}"",
                    ""homework"": ""{Homework}"",
                    ""numberLesson"":""{NumberLesson}""" +
                  "}";
        return str;
    }
}