﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VsmdWorkstation.Controls;

namespace VsmdWorkstation
{
    public enum BoardType
    {
        Site = 1,
        Grid = 2,
    }
    public class BoardMeta
    {
        public int ID { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public int GridCount { get; set; }
        public int SiteCount { get; set; }
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
        
        public int Site1FirstTubeX { get; set; }
        
        public int Site1FirstTubeY { get; set; }

        public int Site1LastTubeX { get; set; }

        public int Site1LastTubeY { get; set; }

        public int Site2FirstTubeX { get; set; }
        
        public int Site2FirstTubeY { get; set; }
        /// <summary>
        /// 组距
        /// </summary>
        public int BlockDistanceX { get; set; }

        public int GridFirstTubeX { get; set; }
        public int GridFirstTubeY { get; set; }
        public int GridLastTubeX { get; set; }
        public int GridLastTubeY { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
    public delegate void DelDataUpdated(object data);
    public class BoardSetting
    {
        private List<BoardMeta> m_boardSettings = new List<BoardMeta>();
        public BoardMeta CurrentBoard { get; set; }
        public DelDataUpdated OnDataUpdate;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="coord">start from 1</param>
        /// <returns></returns>
        public int Convert2PhysicalPos(VsmdAxis axis, int coord)
        {
            int fpox = 0;
            switch (axis)
            {
                case VsmdAxis.X:
                    int blockIdx = (coord - 1) / CurrentBoard.ColumnCount;
                    fpox = CurrentBoard.Site1FirstTubeX + CurrentBoard.BlockDistanceX * blockIdx + CurrentBoard.Site2FirstTubeX * (blockIdx * (CurrentBoard.ColumnCount - 1) + (coord - 1) % CurrentBoard.ColumnCount);
                    //fpox = FirstTubeX + (coord - 1) * TubeDistanceX;
                    break;
                case VsmdAxis.Y:
                    fpox = CurrentBoard.Site1FirstTubeY + (coord - 1) * CurrentBoard.Site2FirstTubeY;
                    break;
                default:
                    break;
            }
            return fpox;
        }
        public string GetBoardMetaFilePath()
        {
            return Application.StartupPath + "\\boardSettings.json";
        }
        public void LoadBoardSettings()
        {
            string configFile = GetBoardMetaFilePath();
            if (!File.Exists(configFile))
            {
                StatusBar.DisplayMessage(MessageType.Error, "载物架配置文件未找到，请重新配置载物架信息！");
                return;
            }
            string str = File.ReadAllText(configFile);
            if (string.IsNullOrWhiteSpace(str.Trim()))
            {
                StatusBar.DisplayMessage(MessageType.Warming, "载物架配置文件为空！");
                return;
            }
            m_boardSettings = JsonConvert.DeserializeObject<List<BoardMeta>>(str);
        }
        public List<BoardMeta> GetAllBoardMetaes()
        {
            return m_boardSettings;
        }
        public bool AddNewBoard(BoardMeta board)
        {
            m_boardSettings.Add(board);
            return Save();
        }
        public bool DeleteBoard(BoardMeta board)
        {
            m_boardSettings.Remove(board);
            return Save();
        }
        public bool Save()
        {
            string configFile = GetBoardMetaFilePath();
            bool ret = true;
            try
            {
                if (File.Exists(configFile))
                {
                    File.Delete(configFile);
                }
                using (FileStream stream = File.Create(configFile))
                {
                    string str = JsonConvert.SerializeObject(m_boardSettings);
                    byte[] bytes = System.Text.Encoding.Default.GetBytes(str);
                    stream.Write(bytes, 0, bytes.Length);
                    //File.WriteAllText(configFile, str);
                }
                if(OnDataUpdate != null)
                {
                    OnDataUpdate(m_boardSettings);
                }
            } catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                ret = false;
            }
            return ret;
        }
        public int GetNextBoardNum()
        {
            int no = 1;
            m_boardSettings.ForEach((board) => {
                if(board.ID >= no)
                {
                    no = board.ID + 1;
                }
            });

            return no;
        }
        private static BoardSetting m_curBoardSetting = null;
        public static void SetCurrentBoardSetting(BoardSetting setting)
        {
            m_curBoardSetting = setting;
        }
        public static BoardSetting GetInstance()
        {
            if(m_curBoardSetting == null)
            {
                m_curBoardSetting = new BoardSetting();
            }
            return m_curBoardSetting;
        }
    }
}
