﻿using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VsmdLib;
using VsmdWorkstation.Controls;

namespace VsmdWorkstation
{
    public partial class VsmdSettingFrm : Form
    {

        public VsmdSettingFrm()
        {
            InitializeComponent();
        }

        private void VsmdSettingFrm_Load(object sender, EventArgs e)
        {
            InitAxises();
        }
        private void InitAxises()
        {
            if (!VsmdController.GetVsmdController().IsInitialized())
            {
                StatusBar.DisplayMessage(MessageType.Error, "设备未连接！");
                DisableAllControls();
                return;
            }
            VsmdInfo axisX = VsmdController.GetVsmdController().GetAxis(VsmdAxis.X);
            txtCidX.Text = axisX.Cid.ToString();
            txtPosX.Text = axisX.curPos.ToString();
            txtSpeedX.Text = axisX.curSpd.ToString();
            ckbAutoUpdateX.Checked = axisX.flgAutoUpdate;


            VsmdInfo axisY = VsmdController.GetVsmdController().GetAxis(VsmdAxis.Y);
            txtCidY.Text = axisY.Cid.ToString();
            txtPosY.Text = axisY.curPos.ToString();
            txtSpeedY.Text = axisY.curSpd.ToString();
            ckbAutoUpdateY.Checked = axisY.flgAutoUpdate;

            VsmdInfo axisZ = VsmdController.GetVsmdController().GetAxis(VsmdAxis.Z);
            txtCidZ.Text = axisZ.Cid.ToString();
            txtPosZ.Text = axisZ.curPos.ToString();
            txtSpeedZ.Text = axisZ.curSpd.ToString();
            ckbAutoUpdateZ.Checked = axisZ.flgAutoUpdate;
        }
        private void DisableAllControls()
        {
            foreach(Control ctrl in this.Controls)
            {
                if(ctrl is GroupBox)
                {
                    foreach (Control ctrl2 in ctrl.Controls)
                    {
                        if (ctrl2 is Button ||
                            ctrl2 is TextBox ||
                            ctrl2 is CheckBox)
                        {
                            ctrl2.Enabled = false;
                        }
                    }
                }
                
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        private bool CheckTextBoxValue(TextBox box, out int val)
        {
            return int.TryParse(box.Text.Trim(), out val);

        }
        private void btnPosX_Click(object sender, EventArgs e)
        {
            PosImpl(VsmdAxis.X, txtPosX);
        }
        private void btnPosY_Click(object sender, EventArgs e)
        {
            PosImpl(VsmdAxis.Y, txtPosY);
        }

        private void btnPosZ_Click(object sender, EventArgs e)
        {
            PosImpl(VsmdAxis.Z, txtPosZ);
        }
        private void PosImpl(VsmdAxis axis, TextBoxEx boxCtrl)
        {
            VsmdController.GetVsmdController().Pos(axis, int.Parse(boxCtrl.Text.Trim()));
        }

        private void btnEnaX_Click(object sender, EventArgs e)
        {
            EnaImpl(VsmdAxis.X);
        }

        private void btnEnaY_Click(object sender, EventArgs e)
        {
            EnaImpl(VsmdAxis.Y);
        }

        private void btnEnaZ_Click(object sender, EventArgs e)
        {
            EnaImpl(VsmdAxis.Z);
        }
        private void EnaImpl(VsmdAxis axis)
        {
            VsmdController.GetVsmdController().Ena(axis);
        }

        private void btnOffX_Click(object sender, EventArgs e)
        {
            OffImpl(VsmdAxis.X);
        }

        private void btnOffY_Click(object sender, EventArgs e)
        {
            OffImpl(VsmdAxis.Y);
        }

        private void btnOffZ_Click(object sender, EventArgs e)
        {
            OffImpl(VsmdAxis.Z);
        }
        private void OffImpl(VsmdAxis axis)
        {
            VsmdController.GetVsmdController().Off(axis);
        }

        private void btnMoveX_Click(object sender, EventArgs e)
        {
            MoveImpl(VsmdAxis.X);
        }

        private void btnMoveY_Click(object sender, EventArgs e)
        {
            MoveImpl(VsmdAxis.Y);
        }

        private void btnMoveZ_Click(object sender, EventArgs e)
        {
            MoveImpl(VsmdAxis.Z);
        }
        private void MoveImpl(VsmdAxis axis)
        {
            VsmdController.GetVsmdController().Move(axis);
        }

        private void btnStopX_Click(object sender, EventArgs e)
        {
            StopImpl(VsmdAxis.X);
        }

        private void btnStopY_Click(object sender, EventArgs e)
        {
            StopImpl(VsmdAxis.Y);
        }

        private void btnStopZ_Click(object sender, EventArgs e)
        {
            StopImpl(VsmdAxis.Z);
        }
        private void StopImpl(VsmdAxis axis)
        {
            VsmdController.GetVsmdController().Stop(axis);
        }

        private void btnOrgX_Click(object sender, EventArgs e)
        {
            OrgImpl(VsmdAxis.X);
        }

        private void btnOrgY_Click(object sender, EventArgs e)
        {
            OrgImpl(VsmdAxis.Y);
        }

        private void btnOrgZ_Click(object sender, EventArgs e)
        {
            OrgImpl(VsmdAxis.Z);
        }
        private void OrgImpl(VsmdAxis axis)
        {
            VsmdController.GetVsmdController().Org(axis);
        }

        private void btnZeroStartX_Click(object sender, EventArgs e)
        {
            ZeroStartImpl(VsmdAxis.X);
        }

        private void btnZeroStartY_Click(object sender, EventArgs e)
        {
            ZeroStartImpl(VsmdAxis.Y);
        }

        private void btnZeroStartZ_Click(object sender, EventArgs e)
        {
            ZeroStartImpl(VsmdAxis.Z);
        }
        private void ZeroStartImpl(VsmdAxis axis)
        {
            VsmdController.GetVsmdController().ZeroStart(axis);
        }

        private void btnZeroStopX_Click(object sender, EventArgs e)
        {
            ZeroStopImpl(VsmdAxis.X);
        }

        private void btnZeroStopY_Click(object sender, EventArgs e)
        {
            ZeroStopImpl(VsmdAxis.Y);
        }

        private void btnZeroStopZ_Click(object sender, EventArgs e)
        {
            ZeroStopImpl(VsmdAxis.Z);
        }
        private void ZeroStopImpl(VsmdAxis axis)
        {
            VsmdController.GetVsmdController().ZeroStop(axis);
        }

        private void btnStsX_Click(object sender, EventArgs e)
        {
            StsImpl(VsmdAxis.X);
        }

        private void btnStsY_Click(object sender, EventArgs e)
        {
            StsImpl(VsmdAxis.Y);
        }

        private void btnStsZ_Click(object sender, EventArgs e)
        {
            StsImpl(VsmdAxis.Z);
        }
        private void StsImpl(VsmdAxis axis)
        {
            VsmdController.GetVsmdController().Sts(axis);
        }

        private void btnSaveX_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveY_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveZ_Click(object sender, EventArgs e)
        {

        }
    }
}
