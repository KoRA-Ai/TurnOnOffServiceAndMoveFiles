using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace TurnOnOffServiceAndMoveFiles.ChangeFiles
{
    public partial class FormChangeFile : Form
    {
        private readonly string configFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"SavingConfig.txt");

        public FormChangeFile()
        {
            InitializeComponent();
            if (!File.Exists(configFilePath))
            {
                using (FileStream fs = File.Create(configFilePath)) { }
            }

            SetComboBox(true);
            SetComboBox(false);

            btnSourcePath.Click += (s, e) => GetForderPath(true);
            btnTargetPath.Click += (s, e) => GetForderPath(false);
            btnSaveSourcePath.Click += (s, e) => DoSaveSetting(true);
            btnSaveTargetPath.Click += (s, e) => DoSaveSetting(false);
            btnExecute.Click += (s, e) => DoMoveFiles();
            this.FormClosed += (s, e) => { tbLog.Clear(); };
        }

        private bool CheckDirectory(string dirPath)
        {
            if (string.IsNullOrWhiteSpace(dirPath))
            {
                tbLog.AppendText("【來源路徑/目標路徑不可為空】" + "\n");
                return false;
            }
            if (!Directory.Exists(dirPath))
            {
                tbLog.AppendText("【來源路徑/目標路徑不存在】" + "\n");
                return false;
            }
            return true;
        }

        private void DoMoveFiles()
        {
            try
            {
                string from = cbSourcePath.Text;
                string to = cbTargetPath.Text;
                if (from == to)
                {
                    tbLog.AppendText($"【來源路徑不可跟目標路徑相同】" + "\n");
                    return;
                }
                if (CheckDirectory(from) && CheckDirectory(to))
                {
                    int fileCount = 0;
                    MoveFile(from, to, ref fileCount);
                    tbLog.AppendText($"【換檔案完成-移動了{fileCount}個檔案】" + "\n");
                }
            }
            catch (Exception e)
            {
                tbLog.AppendText("【執行錯誤】" + e.ToString() + "\n");
            }
        }

        private void MoveFile(string fromDir, string toDir, ref int fileCount)
        {
            if (!Directory.Exists(toDir))
                Directory.CreateDirectory(toDir);

            string[] files = Directory.GetFiles(fromDir);

            foreach (string file in files)
            {
                string name = Path.GetFileName(file);

                string dest = Path.Combine(toDir, name);
                if (File.Exists(dest))
                {
                    File.Delete(dest);
                }
                File.Copy(file, dest);
                fileCount++;
            }
            string[] folders = Directory.GetDirectories(fromDir);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(toDir, name);
                MoveFile(folder, dest, ref fileCount);
            }
        }

        private void GetForderPath(bool isSelectSource)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "選擇資料夾";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (isSelectSource)
                {
                    cbSourcePath.Text = folderBrowserDialog.SelectedPath;
                }
                else
                {
                    cbTargetPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void DoSaveSetting(bool isSelectSource)
        {
            WriteTxt(isSelectSource);
            SetComboBox(isSelectSource);
        }

        private void SetComboBox(bool isSelectSource)
        {
            try
            {
                if (File.Exists(configFilePath))
                {
                    List<string> lines = new List<string>();
                    lines.AddRange(File.ReadAllLines(configFilePath));
                    while (lines.Count() < 2)
                    {
                        lines.Add("");//補足兩行，第一行放來源路徑，第二行放目標路徑
                    }

                    if (isSelectSource)
                    {
                        cbSourcePath.Items.Clear();
                        cbSourcePath.Items.AddRange(lines[0].Trim().Split(',').ToArray());
                    }
                    else
                    {
                        cbTargetPath.Items.Clear();
                        cbTargetPath.Items.AddRange(lines[1].Trim().Split(',').ToArray());
                    }
                }
            }
            catch (Exception e)
            {
                tbLog.AppendText("【儲存設定失敗】" + e.ToString() + "\n");
            }
        }

        private void WriteTxt(bool isSelectSource)
        {
            try
            {
                if (!File.Exists(configFilePath))
                {
                    using (FileStream fs = File.Create(configFilePath)) { }
                }

                List<string> lines = new List<string>();
                lines.AddRange(File.ReadAllLines(configFilePath));
                while (lines.Count() < 2)
                {
                    lines.Add("");//補足兩行，第一行放來源路徑，第二行放目標路徑
                }
                if (isSelectSource)
                {
                    if (!CheckDirectory(cbSourcePath.Text)) return;
                    //讀取已儲存的設置，若現在要存的路徑已存在，則不重複增加
                    foreach (string data in lines[0].Split(',').ToArray())
                    {
                        if (data == cbSourcePath.Text) return;
                    }
                    //寫入路徑
                    lines[0] = (string.IsNullOrWhiteSpace(lines[0]) ? "" : lines[0] + ",") + cbSourcePath.Text;
                }
                else
                {
                    if (!CheckDirectory(cbTargetPath.Text)) return;

                    //讀取已儲存的設置，若現在要存的路徑已存在，則不重複增加
                    foreach (string data in lines[1].Split(',').ToArray())
                    {
                        if (data == cbTargetPath.Text) return;
                    }
                    //寫入路徑
                    lines[1] = (string.IsNullOrWhiteSpace(lines[1]) ? "" : lines[1] + ",") + cbTargetPath.Text;
                }

                File.WriteAllLines(configFilePath, lines);
                tbLog.AppendText("【儲存設定成功】" + "\n");
            }
            catch (Exception e)
            {
                tbLog.AppendText("【儲存設定失敗】" + e.ToString() + "\n");
            }
        }
    }
}