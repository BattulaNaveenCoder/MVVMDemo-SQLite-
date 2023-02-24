using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMDemo.Models
{
    public class StudentModel
    {
        [PrimaryKey,AutoIncrement]
      public int Id { get; set; }
      public string Name { get; set; }
      public int? RollNumber { get; set; }
      public string Gender { get; set; }
      public string Address { get; set; }

    }
}
