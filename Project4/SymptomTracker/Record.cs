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

        public Record()
        {
            
        }

        public override string ToString()
        {
            return $"{timeOfIncident} Severity: {severity} Note: {note}";
        }
    }
}
