using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Auditores
{
    public interface IFacturacionAuditor
    {

        bool IsDebugHabilitado { get; }
        bool IsInfoHabilitado { get; }
        bool IsWarnHabilitado { get; }
        bool IsErrorHablitado { get; }
        bool IsFatalHabilitado { get; }

        void Debug(string mensaje);
        void Info(string mensaje);
        void Warn(string mensaje);
        void Error(string mensaje);
        void Fatal(string mensaje);

        void Debug(ILogable mensaje);
        void Info(ILogable mensaje);
        void Warn(ILogable mensaje);
        void Error(ILogable mensaje);
        void Fatal(ILogable mensaje);

        void Debug(string mensaje, Exception ex);
        void Info(string mensaje, Exception ex);
        void Warn(string mensaje, Exception ex);
        void Error(string mensaje, Exception ex);
        void Fatal(string mensaje, Exception ex);

        void Debug(ILogable mensaje, Exception ex);
        void Info(ILogable mensaje, Exception ex);
        void Warn(ILogable mensaje, Exception ex);
        void Error(ILogable mensaje, Exception ex);
        void Fatal(ILogable mensaje, Exception ex);

    }
}
