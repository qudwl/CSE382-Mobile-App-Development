﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LinqContinued;

[Table("manufacturer")]
public class Manufacturer
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [Unique]
    public string Name { get; set; }
    public string Headquarters { get; set; }

}
