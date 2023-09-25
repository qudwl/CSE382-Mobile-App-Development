using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
namespace DBIntro
{
    [Table("person")]
    internal class Person
    {
        [PrimaryKey, AutoIncrement, Column("_id")] 
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        [Unique]
        public string SSN { get; set; }
        public int Income { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1}) {2} {3} ${4}", Name, Id, DOB, SSN, Income);
        }
    }
}
