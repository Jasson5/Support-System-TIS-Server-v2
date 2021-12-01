﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Attendance : Entity
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AttendanceDate { get; set; }

        public string Note { get; set; }

        [Required]
        public int AttendanceStatus { get; set; }

        public int AttendanceGrade { get; set; }

        public int POVGrade { get; set; }
    }
}