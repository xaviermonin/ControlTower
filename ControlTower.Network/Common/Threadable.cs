using System;
using System.Threading;

namespace ControlTower.Network.Common
{
    public class Threadable
    {
        public void Start()
        {
            if (IsRunning)
                return;

            StopAsked = false;

            OnStarting();

            _thread = new Thread(RunThread);
            _thread.Start();
        }

        public void Stop()
        {
            if (!IsRunning)
                return;

            OnStopping();

            StopAsked = true;
            _thread.Join(WaitingThread);

            if (_thread.IsAlive)
                _thread.Abort();
        }

        private void RunThread(object obj)
        {
            IsRunning = true;
            StatusChanged?.BeginInvoke(this, new EventArgs(), null, null);
            try
            {
                Run();
            }
            finally
            {
                IsRunning = false;
                StatusChanged?.BeginInvoke(this, new EventArgs(), null, null);
            }
        }

        protected virtual void Run()
        {

        }

        protected virtual void OnStarting()
        {

        }

        protected virtual void OnStopping()
        {

        }

        public delegate void ThreadStatusHandler(object sender, EventArgs eventArgs);
        public event ThreadStatusHandler StatusChanged;

        public bool IsRunning { get; private set; }

        protected int WaitingThread { get; set; } = 1000;
        protected bool StopAsked { get => stopAsked; set => stopAsked = value; }

        private volatile bool stopAsked;
        private Thread _thread;
    }
}
