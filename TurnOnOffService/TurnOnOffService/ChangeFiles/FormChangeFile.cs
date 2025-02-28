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

namespace TurnOnOffService.ChangeFiles
{
    public partial class FormChangeFile : Form
    {
        private readonly string configFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"SavingConfig.txt");

        public FormChangeFile()
        {
            InitializeComponent();
            SetComboBox(true, true);
            SetComboBox(false, true);

            btnSourcePath.Click += (s, e) => GetForderPath(true);
            btnTargetPath.Click += (s, e) => GetForderPath(false);
            btnSaveSourcePath.Click += (s, e) => DoSaveSetting(true);
            btnSaveTargetPath.Click += (s, e) => DoSaveSetting(false);
            btnExecute.Click += (s, e) => DoMoveFiles();
            this.FormClosed += (s, e) => { tbLog.Clear(); };
        }

        private void DoMoveFiles()
        {
            try
            {
                string from = cbSourcePath.Text;
                string to = cbTargetPath.Text;
                if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
                {
                    tbLog.AppendText("【來源路徑/目標路徑不可為空】" + "\n");
                    return;
                }
                if (!Directory.Exists(from) || !Directory.Exists(to))
                {
                    tbLog.AppendText("【來源路徑/目標路徑不存在】" + "\n");
                    return;
                }
                MoveFile(from, to);
            }
            catch (Exception e)
            {
                tbLog.AppendText("【執行錯誤】" + e.ToString() + "\n");
            }
        }

        private void MoveFile(string fromDir, string toDir)
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
            }
            string[] folders = Directory.GetDirectories(fromDir);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(toDir, name);
                MoveFile(folder, dest);
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

        private void SetComboBox(bool isSelectSource, bool isForUpdate = false)
        {
            try
            {
                if (File.Exists(configFilePath))
                {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(configFilePath))
                    {
                        if (isSelectSource)
                        {
                            cbSourcePath.Items.Clear();
                            cbSourcePath.Items.AddRange(reader.ReadToEnd().Split(';')[0].Split(',').ToArray());
                        }
                        else
                        {
                            cbTargetPath.Items.Clear();
                            cbTargetPath.Items.AddRange(reader.ReadToEnd().Split(';')[1].Split(',').ToArray());
                        }
                    }
                    if (!isForUpdate)
                    {
                        tbLog.AppendText("【儲存設定成功】" + "\n");
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
                bool isFirstWrite = false;
                if (!File.Exists(configFilePath))
                {
                    isFirstWrite = true;
                }
                else
                {
                    //讀取已儲存的設置，若現在要存的路徑已存在，則不重複增加
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(configFilePath))
                    {
                        string sourcePaths = "";
                        string targetPaths = "";
                        var alltext = reader.ReadToEnd().Split(';').ToArray();
                        for (int i = 0; i < alltext.Count(); i++)
                        {
                            if (i == 0)
                            {
                                sourcePaths = alltext[0];
                            }
                            else if (i == 1)
                            {
                                targetPaths = alltext[1];
                            }
                        }

                        if (isSelectSource && !string.IsNullOrWhiteSpace(sourcePaths))
                        {
                            foreach (string data in sourcePaths.Split(',').ToArray())
                            {
                                if (data == cbSourcePath.Text) return;
                            }
                        }
                        else if (!isSelectSource && !string.IsNullOrWhiteSpace(sourcePaths))
                        {
                            foreach (string data in targetPaths.Split(',').ToArray())
                            {
                                if (data == cbTargetPath.Text) return;
                            }
                        }
                    }
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(configFilePath, true))
                {
                    file.Write((isFirstWrite ? "" : ",") + (isSelectSource ? cbSourcePath.Text : cbTargetPath.Text));

                    file.Close();
                }
            }
            catch (Exception e)
            {
                tbLog.AppendText("【儲存設定失敗】" + e.ToString() + "\n");
            }
        }

        #region useless XML

        private void WriteXML(bool isSelectSource)
        {
            string configFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"SavingConfig.xml");

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(configFilePath, settings))
            {
                if (!File.Exists(configFilePath))
                {
                    writer.WriteStartDocument();
                    writer.WriteComment("This file is generated by the program.");

                    //writer.WriteStartElement("Paths");
                }

                if (isSelectSource)
                {
                    WriteSavingData(writer, true, cbSourcePath.Text);
                    //WriteSavingData(writer, true, tbSourcePath.Text);
                }
                else
                {
                    WriteSavingData(writer, false, cbTargetPath.Text);
                    //WriteSavingData(writer, false, tbTargetPath.Text);
                }
                //writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
            }
        }

        private void WriteSavingData(XmlWriter writer, bool isSelectSource, string fullPath)
        {
            writer.WriteStartElement("Path");
            writer.WriteAttributeString("PathType", (isSelectSource ? "SourcePath" : "TargetPath"));
            writer.WriteElementString("FullPath", fullPath);
            writer.WriteEndElement();
        }

        #endregion  useless XML
    }
}