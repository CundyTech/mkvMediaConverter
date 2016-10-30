using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mkvMediaConverter.Properties;
using System.Threading.Tasks;

namespace mkvMediaConverter
{
    public partial class FrmMain : Form
    {
        /// <References>
        /// Watcher example borrowed from:
        /// http://www.codeproject.com/Articles/26528/C-Application-to-Watch-a-File-or-Directory-using-F
        /// Conversion Example using FFMPEG borrowed from:
        /// https://github.com/Gigawiz/MKV2MP4
        /// </References>

        private bool _isWatching;

        private string _path;
        private string _customTargetPath;
        private FileSystemWatcher _watcher = new FileSystemWatcher();
        private readonly StringBuilder _sb;
        private bool _isBusy;

        #region Public Methods

        public FrmMain()
        {
            InitializeComponent();
            _sb = new StringBuilder();
            _isBusy = false;
            _conversionQueue = new ConcurrentQueue<MediaFile>();


        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Converts MKV to MP4
        /// </summary>
        /// <param name="infile"></param>
        /// <param name="outfile"></param>
        private void ConvertToMp4(string infile, string outfile)
        {
            string strFileName = Path.GetFileName(infile);
            UpdateStatusStrip(SystemStatus.Converting, strFileName);

            try
            {
                //Setup FFMPEG with params etc
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg\\ffmpeg.exe");
                startInfo.Arguments = @" -i " + @"""" + infile + @"""" + " -y -vcodec copy -acodec copy " + @" """ +
                                      outfile + @""" ";


                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardOutput = true;


                process.StartInfo = startInfo;
                process.ErrorDataReceived += ConsoleDataReceived;
                process.OutputDataReceived += ConsoleDataReceived;

                process.Start();

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                process.WaitForExit();


                if (deleteOldFileToolStripMenuItem.Checked) //Delete original mkv?
                {
                    File.Delete(infile);
                }
            }
            catch (Exception ex)
            {
                //Invoke LstOutput and write exception to it.
                LstOutput.BeginInvoke((Action)(() =>
                {
                    LstOutput.BeginUpdate();
                    LstOutput.Items.Add(ex.ToString());
                    LstOutput.EndUpdate();
                }));
            }

            UpdateStatusStrip(SystemStatus.FinishedConverting, strFileName);
            UpdateConvertedFilesLog(strFileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediaFile"></param>
        private void ConvertMedia(MediaFile mediaFile)
        {
            string strFileName = mediaFile.StrName;
            string strOutputFilePath = mediaFile.StrOutputFilePath;
            string strOriginFilePath = mediaFile.StrOriginFilePath;
            UpdateStatusStrip(SystemStatus.Converting, strFileName);

            try
            {
                //Setup FFMPEG with params etc
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg\\ffmpeg.exe");
                startInfo.Arguments = @" -i " + @"""" + strOriginFilePath + @"""" + " -y -vcodec copy -acodec copy " + @" """ +
                                      strOutputFilePath + @""" ";


                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardError = true;
                startInfo.RedirectStandardOutput = true;

                process.StartInfo = startInfo;
                process.ErrorDataReceived += ConsoleDataReceived;
                process.OutputDataReceived += ConsoleDataReceived;

                process.Start();

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                process.WaitForExit();

                //Delete original mkv?
                if (deleteOldFileToolStripMenuItem.Checked)
                {
                    File.Delete(strOriginFilePath);
                }
            }
            catch (Exception ex)
            {
                //Invoke LstOutput and write exception to it.
                LstOutput.BeginInvoke((Action)(() =>
                {
                    LstOutput.BeginUpdate();
                    LstOutput.Items.Add(ex.ToString());
                    LstOutput.EndUpdate();
                }));
            }

            UpdateStatusStrip(SystemStatus.FinishedConverting, strFileName);
            UpdateConvertedFilesLog(strFileName);
        }

        /// <summary>
        /// Adds converted files for log
        /// </summary>
        /// <param name="strFileName"></param>
        private void UpdateConvertedFilesLog(string strFileName)
        {
            StringBuilder sbBuilder = new StringBuilder();
            sbBuilder.Append(strFileName);
            sbBuilder.Append("    ");
            sbBuilder.Append(DateTime.Now);
            LbConvertedFiles.BeginInvoke((Action)(() =>
            {
                LbConvertedFiles.BeginUpdate();
                LbConvertedFiles.Items.Add(sbBuilder);
                LbConvertedFiles.EndUpdate();
            }));
        }

        /// <summary>
        /// Sets up and enables Watcher.
        /// </summary>
        /// <param name="path"></param>
        private void Watch(string path)
        {

            if (path == null) throw new ArgumentNullException("path");
            if (_isWatching) //If already Watching
            {
                //Timer();
                UpdateStatusStrip(SystemStatus.Stopped);

                _isWatching = false;
                _watcher.EnableRaisingEvents = false; //Stop Watcher
                _watcher.Dispose();
                //BtnWatch.BackColor = Color.ForestGreen;
                BtnWatch.Text = @"Start";
                BtnWatch.Image = Resources.ServiceStart_5723;
            }
            else
            {
                //Timer();
                if (TxtWtchFldr.Text != "") //If not Watching and watch folder exists
                {
                    UpdateStatusStrip(SystemStatus.Started);
                    BtnWatch.Image = Resources.ServicesStop_5725;
                    path = TxtWtchFldr.Text; //Folder to watch
                    _isWatching = true;
                    //BtnWatch.BackColor = Color.Red;
                    BtnWatch.Text = @"Stop";

                    _watcher = new FileSystemWatcher();

                    _watcher.Filter = "*.*"; //Watch everything in folder

                    _watcher.Path = path + "\\";
                    _watcher.IncludeSubdirectories = true;

                    //Define Filters
                    _watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                            | NotifyFilters.FileName | NotifyFilters.DirectoryName;

                    //Add listeners
                    _watcher.Changed += OnChanged;
                    _watcher.Created += OnChanged;
                    _watcher.Deleted += OnChanged;
                    _watcher.Renamed += _watcher_Renamed;

                    _watcher.EnableRaisingEvents = true; //Start Watcher
                }
            }
        }

        /// <summary>
        /// The different statuses the system can be.
        /// </summary>
        private enum SystemStatus
        {
            Started,
            Stopped,
            Converting,
            FinishedConverting

        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="name"></param>
        private void UpdateStatusStrip(SystemStatus status, string name = null)
        {
            string strStatusText = "";
            switch (status)
            {
                case SystemStatus.Started:
                    {
                        strStatusText = "Watching Media";
                        break;
                    }
                case SystemStatus.Converting:
                    {
                        strStatusText = string.Format("Converting {0}", name);
                        break;
                    }
                case SystemStatus.FinishedConverting:
                    {
                        strStatusText = string.Format("Finished Converting {0}", name);
                        break;
                    }

                case SystemStatus.Stopped:
                    {
                        strStatusText = string.Format("Stopped Watching Media");
                        break;
                    }
            }

            statusStrip.BeginInvoke((Action)(() =>
            {
                toolStripStatusLabel.Text = String.Format("{0}", strStatusText);
                statusStrip.Refresh();
                statusStrip.Update();
            }));
        }
        
        /// <summary>
        /// Log any changes
        /// </summary>
        /// <param name="e"></param>
        private void LogFile(FileSystemEventArgs e)
        {
            if (_isBusy == false)
            {
                _sb.Remove(0, _sb.Length);
                _sb.Append(e.FullPath);
                _sb.Append(" ");
                _sb.Append(e.ChangeType);
                _sb.Append("    ");
                _sb.Append(DateTime.Now);
                _isBusy = true;
            }
        }

        /// <summary>
        /// Logs any rename events
        /// </summary>
        /// <param name="e"></param>
        private void LogFile(RenamedEventArgs e)
        {

            if (_isBusy == false)
            {
                _sb.Remove(0, _sb.Length);
                _sb.Append(e.OldName);
                _sb.Append(" -> ");
                _sb.Append(e.FullPath);
                _sb.Append(" ");
                _sb.Append(e.ChangeType);
                _sb.Append(" ");
                _sb.Append(DateTime.Now);
                _isBusy = true;
            }
        }

        /// <summary>
        /// Checks if file is locked by another process
        /// Ref:http://stackoverflow.com/a/937558/2468342
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        private void BtnSlctCstmFldr_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = @"Select folder when converted files will be created.";
            fbd.SelectedPath = TxtWtchFldr.Text;
            fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                _customTargetPath = fbd.SelectedPath;
                TxtOutput.Text = fbd.SelectedPath;
            }
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                notifyIcon.Visible = true;
                Hide();
            }

            else if (FormWindowState.Normal == WindowState)
            {
                notifyIcon.Visible = false;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void deleteOldFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteOldFileToolStripMenuItem.Checked = deleteOldFileToolStripMenuItem.Checked != true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox1 = new AboutBox();
            aboutBox1.ShowDialog();
        }
        
        #endregion

        #region Form Methods
        

        private ExtentionType _outputExtension;
        private string _outputFile;

        /// <summary>
        /// Processes changes to watch folder
        /// </summary>
        /// <param name="e"></param>
        private void ChangeDetected(FileSystemEventArgs e)
        {
            if (RbtnMKVtoMP4.Checked) { _outputExtension = ExtentionType.Mp4; }

            if (e.ChangeType == WatcherChangeTypes.Created || e.ChangeType == WatcherChangeTypes.Changed)
            {
                AddToQueue(e, _outputExtension);

                //If file is folder
                if (Directory.Exists(e.FullPath))
                {
                    //Get files from folder
                    foreach (string file in Directory.GetFiles(e.FullPath))
                    {
                        _outputFile = GetCustomFolder(e, ChkCustomOutput.Checked);

                        if (file.EndsWith(".mkv")) //if file is a .mkv
                        {
                            bool seenBefore = HashCheck.DoCheck(file);

                            if (!seenBefore)
                            {
                                //If convert to MKV option checked
                                if (RbtnMKVtoMP4.Checked)
                                {
                                    ConvertToMp4(file, _outputFile);
                                }
                            }
                        }
                        else
                        {
                            //Recursively look into other folders and repeat
                            var eventArgs = new FileSystemEventArgs(
                                WatcherChangeTypes.Created,
                                Path.GetDirectoryName(file),
                                Path.GetFileName(file));
                            ChangeDetected(eventArgs);
                        }
                    }
                }

                else
                {
                    //single file (not in folder)
                    if (e.ChangeType == WatcherChangeTypes.Created || e.ChangeType == WatcherChangeTypes.Changed)
                    {
                        bool seenBefore = HashCheck.DoCheck(e.FullPath);

                        if (!seenBefore)
                        {
                            _outputFile = GetCustomFolder(e, ChkCustomOutput.Checked);

                            //If convert to MKV option checked
                            if (RbtnMKVtoMP4.Checked)
                            {
                                ConvertToMp4(e.FullPath, _outputFile);
                                LogFile(e);
                            }
                        }


                    }
                }
            }
        }

        private readonly ConcurrentQueue<MediaFile> _conversionQueue;
        private void AddToQueue(FileSystemEventArgs e, ExtentionType extentionType)
        {
            bool seenBefore = HashCheck.DoCheck(e.FullPath);
            if (!seenBefore)
            {
                //Create Media Item for Queue
                MediaFile mediaFile = new MediaFile
                {
                    DtDateTimeStamp = DateTime.Now,
                    ConversionType = extentionType,
                    StrName = e.Name,
                    StrOriginFilePath = e.FullPath,
                    StrOutputFilePath = GetCustomFolder(e, ChkCustomOutput.Checked),
                    Hash = HashCheck.GetHash(e),
                    Progress = 10
                };

                _conversionQueue.Enqueue(mediaFile);

                dgvQueue.BeginInvoke((Action)(() =>
                {
                    if (dgvQueue.Rows.Count < 0)
                    {
                        SetupGrid();
                    }
                    dgvQueue.DataSource = _conversionQueue.ToList();
                   
                }));
            }
        }

        private void CheckQueue()
        {
            MediaFile mediaFile;
            while (_conversionQueue.IsEmpty)
            {
                // Maybe sleep / wait / ...
            }

            if (_conversionQueue.TryDequeue(out mediaFile))
            {
                ConvertMedia(mediaFile);
            }

        }

        private int _i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            _i++;
            dgvQueue["Progress", 0].Value = _i;
            if (_i == 100)
            {
                timer1.Stop();
            }
        }

        private void SetupGrid()
        {
            dgvQueue.AutoGenerateColumns = false;

            dgvQueue.ColumnCount = 7;
            dgvQueue.Columns[0].Name = "Name";
            dgvQueue.Columns[0].DataPropertyName = "StrName";
            dgvQueue.Columns[0].Visible = true;
            dgvQueue.Columns["Name"].DisplayIndex = 0;
            dgvQueue.Columns[1].Name = "Time Seen";
            dgvQueue.Columns[1].DataPropertyName = "DtDateTimeStamp";
            dgvQueue.Columns[1].Visible = true;
            dgvQueue.Columns["Time Seen"].DisplayIndex = 1;
            dgvQueue.Columns[2].Name = "Conversion Type";
            dgvQueue.Columns[2].DataPropertyName = "ConversionType";
            dgvQueue.Columns[2].Visible = true;
            dgvQueue.Columns["Conversion Type"].DisplayIndex = 2;
            dgvQueue.Columns[3].Name = "StrOriginFilePath";
            dgvQueue.Columns[3].DataPropertyName = "StrOriginFilePath";
            dgvQueue.Columns[3].Visible = false;
            dgvQueue.Columns["StrOriginFilePath"].DisplayIndex = 3;
            dgvQueue.Columns[4].Name = "StrOutputFilePath";
            dgvQueue.Columns[4].DataPropertyName = "StrOutputFilePath";
            dgvQueue.Columns[4].Visible = false;
            dgvQueue.Columns["StrOutputFilePath"].DisplayIndex = 4;
            dgvQueue.Columns[5].Name = "Hash";
            dgvQueue.Columns[5].DataPropertyName = "Hash";
            dgvQueue.Columns[5].Visible = false;
            dgvQueue.Columns["Hash"].DisplayIndex = 5;

            //Add progressbar column
            DataGridViewProgressColumn column = new DataGridViewProgressColumn();
            dgvQueue.Columns.Add(column);
            column.Name = "Progress";
            column.HeaderText = @"Progress";
            dgvQueue.Columns["Progress"].DisplayIndex = 6;
            dgvQueue.Columns[6].DataPropertyName = "Progress";
            dgvQueue.Columns[6].Visible = true;
            timer1.Start();

        }

        private string GetCustomFolder(FileSystemEventArgs e, bool useCustomFolder)
        {
            var outputFile = string.Empty;
            if (!useCustomFolder)
            {
                outputFile = e.FullPath.Replace(".mkv", "." + _outputExtension);

            }
            else
            {
                var strFileName = Path.GetFileName(e.FullPath);
                _customTargetPath = TxtOutput.Text;
                if (strFileName != null)
                {
                    strFileName = strFileName.Replace(".mkv", "." + _outputExtension);
                    outputFile = Path.Combine(_customTargetPath, strFileName);
                }
            }
            return outputFile;
        }
        
        /// <summary>
        /// Receives SOUT data from FFMPEG and updates log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsoleDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
                LstFfmpegOutput.BeginInvoke((Action)(() =>
                {
                    LstFfmpegOutput.BeginUpdate();
                    if (e.Data != null) LstFfmpegOutput.Items.Add(e.Data);
                    LstFfmpegOutput.EndUpdate();
                }));
        }

