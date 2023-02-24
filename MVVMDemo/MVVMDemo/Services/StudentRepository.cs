using MVVMDemo.Models; 
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Services
{
    public class StudentRepository : IStudent
    {
        public SQLiteAsyncConnection _database;
        public StudentRepository(string _dbPath)
        {
            _database = new SQLiteAsyncConnection(_dbPath);
            _database.CreateTableAsync<StudentModel>().Wait();
        }
        public async Task<bool> Addstudent(StudentModel student)
        {
            if(student.Id > 0)
            {
                
                await _database.UpdateAsync(student);
            }
            else
            {
                await _database.InsertAsync(student);
            }
            return await Task.FromResult(true);
           
        }

        public async Task<bool> DeleteStudent(int id)
        {
            await _database.DeleteAsync<StudentModel>(id);
            return await Task.FromResult(true);
        }

        public Task<StudentModel> GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentModel>> GetStudents()
        {
          return await _database.Table<StudentModel>().ToListAsync();
            
        }

        public Task<bool> UpdateStudent(StudentModel student)
        {
            throw new NotImplementedException();
        }
    }
}
