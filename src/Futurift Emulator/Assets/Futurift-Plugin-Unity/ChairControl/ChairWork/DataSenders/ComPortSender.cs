﻿using Assets.Plugins.UnityChairPlugin.ChairControl.ChairWork.Options;
using System.IO.Ports;

namespace Assets.Plugins.UnityChairPlugin.ChairControl.ChairWork.DataSenders
{
    internal class ComPortSender : IDataSender
    {
        private readonly SerialPort port;
        public bool IsConnected => port.IsOpen;

        public ComPortSender(ComPortOptions options)
        {
            port = new SerialPort()
            {
                BaudRate = 115200,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One,
                ReadBufferSize = 4096,
                WriteBufferSize = 4096,
                ReadTimeout = 500,
                PortName = $"COM{options.ComPort}",
            };
        }

        public void SendData(byte[] data)
        {
            port.Write(data, 0, data.Length);
        }

        public void Start()
        {
            port.Open();
        }

        public void Stop()
        {
            port.Close();
        }
    }
}