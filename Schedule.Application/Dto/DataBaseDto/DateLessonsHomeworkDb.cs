using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schedule.Application.Dto;

[Table("date_lesson_homework")]
public class DateLessonsHomeworkDb
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Column("day")]
    public DateTime Day { get; set; }
    public List<LessonHomeworkDb> DataDlh { get; set; }
}

