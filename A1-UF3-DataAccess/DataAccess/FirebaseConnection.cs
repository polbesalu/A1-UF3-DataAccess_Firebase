using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;

namespace A1_UF3_DataAccess.DataAccess
{
    static class FirebaseConnection
    {
        public static FirebaseClient GetFirebaseClient(string url, string secret=null) 
        {
            FirebaseClient firebaseClient = new FirebaseClient(url);
            return firebaseClient;
        }
    }
}
