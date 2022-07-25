﻿namespace StudentShadow.Models
{
    public class Student
    {
        public int Id { get; set; }

        public int SchoolId { get; set; }
        public virtual School School { get; set; }

        public int GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
