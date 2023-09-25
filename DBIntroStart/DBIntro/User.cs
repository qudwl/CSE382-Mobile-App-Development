using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
namespace DBIntro;

[Table("user")]
public class User
{
    // PrimaryKey is typically numeric 
    [PrimaryKey, AutoIncrement, Column("_id")]
    public int Id { get; set; }

    [Unique]
    public string Username { get; set; }
    public override string ToString()
    {
        return string.Format("{0} ({1})", Username, Id);
    }
}
