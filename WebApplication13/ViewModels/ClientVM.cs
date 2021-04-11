using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication13.Tables
{
    public class ClientVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public int IdClient { get; set; }

        public long Telephone { get; set; }  

        public string fullName
        {
            get
            {
                return String.Join(' ', LastName, FirstName, Patronymic);
            }
        }

    }
}
