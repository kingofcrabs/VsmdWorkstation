﻿using System;
using System.Windows.Forms;
using VsmdWorkstation.Controls;

namespace VsmdWorkstation
{
    public partial class GeneralSettingFrm : Form
    {
        public GeneralSettingFrm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GeneralSettingMeta meta = GeneralSettings.GetInstance().GetSettingMeta();
            meta.DripInterval = (int)numDripInter.Value;
            meta.MoveSpeed = float.Parse(txtMoveSpd.Text.Trim());
            meta.AutoConnect = ckbAutoConnect.Checked;
            meta.OutputCommandLog = ckbEnableCmdLog.Checked;
            meta.OutputStsCommandLog = ckbEnableStsCmdLog.Checked;
            bool retVal = GeneralSettings.GetInstance().Save();
            if (retVal)
            {
                StatusBar.DisplayMessage(MessageType.Info, "设置成功！");
                if (VsmdController.GetVsmdController().IsInitialized())
                {
                    VsmdController.GetVsmdController().SetOutputCommandLogFlag(meta.OutputCommandLog);
                }
                
                this.Close();
            }
            else
            {
                StatusBar.DisplayMessage(MessageType.Error, "设置失败！");
            }
        }

        private void GeneralSettingFrm_Load(object sender, EventArgs e)
        {
            InitFormData();
#if DEBUG
            ckbEnableCmdLog.Visible = true;
            ckbEnableStsCmdLog.Visible = true;
#endif
        }

        private void InitFormData()
        {
            GeneralSettingMeta meta = GeneralSettings.GetInstance().GetSettingMeta();
            numDripInter.Value = (decimal)meta.DripInterval;

            txtMoveSpd.Text = meta.MoveSpeed.ToString();
            ckbAutoConnect.Checked = meta.AutoConnect;
            ckbEnableCmdLog.Checked = meta.OutputCommandLog;
            ckbEnableStsCmdLog.Checked = meta.OutputStsCommandLog;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