        /// <summary>
        /// Event for when an object is renamed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _watcher_Renamed(object sender, RenamedEventArgs e)
        {
            LogFile(e);
            ChangeDetected(e);
        }

        /// <summary>
        /// Event fires when change detected
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            LogFile(e);
            ChangeDetected(e);
        }


        /// <summary>
        /// Begin/Stop Watching
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWatch_Click(object sender, EventArgs e)
        {
            if (TxtWtchFldr.Text != null)
            {

                _path = TxtWtchFldr.Text;
                Watch(_path);
                _tsTimeSpan = DateTime.Now;

            }
        }

        private DateTime _tsTimeSpan;
        /// <summary>
        /// Check if there are updates pending to be logged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (_isBusy)
            {
                LstOutput.BeginUpdate();
                LstOutput.Items.Add(_sb.ToString());
                LstOutput.EndUpdate();
                _isBusy = false;
            }

            if (BtnWatch.Text == @"Stop")
            {
                //uptime calc
                statusStrip.BeginInvoke((Action)(() =>
                {
                    TimeSpan span = (DateTime.Now - _tsTimeSpan);
                    toolStripStatusLabel2.Text = String.Format("{0} Days, {1} Hours, {2} Minutes, {3} Seconds",
                        span.Days, span.Hours, span.Minutes, span.Seconds);
                    statusStrip.Refresh();
                    statusStrip.Update();
                }));

            }

        }

        /// <summary>
        /// Use Custom Output path instead of default directory
        /// NOT IMPLEMENTED YET!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkCustomOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCustomOutput.Checked)
            {
                TxtOutput.Enabled = true;
            }
            if (ChkCustomOutput.Checked == false)
            {
                TxtOutput.Enabled = false;
            }
        }

        /// <summary>
        /// Load users presets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //BtnWatch.BackColor = Color.ForestGreen;
            TxtWtchFldr.Text = Settings.Default.TxtWtchFldr;
            deleteOldFileToolStripMenuItem.Checked = Settings.Default.ChkDeleteMkv;
          
            Task.Run(() =>
            {
                CheckQueue();
            });
        }

        /// <summary>
        /// Save users preset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.ChkDeleteMkv = deleteOldFileToolStripMenuItem.Checked;
            Settings.Default.TxtWtchFldr = TxtWtchFldr.Text;
            Settings.Default.Save();
        }

        /// <summary>
        /// Clear Log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClearOutput_Click(object sender, EventArgs e)
        {
            LstOutput.Items.Clear();
        }

        /// <summary>
        /// Gets Watch Folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSlctWtchFldr_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = @"Select folder that will be watched for new file of select format.";
            fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                _path = fbd.SelectedPath;
                TxtWtchFldr.Text = fbd.SelectedPath;
            }
        }


        #endregion




    }
}
