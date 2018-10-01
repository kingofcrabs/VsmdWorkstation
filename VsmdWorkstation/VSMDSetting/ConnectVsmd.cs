﻿using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace VsmdWorkstation
{
    public delegate void DelInitVsmdConnectionCB(InitResult initRet);
    public partial class ConnectVsmd : Form
    {
        private DelInitVsmdConnectionCB m_initCB;
        private bool m_isConnecting;

        public bool IsConnected { get; set; }
        public bool IsClosed { get; set; }
        
        public ConnectVsmd(DelInitVsmdConnectionCB callback = null)
        {
            InitializeComponent();
            m_initCB = callback;
        }

        private void ConnectVsmd_Load(object sender, EventArgs e)
        {
            if (VsmdController.GetVsmdController().IsInitialized())
            {
                lblCurConn.Visible = true;
                lblCurInfo.Text = VsmdController.GetVsmdController().GetPort() + ", " + VsmdController.GetVsmdController().GetBaudrate();
                lblCurInfo.Visible = true;
            }
            else
            {
                lblCurConn.Visible = false;
                lblCurInfo.Visible = false;
            }
            cmbPort.Items.AddRange(SerialPort.GetPortNames());
            cmbPumpPort.Items.AddRange(SerialPort.GetPortNames());
            if (cmbPort.Items.Count > 0)
            {
                cmbPort.SelectedIndex = 0;
                cmbPumpPort.SelectedIndex = 0;
            }
            cmbBaudrate.SelectedIndex = 2;
            IsClosed = false;
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (m_isConnecting)
            {
                return;
            }
            m_isConnecting = true;
            InitResult vsmdRet = await VsmdController.GetVsmdController().Init(cmbPort.SelectedItem.ToString(), int.Parse(cmbBaudrate.SelectedItem.ToString()));
            InitResult pumpRet = PumpController.GetPumpController().Init(cmbPumpPort.SelectedItem.ToString());
            if (m_initCB != null)
            {
                InitResult connectRet = new InitResult();
                connectRet.IsSuccess = vsmdRet.IsSuccess && pumpRet.IsSuccess;
                connectRet.ErrorMsg = vsmdRet.IsSuccess ? pumpRet.ErrorMsg : vsmdRet.ErrorMsg;
                m_initCB(connectRet);
                m_isConnecting = false;
            }
            if (vsmdRet.IsSuccess && pumpRet.IsSuccess)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConnectVsmd_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsClosed = true;
        }
    }
}
