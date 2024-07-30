using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schedule.Application.Dto;

[Table("date_lesson_homework")]
public class DateLessonsHomeworkDto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Column("day")]
    public DateTime Day { get; set; }
    public List<LessonHomeworkDto> DataDLH { get; set; }
}

