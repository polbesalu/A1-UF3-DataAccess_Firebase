using A1_UF3_DataAccess.DataAccess.Repositories;
using A1_UF3_DataAccess.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1_UF3_DataAccess.Domain
{
    internal class FirebaseDomain : IFirebaseDomain
    {
        public IFirebaseRepository FirebaseRepository { get; set; }
        public FirebaseDomain() 
        {
            FirebaseRepository = FirebaseFactory.GetFirebaseRepository();
        }
        public async Task<bool> AddStudent(Student student)
        {
            return await FirebaseRepository.AddStudent(student);
        }
        public async Task<bool> ExistsStudent(string name)
        {
            return await FirebaseRepository.ExistsStudent(name);
        }

        public async Task<Student> GetStudent(string name)
        {
            return await FirebaseRepository.GetStudent(name);
        }

        public async Task<IReadOnlyCollection<FirebaseObject<Student>>> GetStudents()
        {
            return await FirebaseRepository.GetStudents();
        }

        public async Task<bool> RemoveStudent(string student)
        {
            return await FirebaseRepository.RemoveStudent(student);
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            return await FirebaseRepository.UpdateStudent(student);
        }
    }
}
