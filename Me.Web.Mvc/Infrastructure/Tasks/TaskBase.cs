namespace Me.Web.Mvc.Infrastructure.Tasks
{
    #region using

    using System;

    using log4net;

    #endregion
    
    public abstract class TaskBase : ITask
    {
        protected static readonly ILog Log = LogManager.GetLogger(typeof(TaskBase));

        public DateTime ExecutionTime { get; private set; }

        protected TaskBase(DateTime executionTime)
        {
            ExecutionTime = executionTime;
        }

        public abstract void Execute();
    }
}