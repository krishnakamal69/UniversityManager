﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DMofaUniversity.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DeptMofaUniversityConn : DbContext
    {
        public DeptMofaUniversityConn()
            : base("name=DeptMofaUniversityConn")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblBatch> tblBatches { get; set; }
        public virtual DbSet<tblCourse> tblCourses { get; set; }
        public virtual DbSet<tblMidResult> tblMidResults { get; set; }
        public virtual DbSet<tblResource> tblResources { get; set; }
        public virtual DbSet<tblRole> tblRoles { get; set; }
        public virtual DbSet<tblSemester> tblSemesters { get; set; }
        public virtual DbSet<tblSesson> tblSessons { get; set; }
        public virtual DbSet<tblStudent> tblStudents { get; set; }
        public virtual DbSet<tblTeacherCourse> tblTeacherCourses { get; set; }
        public virtual DbSet<tblTeacher> tblTeachers { get; set; }
        public virtual DbSet<tblTheoryResult> tblTheoryResults { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
    }
}
