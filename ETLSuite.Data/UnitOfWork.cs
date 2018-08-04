using ETLSuite.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETLSuite.Data
{
    public interface IUnitOfWork
    {
        IProjectRepository ProjectRepository { get; }
        ILogEntryRepository LogEntryRepository { get; }
        IDbConnectionDefinitionRepository DbConnectionDefinitionRepository { get; }

        int Save();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private ETLDataContext context;
        private ILogEntryRepository logEntryRepository;
        private IProjectRepository projectRepository;
        private IDbConnectionDefinitionRepository dbConnectionDefinitionRepository;

        public UnitOfWork(ETLDataContext context)
        {
            this.context = context;
        }

        public IProjectRepository ProjectRepository
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new ProjectRepository(context);
                return projectRepository;
            }
        }

        public ILogEntryRepository LogEntryRepository
        {
            get
            {
                if (logEntryRepository == null)
                    logEntryRepository = new LogEntryRepository(context);
                return logEntryRepository;
            }
        }

        public IDbConnectionDefinitionRepository DbConnectionDefinitionRepository
        {
            get
            {
                if (dbConnectionDefinitionRepository == null)
                    dbConnectionDefinitionRepository = new DbConnectionDefinitionRepository(context);
                return dbConnectionDefinitionRepository;
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
