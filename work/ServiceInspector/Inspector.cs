using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace Finandina.TPaga.WCFServices.ServiceInspector
{
    class Inspector : IDispatchMessageInspector
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            Log("Request", request.CreateBufferedCopy(int.MaxValue));
            /*
            var buffer = request.CreateBufferedCopy(int.MaxValue);
            request = buffer.CreateMessage();
            var msg = buffer.CreateMessage();
            var reader = msg.GetReaderAtBodyContents();
            log.Info(reader.ReadInnerXml());
            */
            //Log(request.CreateBufferedCopy(int.MaxValue));
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            /*
            var buffer = reply.CreateBufferedCopy(int.MaxValue);
            reply = buffer.CreateMessage();
            var msg = buffer.CreateMessage();
            log.Info(msg);
            */
            reply = Log("Response", reply.CreateBufferedCopy(int.MaxValue));
        }

        private Message Log(string action, MessageBuffer buffer)
        {
            var result = buffer.CreateMessage();
            var msg = buffer.CreateMessage();

            var body = string.Empty;
            var url = string.Empty;
            var method = string.Empty;
            /*
            if (!msg.IsEmpty) { 
                var reader = msg.GetReaderAtBodyContents();
                body = reader.ReadInnerXml();
            }
            if (msg.Headers.To != null && !string.IsNullOrEmpty(msg.Headers.To.AbsolutePath))
            {
                url = msg.Headers.To.AbsolutePath;
            }
            if (string.IsNullOrEmpty(msg.Headers.Action))
            {
                method = msg.Headers.Action;
            }
            */
            log.Info(String.Format("[{0}] Service: {1}, Method: {2}, Body \r\n{3}", action, url, method, body));

            //log(msg.Headers.To.AbsolutePath);
            return result;
        }
    }
}