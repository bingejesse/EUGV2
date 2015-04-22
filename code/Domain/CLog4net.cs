using System;
using System.Reflection;

namespace Domain
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public static class CLog4net
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="message"></param>
        public static void LogInfo(object message)
        {
            log.Info(message);
        }

        /// <summary>
        /// 记录BUG
        /// </summary>
        /// <param name="message"></param>
        public static void LogBug(object message)
        {
            log.Debug(message);
        }

        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="message"></param>
        public static void LogError(object message)
        {
            log.Error(message);
        }
    }
}
