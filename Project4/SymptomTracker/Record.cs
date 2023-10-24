using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SymptomTracker
{
    [Table("record")]
    public class Record
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public DateTime timeOfIncident { get; set; }
        public string note { get; set; }
        public int severity { get; set; }
        public Record (DateTime dt, string note, int severity)
        {
            this.timeOfIncident = dt;
            this.note = note;
            this.severity = severity;
        }

        public Record() { }
        [Ignore]
        public Brush Color
        {
            get
            {
                switch (severity)
                {
                    case 1:
                    case 2:
                    case 3:
                        return Brush.Green;
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        return Brush.Orange;
                    case 8:
                    case 9:
                    case 10:
                        return Brush.Red;
                    default:
                        return Brush.Black;
                }
            }
        }

        public override string ToString()
        {
            return $"{timeOfIncident} Severity: {severity} Note: {note}";
        }
    }
}
