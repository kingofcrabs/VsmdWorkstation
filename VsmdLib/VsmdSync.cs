﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VsmdLib
{
    public class VsmdConstVars
    {
        public const int Default_Wait_Interval = 10;
        public const int Default_Wait_Count = 50;
    }
    /// <summary>Vsmd Class</summary>
    public class VsmdSync
    {
        /// <summary>device list</summary>
        private List<VsmdInfoSync> objList = new List<VsmdInfoSync>();
        /// <summary>serial port object</summary>
        private SerialPort com_port = new SerialPort();

        /// <summary>serial port recieve thread</summary>
        private Thread serial_port_recieve_thread;
        /// <summary>
        /// 
        /// </summary>
        private byte[] recieveBuffer = new byte[1024];
        private VsmdTimer waitResTimer = new VsmdTimer(1000L);

        private int recieveBufferSize;
        private bool m_isWaitingResponse;
        private bool m_outputCmdLog;
        private bool m_outputStsCmdLog;

        public VsmdSync()
        {
            m_outputCmdLog = false;
            m_outputStsCmdLog = false;
        }
        public bool OutputCommandLog
        {
            get
            {
                return m_outputCmdLog;
            }
            set
            {
                m_outputCmdLog = value;
            }
        }
        public bool OutputStsCommandLog
        {
            get
            {
                return m_outputStsCmdLog;
            }
            set
            {
                m_outputStsCmdLog = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public SerialPort comPort
        {
            get
            {
                return this.com_port;
            }
        }

        /// <summary>open serial port</summary>
        /// <param name="port"></param>
        /// <param name="baudrate"></param>
        /// <returns></returns>
        public bool openSerialPort(string port, int baudrate)
        {
            if (baudrate < 2400 || baudrate > 921600)
                return false;
            this.comPort.PortName = port;
            this.comPort.BaudRate = baudrate;
            this.comPort.Parity = Parity.None;
            this.comPort.DataBits = 8;
            this.comPort.StopBits = StopBits.One;
            try
            {
                this.comPort.Open();
            }
            catch
            {
                return false;
            }

            this.isSerialPortRecieveThreadRunning = true;
            this.serial_port_recieve_thread = new Thread(new ParameterizedThreadStart(serial_port_recieve_thread_process));
            this.serial_port_recieve_thread.Priority = ThreadPriority.Highest;
            this.serial_port_recieve_thread.Start((object)this);

            return true;
        }

        /// <summary>close serial port</summary>
        /// <returns></returns>
        public bool closeSerialPort()
        {
            bool flag = true;
            this.isSerialPortRecieveThreadRunning = false;
            try
            {
                this.comPort.DiscardInBuffer();
                this.comPort.DiscardOutBuffer();
                this.comPort.Close();
            }
            catch
            {
                flag = this.comPort.IsOpen && false;
            }
            return flag;
        }

        private bool isSerialPortRecieveThreadRunning { get; set; }

        /// <summary>serial port recieve process</summary>
        private void serialPortRecieveProcess()
        {
            while (this.isSerialPortRecieveThreadRunning)
            {
                try
                {
                    if (this.comPort.BytesToRead > 0)
                    {
                        byte[] buffer = new byte[this.comPort.BytesToRead];
                        this.comPort.Read(buffer, 0, buffer.Length);
                        foreach (byte data in buffer)
                            this.parse(data);
                    }
                }
                catch
                {
                }
                Thread.Sleep(0);
            }
        }

        /// <summary>parse response data</summary>
        /// <param name="data"></param>
        private void parse(byte data)
        {
            switch (data)
            {
                case 254:
                    if (this.recieveBuffer[0] == byte.MaxValue)
                    {
                        this.recieveBuffer[this.recieveBufferSize] = data;
                        ++this.recieveBufferSize;
                        byte[] res = new byte[this.recieveBufferSize];
                        Buffer.BlockCopy((Array)this.recieveBuffer, 0, (Array)res, 0, this.recieveBufferSize);
                        if (this.bcc_checksum(res))
                        {
                            for (int index = 0; index < this.objList.Count; ++index)
                            {
                                if (this.objList[index].Cid == (int)res[1])
                                {
                                    this.objList[index].parse(res);
                                    OutputLog(res);
                                    break;
                                }
                            }
                        }
                        this.m_isWaitingResponse = false;
                        break;
                    }
                    goto default;
                case byte.MaxValue:
                    this.recieveBufferSize = 0;
                    this.recieveBuffer[this.recieveBufferSize] = data;
                    ++this.recieveBufferSize;
                    break;
                default:
                    if (this.recieveBuffer[0] == byte.MaxValue)
                    {
                        this.recieveBuffer[this.recieveBufferSize] = data;
                        ++this.recieveBufferSize;
                        break;
                    }
                    break;
            }
            if (this.recieveBufferSize < 3)
                return;
            this.waitResTimer.start(2000000L);
        }

        /// <summary>bcc check</summary>
        /// <param name="res"></param>
        /// <returns></returns>
        private bool bcc_checksum(byte[] res)
        {
            byte num = (byte)((uint)(byte)((uint)res[res.Length - 3] << 7) | (uint)res[res.Length - 2]);
            for (int index = 1; index < res.Length - 3; ++index)
                num ^= res[index];
            return num == (byte)0;
        }

        /// <summary>serial port recieve thread process</summary>
        /// <param name="obj"></param>
        private void serial_port_recieve_thread_process(object obj)
        {
            ((VsmdSync)obj).serialPortRecieveProcess();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public VsmdInfoSync createVsmdInfo(int cid)
        {
            VsmdInfoSync vsmdInfo = new VsmdInfoSync(cid, this);
            vsmdInfo.comPort = this.comPort;
            this.objList.Add(vsmdInfo);
            return vsmdInfo;
        }

        /// <summary>remove VsmdInfo object</summary>
        /// <param name="info"></param>
        public void removeVsmdInfo(VsmdInfoSync info)
        {
            this.objList.Remove(info);
        }
        public bool SendCommand(string cmd)
        {
            if (m_isWaitingResponse)
            {
                OutputLog("send command fail since last command didn't finish, " + cmd);
                return false;
            }
            this.comPort.Write(cmd);
            OutputLog("**** send command: " + cmd);
            m_isWaitingResponse = true;
            return true;
        }
        public async Task<bool> SendCommandSync(string cmd, int waitInterval = VsmdConstVars.Default_Wait_Interval, int waitCount = VsmdConstVars.Default_Wait_Count)
        {
            bool returnVal = true;
            this.comPort.Write(cmd);
            OutputLog("**** send command sync: " + cmd);
            m_isWaitingResponse = true;
            returnVal = await WaitResponse(waitInterval, waitCount);
            if (!returnVal)
            {
                m_isWaitingResponse = false;
                OutputLog("fail to wait response for command: " + cmd);
            }
            else
            {
                OutputLog("receive response successfully.");
            }
            return returnVal;
        }
        public async Task<bool> WaitResponse(int waitInterval = VsmdConstVars.Default_Wait_Interval, int waitCount = VsmdConstVars.Default_Wait_Count)
        {
            int curWaitCnt = 0;
            while(curWaitCnt < waitCount)
            {
                if (!m_isWaitingResponse)
                {
                    break;
                }
                curWaitCnt++;
                if (m_outputStsCmdLog)
                {
                    OutputLog("wait for response, try " + curWaitCnt.ToString());
                }
                await Task.Delay(waitInterval);
            }

            return curWaitCnt < waitCount;
        }

        public void Stop()
        {
            m_isWaitingResponse = false;
        }

        public void OutputLog(string log)
        {
            if (!m_outputCmdLog)
            {
                return;
            }
            string prefix = "VsmdWorkstation - ";
            if(log[log.Length - 1] == '\n')
            {
                Debugger.Log(0, "", prefix + log);
            }
            else
            {
                Debugger.Log(0, "", prefix + log + '\n');
            }
        }
        public void OutputLog(byte[] log)
        {
            if (!m_outputCmdLog)
            {
                return;
            }
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("receive response: ");
            Array.ForEach(log, (val) =>
            {
                strBuilder.Append(val.ToString());
                strBuilder.Append(' ');
            });
            OutputLog(strBuilder.ToString());
        }
    }
}
