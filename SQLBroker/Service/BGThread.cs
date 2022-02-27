using SQLBroker.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace SQLBroker.Service
{
    public class BGThread
    {
        public CancellationTokenSource _cts;

        public void Run()
        {
            var aThread = new Thread(TaskLoop);
            aThread.IsBackground = true;
            aThread.Priority = ThreadPriority.BelowNormal;  // 避免此背景工作拖慢 ASP.NET 處理 HTTP 請求.
            aThread.Start();
            _cts = new CancellationTokenSource();
        }
        private void TaskLoop()
        {
            var i = 0;
            while (!_cts.Token.IsCancellationRequested)
            {
                i++;
                MyHub.TestMessage();
                SpinWait.SpinUntil(() => false, 500);
                if (i == 5)
                {
                    _cts.Cancel();
                }
            }
        }
    }
}