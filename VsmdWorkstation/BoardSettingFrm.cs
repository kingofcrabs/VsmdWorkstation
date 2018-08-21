﻿using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VsmdLib;
using VsmdWorkstation.Controls;

namespace VsmdWorkstation
{
    public partial class BoardSettingFrm : Form
    {
        public enum FORM_MODE
        {
            Add,
            Update
        }
        private FORM_MODE m_mode;
        private BoardMeta m_curMeta;
        public BoardSettingFrm()
        {
            InitializeComponent();
        }

        private void BoardSettingFrm_Load(object sender, EventArgs e)
        {
            m_curMeta = new BoardMeta();
            FillData();
            m_mode = FORM_MODE.Add;

            if (!VsmdController.GetVsmdController().IsInitialized())
            {
                StatusBar.DisplayMessage(MessageType.Error, "设备未连接！");
                DisableControls();
                return;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidFormData())
            {
                return;
            }
            //BoardMeta meta = GetTempBoardSetting();
            FormDatToMeta();
            bool ret = true;
            if(m_mode == FORM_MODE.Add)
            {
                ret = BoardSetting.GetInstance().AddNewBoard(m_curMeta);
                if (ret)
                {
                    ShowMessage(MessageType.Info, "添加成功！");
                    ResetData();
                }
                else
                {
                    ShowMessage(MessageType.Error, "添加失败！");
                }
            }
            else if(m_mode == FORM_MODE.Update)
            {
                //BoardSetting.GetInstance().AddNewBoard(m_curMeta);
                ret = BoardSetting.GetInstance().Save();
                if (ret)
                {
                    ShowMessage(MessageType.Info, "更新成功！");
                    ResetData();
                }
                else
                {
                    ShowMessage(MessageType.Error, "更新失败！");
                }
            }
        }

        private void ResetData()
        {
            m_curMeta = new BoardMeta();
            m_mode = FORM_MODE.Add;
            FillData();
        }
        private BoardMeta GetTempBoardSetting()
        {
            BoardMeta temp = new BoardMeta();
            FormDatToMetaImpl(temp);

            return temp;
        }
        private void FormDatToMeta()
        {
            FormDatToMetaImpl(m_curMeta);
        }
        private void FormDatToMetaImpl(BoardMeta meta)
        {
            if(m_mode == FORM_MODE.Add)
            {
                meta.ID = BoardSetting.GetInstance().GetNextBoardNum();
            }
            meta.Name = txtName.Text.Trim();
            meta.BlockCount = int.Parse(txtBlockCnt.Text.Trim());
            meta.RowCount = int.Parse(txtRowCnt.Text.Trim());
            meta.ColumnCount = int.Parse(txtColCnt.Text.Trim());
            int val = 0;
            int.TryParse(txtFirstTubePosX.Text.Trim(), out val);
            meta.FirstTubeX = val;

            val = 0;
            int.TryParse(txtFirstTubePosY.Text.Trim(), out val);
            meta.FirstTubeY = val;

            val = 0;
            int.TryParse(txtTubeDistX.Text.Trim(), out val);
            meta.TubeDistanceX = val;

            val = 0;
            int.TryParse(txtTubeDistY.Text.Trim(), out val);
            meta.TubeDistanceY = val;

            val = 0;
            int.TryParse(txtBlockDist.Text.Trim(), out val);
            meta.BlockDistanceX = val;
        }

