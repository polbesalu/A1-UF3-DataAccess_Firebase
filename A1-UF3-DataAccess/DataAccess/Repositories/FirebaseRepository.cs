using A1_UF3_DataAccess.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace A1_UF3_DataAccess.DataAccess.Repositories
{
    internal class FirebaseRepository : IFirebaseRepository
    {
        FirebaseClient Firebase { get; set; }
        public FirebaseRepository() 
        {
            Firebase = FirebaseConnection.GetFirebaseClient("https://provadam-15e08-default-rtdb.europe-west1.firebasedatabase.app/");
        }
        public async Task<bool> AddStudent(Student student)
        {
            await Firebase.Child("Students").PostAsync(student);
            return await Firebase.Child("Students").Child($"{student.FullName}").OnceSingleAsync<Student>() != null;
        }

        public async Task<bool> ExistsStudent(string name)
        {
            return await Firebase.Child("Students").Child($"{name}").OnceSingleAsync<Student>() != null;
        }

        public async Task<Student> GetStudent(string name)
        {
            return await Firebase.Child("Students").Child($"{name}").OnceSingleAsync<Student>();
        }

        public async Task<IReadOnlyCollection<FirebaseObject<Student>>> GetStudents()
        {
            var students = await Firebase.Child("Students").OnceAsync<Student>();
            return students;
        }

        public async Task<bool> RemoveStudent(string student)
        {
            await Firebase.Child("Students").Child(student).DeleteAsync();
            return await Firebase.Child("Students").Child($"{student}").OnceSingleAsync<Student>() == null;
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            await Firebase
                .Child("Students")
                .Child(student.FullName)
                .PutAsync(student);
            return await Firebase.Child("Students").Child($"{student.FullName}").OnceSingleAsync<Student>() != null;

        }
    }
}
