using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.Auditores;
using log4net;
using MongoDB.Bson;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Log.Log4Net
{
    public class FacturacioLog4Net : IFacturacionAuditor
    {
        private const string ActionPropertyname = "action";
        private readonly ILog _auditor;

        public FacturacioLog4Net(Type type)
        {
            if (type == null)
            {
                throw new ArgumentException();
            }
            _auditor = LogManager.GetLogger(type);
        }
        public bool IsDebugHabilitado
        {
            get
            {
                return _auditor.IsDebugEnabled;
            }
        }

        public bool IsInfoHabilitado
        {
            get
            {
                return _auditor.IsInfoEnabled;
            }
        }

        public bool IsWarnHabilitado
        {
            get
            {
                return _auditor.IsWarnEnabled;
            }
        }

        public bool IsErrorHablitado
        {
            get
            {
                return _auditor.IsErrorEnabled;
            }
        }

        public bool IsFatalHabilitado
        {
            get
            {
                return _auditor.IsFatalEnabled;
            }
        }

        public void Debug(string mensaje)
        {
            Debug(new MensajeLogable { Mensaje = mensaje });
        }

        public void Info(string mensaje)
        {
            Info(new MensajeLogable { Mensaje = mensaje });
        }

        public void Warn(string mensaje)
        {
            Warn(new MensajeLogable { Mensaje = mensaje });
        }

        public void Error(string mensaje)
        {
            Error(new MensajeLogable { Mensaje = mensaje });
        }

        public void Fatal(string mensaje)
        {
            Fatal(new MensajeLogable { Mensaje = mensaje });
        }

        public void Debug(ILogable mensaje)
        {
            var bsonDoc = mensaje.ToBsonDocument();
            ThreadContext.Properties[ActionPropertyname] = bsonDoc;
            _auditor.Debug(bsonDoc);
        }

        public void Info(ILogable mensaje)
        {
            var bsonDoc = mensaje.ToBsonDocument();
            ThreadContext.Properties[ActionPropertyname] = bsonDoc;
            _auditor.Info(bsonDoc);
        }

        public void Warn(ILogable mensaje)
        {
            var bsonDoc = mensaje.ToBsonDocument();
            ThreadContext.Properties[ActionPropertyname] = bsonDoc;
            _auditor.Warn(bsonDoc);
        }

        public void Error(ILogable mensaje)
        {
            var bsonDoc = mensaje.ToBsonDocument();
            ThreadContext.Properties[ActionPropertyname] = bsonDoc;
            _auditor.Error(bsonDoc);
        }

        public void Fatal(ILogable mensaje)
        {
            var bsonDoc = mensaje.ToBsonDocument();
            ThreadContext.Properties[ActionPropertyname] = bsonDoc;
            _auditor.Fatal(bsonDoc);
        }

        public void Debug(string mensaje, Exception ex)
        {
            Debug(new MensajeLogable { Mensaje = mensaje }, ex);
        }

        public void Info(string mensaje, Exception ex)
        {
            Info(new MensajeLogable { Mensaje = mensaje }, ex);
        }

        public void Warn(string mensaje, Exception ex)
        {
            Warn(new MensajeLogable { Mensaje = mensaje }, ex);
        }

        public void Error(string mensaje, Exception ex)
        {
            Error(new MensajeLogable { Mensaje = mensaje }, ex);
        }

        public void Fatal(string mensaje, Exception ex)
        {
            Fatal(new MensajeLogable { Mensaje = mensaje }, ex);
        }

        public void Debug(ILogable mensaje, Exception ex)
        {
            var log = new ExcepcionLogable
            {
                Mensaje = mensaje.mensaje,
                StackTrace = (ex != null ? string.Format("{0}\n{1}", ex.Message, ex.StackTrace) : string.Empty)
            };
            var bsonDoc = log.ToBsonDocument();
            ThreadContext.Properties[ActionPropertyname] = bsonDoc;
            _auditor.Debug(bsonDoc);
        }

        public void Info(ILogable mensaje, Exception ex)
        {
            var log = new ExcepcionLogable
            {
                Mensaje = mensaje.mensaje,
                StackTrace = (ex != null ? string.Format("{0}\n{1}", ex.Message, ex.StackTrace) : string.Empty)
            };
            var bsonDoc = log.ToBsonDocument();
            ThreadContext.Properties[ActionPropertyname] = bsonDoc;
            _auditor.Info(bsonDoc);
        }

        public void Warn(ILogable mensaje, Exception ex)
        {
            var log = new ExcepcionLogable
            {
                Mensaje = mensaje.mensaje,
                StackTrace = (ex != null ? string.Format("{0}\n{1}", ex.Message, ex.StackTrace) : string.Empty)
            };
            var bsonDoc = log.ToBsonDocument();
            ThreadContext.Properties[ActionPropertyname] = bsonDoc;
            _auditor.Warn(bsonDoc);
        }

        public void Error(ILogable mensaje, Exception ex)
        {
            var log = new ExcepcionLogable
            {
                Mensaje = mensaje.mensaje,
                StackTrace = (ex != null ? string.Format("{0}\n{1}", ex.Message, ex.StackTrace) : string.Empty)
            };
            var bsonDoc = log.ToBsonDocument();
            ThreadContext.Properties[ActionPropertyname] = bsonDoc;
            _auditor.Error(bsonDoc);
        }

        public void Fatal(ILogable mensaje, Exception ex)
        {
            var log = new ExcepcionLogable
            {
                Mensaje = mensaje.mensaje,
                StackTrace = (ex != null ? string.Format("{0}\n{1}", ex.Message, ex.StackTrace) : string.Empty)
            };
            var bsonDoc = log.ToBsonDocument();
            ThreadContext.Properties[ActionPropertyname] = bsonDoc;
            _auditor.Fatal(bsonDoc);
        }
    }
}
