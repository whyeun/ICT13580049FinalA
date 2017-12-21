using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ICT13580049FinalA.Models
{
    public class Product
    {
   
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string Name { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string Lastname { get; set; }

        public int Age { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public int Phone { get; set; }

        [NotNull]
        public string Address { get; set; }
        public string Status { get; set; }
        public int Children { get; set; }
        public string Saraly { get; set; }
        public string Email { get; set; }


    }
}
