using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LinqContinued;

[Table("car")]
public class Car
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
	public string Type { get; set; }
    public int Cost { get; set; }
}