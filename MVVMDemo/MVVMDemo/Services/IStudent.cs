using MVVMDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Services
{
    public interface IStudent
    {
        Task<bool> Addstudent(StudentModel student);
        Task<bool> UpdateStudent(StudentModel student);
        Task<bool> DeleteStudent(int id);
        Task<StudentModel>GetStudentById(int id);
        Task<IEnumerable<StudentModel>> GetStudents();
    }
}
