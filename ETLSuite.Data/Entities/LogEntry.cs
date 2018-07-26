using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ETLSuite.Data.Entities
{
    [Table("LogEntries")]
    public class LogEntry : EntityBase
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public LogLevel Level { get; set; }
    }
}
