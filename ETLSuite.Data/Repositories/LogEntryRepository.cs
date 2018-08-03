using ETLSuite.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETLSuite.Data.Repositories
{
    public interface ILogEntryRepository
    {
        IQueryable<LogEntry> Get();
        void Insert(LogEntry project);
        void Delete(int id);
        void Update(LogEntry newValues);
    }
    public class LogEntryRepository : RepositoryBase<LogEntry>, ILogEntryRepository
    {
        public LogEntryRepository(ETLDataContext context) : base(context)
        {
        }
    }
}
