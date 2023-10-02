using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqContinued;

internal class DB {
	public static SQLiteConnection conn;
	public static void InitDBConnection() {
		string libFolder = FileSystem.AppDataDirectory;
		string fname = System.IO.Path.Combine(libFolder, "cars.db");

		conn = new SQLiteConnection(fname);
		conn.CreateTable<Manufacturer>();
		conn.CreateTable<Car>();

		conn.DeleteAll<Manufacturer>();
		conn.DeleteAll<Car>();

		conn.Insert(new Manufacturer { Name = "Ford", Headquarters = "Detroit, MI" });
		conn.Insert(new Manufacturer { Name = "GM", Headquarters = "Detroit, MI" });
		conn.Insert(new Manufacturer { Name = "Subaru", Headquarters = "Tokyo, Japan" });
		conn.Insert(new Manufacturer { Name = "BMW", Headquarters = "Munich, Germany" });

		conn.Insert(new Car { Model = "Focus", Make = "Ford", Type = "Car", Cost=20000 });
		conn.Insert(new Car { Model = "Mustang", Make = "Ford", Type = "Car", Cost = 30000 });
		conn.Insert(new Car { Model = "F-150", Make = "Ford", Type = "Truck", Cost = 30000 });
		conn.Insert(new Car { Model = "Cruze", Make = "GM", Type = "Car", Cost = 22000 });
		conn.Insert(new Car { Model = "Camero", Make = "GM", Type = "Car", Cost = 35000 });
		conn.Insert(new Car { Model = "Forester", Make = "Subaru", Type = "SUV", Cost = 32500 });
		conn.Insert(new Car { Model = "i8", Make = "BMW", Type = "Car", Cost = 39000 });
		conn.Insert(new Car { Model = "X5", Make = "BMW", Type = "Car", Cost = 42000 });
	}
}
