using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1_UF3_DataAccess.DataAccess.Repositories
{
    internal static class FirebaseFactory
    {
        public static FirebaseRepository GetFirebaseRepository()
        {
            return new FirebaseRepository();
        }
    }
}
