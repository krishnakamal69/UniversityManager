using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DMofaUniversity.Models;

namespace DMofaUniversity.DataAccessLayer
{
    public class StudentOfaSemesterGateway
    {
        string conString = WebConfigurationManager.ConnectionStrings["commonCon"].ToString();

        public List<tblStudent> GetStudentOfaSemester(SemesterCourse semesterCourse)
        {
            List<tblStudent> listOfStudent=new List<tblStudent>();
            using (SqlConnection conn=new SqlConnection(conString))
            {
                SqlCommand comm = new SqlCommand("select tblStudents.StudentID,tblStudents.Name,tblStudents.Roll from tblStudents" +
                                                 " where tblStudents.SemisterID='"+semesterCourse.SemesterId+"' and tblStudents.SessonID='"+semesterCourse.SessonId+"'", conn);

                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        tblStudent student=new tblStudent();
                        student.StudentID = Convert.ToInt16(reader[0]);
                        student.Name = reader[1].ToString();
                        student.Roll = reader[2].ToString();
                        listOfStudent.Add(student);
                    }
                    reader.Close();
                }
            }
            return listOfStudent;
        }
    }
}