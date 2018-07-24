﻿using CefSharp.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VsmdWorkstation
{
    public class BridgeObject
    {
        private ChromiumWebBrowser m_browser;
        private Thread m_moveThread;
        public BridgeObject(ChromiumWebBrowser browser)
        {
            m_browser = browser;
        }
        public void Move(string args)
        {
            VsmdController vsmdController = VsmdController.GetVsmdController();
            if (!vsmdController.IsInitialized())
            {
                StatusBar.DisplayMessage(MessageType.Error, "未初始化控制器！");
                return;
            }
            if(m_moveThread != null && m_moveThread.IsAlive)
            {
                m_moveThread.Abort();
            }
            m_moveThread = new Thread(new ParameterizedThreadStart(MoveThread));
            m_moveThread.Start(args);
        }
        public void StopMove()
        {
            if (m_moveThread != null && m_moveThread.IsAlive)
            {
                m_moveThread.Abort();
                AfterMove();
            }
        }
        public void BuildGrid(BoardSettings board)
        {
            JObject opts = new JObject();
            opts.Add("blockCount", board.BlockCount);
            opts.Add("rowCount", board.RowCount);
            opts.Add("columnCount", board.ColumnCount);

            CallJS("JsExecutor.buildGrid(" + opts.ToString() + ");");
        }
        //public string GetSelectedTubes()
        //{
        //    string ret = CallJSWithResult("JsExecutor.getSelectedTubes()");
        //    MessageBox.Show("call CallJSWithResult ");
        //    return ret;
        //}
        private void MoveThread(object args)
        {
            string jsCode = "JsExecutor.getSelectedTubes()";
            var task = m_browser.GetBrowser().MainFrame.EvaluateScriptAsync(jsCode);
            task.ContinueWith(t =>
            {
                if (!t.IsFaulted)
                {
                    var response = t.Result;
                    var result = response.Success ? (response.Result ?? "null") : response.Message;
                    BoardSettings curBoardSetting = BoardSettings.GetCurrentBoardSetting();
                    JArray jsArr = (JArray)JsonConvert.DeserializeObject(result.ToString());
                    BeforeMove();
                    VsmdController vsmdController = VsmdController.GetVsmdController();
                    vsmdController.MoveTo(VsmdAxis.X, 0);
                    vsmdController.MoveTo(VsmdAxis.Y, 0);
                    for (int i = 0; i < jsArr.Count; i++)
                    {
                        JObject obj = (JObject)jsArr[i];
                        int row = int.Parse(obj["row"].ToString());
                        int col = int.Parse(obj["column"].ToString());
                        vsmdController.MoveTo(VsmdAxis.X, curBoardSetting.Convert2PhysicalPos(VsmdAxis.X, col));
                        vsmdController.MoveTo(VsmdAxis.Y, curBoardSetting.Convert2PhysicalPos(VsmdAxis.Y, row));
                        MoveCallBack(row, col);
                        System.Threading.Thread.Sleep(1000);
                    }
                    AfterMove();
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void BeforeMove()
        {
            CallJS("JsExecutor.beforeMove();");
        }
        private void AfterMove()
        {
            CallJS("JsExecutor.afterMove();");
        }
        private void MoveCallBack(int row, int col)
        {
            CallJS("JsExecutor.moveCallBack(" + row + "," + col + ");");
        }
        public void CallJS(string jsCode)
        {
            m_browser.GetBrowser().MainFrame.ExecuteJavaScriptAsync(jsCode);
        }
        public void CallJSWithResult(string jsCode)
        {
            
        }
    }
}
