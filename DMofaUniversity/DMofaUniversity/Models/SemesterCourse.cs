using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DMofaUniversity.Models
{
    public class SemesterCourse
    {
        [Display(Name = "Semester :")]
        public int SemesterId { get; set; }
        [Display(Name = "Course :")]
        public int CourseId { get; set; }
        [Display(Name = "Sesson :")]
        public int SessonId { get; set; }
    }
}