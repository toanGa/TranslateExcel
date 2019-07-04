using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace NT
{
    
    class SerialPortDetecter
    {
        public int BaudRate = 115200;
        // Resend in milisecond
        public int ResendTime = 100;

        private ManualResetEvent RespondEvent = new ManualResetEvent(false);
        private string PingStr;
        /// <summary>
        /// Auto detect serial port
        /// </summary>
        /// <param name="ping"></param>
        /// <param name="respond"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public string DetectPort(string ping, string respond, int timeout)
        {
            string[] ports = SerialPort.GetPortNames();
            string portName = "";

            SerialPort PortDetecter;
            bool waitStatus;
            DateTime dtSend;

            PingStr = respond;
            foreach (string port in ports)
            {
                PortDetecter = new SerialPort();
                PortDetecter.PortName = port;
                PortDetecter.BaudRate = BaudRate;
                PortDetecter.DataReceived += PortDetecter_DataReceived;

                dtSend = DateTime.Now;

                try
                {
                    TraceLog("Try open: " + port);
                    PortDetecter.Open();
                    
                    while((DateTime.Now - dtSend).TotalMilliseconds < timeout)
                    {
                        PortDetecter.Write(ping);
                        waitStatus = RespondEvent.WaitOne(ResendTime);
                        if (waitStatus)
                        {
                            portName = PortDetecter.PortName;
                        }
                        
                        if (!string.IsNullOrEmpty(portName))
                        {
                            PortDetecter.Dispose();
                            goto exit_func;
                        }
                    }

                    try
                    {
                        PortDetecter.Dispose();
                    }
                    catch (Exception ex)
                    {

                    }
                }
                catch
                {

                }
            }
exit_func:
            return portName;
        }

        private void PortDetecter_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort comport = sender as SerialPort;
            if (comport.IsOpen)
            {
                string content = comport.ReadExisting();
                if(PingStr == content)
                {
                    RespondEvent.Set();
                }
            }
        }

        void TraceLog(string s)
        {
            Console.WriteLine(s);
        }
    }
}
