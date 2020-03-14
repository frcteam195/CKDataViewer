using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CKDataToolbox.Utilities
{
    public class LogItemLabel : Label
    {
        public event EventHandler EnableLoggingEvent;
        protected virtual void OnEnableLogging(EventArgs e)
        {
            EventHandler handler = EnableLoggingEvent;
            handler?.Invoke(this, e);
        }
        public event EventHandler DisableLoggingEvent;
        protected virtual void OnDisableLogging(EventArgs e)
        {
            EventHandler handler = DisableLoggingEvent;
            handler?.Invoke(this, e);
        }

        public bool ChartEnabled { get; private set; }

        public LogItemLabel(int tag, EventHandler enableLoggingEvent, EventHandler disableLoggingEvent) : base()
        {
            AutoSize = true;
            ChartEnabled = false;
            Click += clickHandler;
            EnableLoggingEvent += enableLoggingEvent;
            DisableLoggingEvent += disableLoggingEvent;
            Padding = new Padding(0, 2, 0, 2);
            Tag = tag;
        }

        public void DisableChart()
        {
            if (ChartEnabled)
                clickHandler(null, EventArgs.Empty);
        }

        private void clickHandler(object sender, EventArgs e)
        {
            ChartEnabled = !ChartEnabled;

            if (ChartEnabled) {
                Font = new Font(Font, FontStyle.Bold);
                OnEnableLogging(e);
            } else
            {
                Font = new Font(Font, FontStyle.Regular);
                OnDisableLogging(e);
            }   
        }
    }
}