        private bool ValidFormData()
        {
            if(string.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowMessage(MessageType.Error, "名称不能为空！");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtBlockCnt.Text))
            {
                ShowMessage(MessageType.Error, "规格-组不能为空！");
                txtBlockCnt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtRowCnt.Text))
            {
                ShowMessage(MessageType.Error, "规格-行不能为空！");
                txtRowCnt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtColCnt.Text))
            {
                ShowMessage(MessageType.Error, "规格-列不能为空！");
                txtColCnt.Focus();
                return false;
            }
            if (int.Parse(txtBlockCnt.Text) > 1 && string.IsNullOrWhiteSpace(txtBlockDist.Text))
            {
                ShowMessage(MessageType.Error, "组件不能为空！");
                txtBlockDist.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtFirstTubePosX.Text))
            {
                ShowMessage(MessageType.Error, "首孔位置不能为空！");
                txtFirstTubePosX.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtFirstTubePosY.Text))
            {
                ShowMessage(MessageType.Error, "首孔位置不能为空！");
                txtFirstTubePosY.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTubeDistX.Text))
            {
                ShowMessage(MessageType.Error, "孔距不能为空！");
                txtTubeDistX.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTubeDistY.Text))
            {
                ShowMessage(MessageType.Error, "孔距不能为空！");
                txtTubeDistY.Focus();
                return false;
            }

            return true;
        }
        private void ShowMessage(MessageType type, string str)
        {
            StatusBar.DisplayMessage(type, str);
        }
        private void btnSetFX_Click(object sender, EventArgs e)
        {
            ShowSetDlg(txtFirstTubePosX, VsmdAxis.X, SetTubePositionFrm.PosType.Pos);
        }
        private void btnSetFY_Click(object sender, EventArgs e)
        {
            ShowSetDlg(txtFirstTubePosY, VsmdAxis.Y, SetTubePositionFrm.PosType.Pos);
        }
        private void btnSetTX_Click(object sender, EventArgs e)
        {
            ShowSetDlg(txtTubeDistX, VsmdAxis.X, SetTubePositionFrm.PosType.Dist);
        }
        private void btnSetTY_Click(object sender, EventArgs e)
        {
            ShowSetDlg(txtTubeDistY, VsmdAxis.Y, SetTubePositionFrm.PosType.Dist);
        }
        private void ShowSetDlg(TextBox textbox, VsmdAxis axisType, SetTubePositionFrm.PosType posType)
        {
            SetTubePositionFrm frm = new SetTubePositionFrm(axisType, posType);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                textbox.Text = frm.GetDist().ToString();
            }
            
        }
        private void DisableControls() {
            btnSetBlockDist.Enabled = false;
            btnSetFX.Enabled = false;
            btnSetFY.Enabled = false;
            btnSetTX.Enabled = false;
            btnSetTY.Enabled = false;
        }
        private void btnChoose_Click(object sender, EventArgs e)
        {
            ItemListFrm frm = new ItemListFrm();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                m_curMeta = (BoardMeta)frm.SelectedObject;
                FillData();
                m_mode = FORM_MODE.Update;
            }
        }
        private void FillData()
        {
            txtName.Text = m_curMeta.Name;
            txtBlockCnt.Text = m_curMeta.BlockCount.ToString();
            txtBlockDist.Text = m_curMeta.BlockDistanceX.ToString();
            txtRowCnt.Text = m_curMeta.RowCount.ToString();
            txtColCnt.Text = m_curMeta.ColumnCount.ToString();
            txtFirstTubePosX.Text = m_curMeta.FirstTubeX.ToString();
            txtFirstTubePosY.Text = m_curMeta.FirstTubeY.ToString();
            txtTubeDistX.Text = m_curMeta.TubeDistanceX.ToString();
            txtTubeDistY.Text = m_curMeta.TubeDistanceY.ToString();
        }

        private void btnSetBlockDist_Click(object sender, EventArgs e)
        {
            ShowSetDlg(txtBlockDist, VsmdAxis.X, SetTubePositionFrm.PosType.Dist);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            bool ret = BoardSetting.GetInstance().DeleteBoard(m_curMeta);
            if (ret)
            {
                ShowMessage(MessageType.Info, "删除成功！");
                ResetData();
            }
            else
            {
                ShowMessage(MessageType.Error, "删除失败！");
            }
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            tsmiDelete.Enabled = (m_mode == FORM_MODE.Update);
        }
    }
}
