using SaveFileMonitor.Classes;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Timers;
using System.Windows.Forms;

namespace SaveFileMonitor
{
    public partial class save_file_form : Form
    {
        private FileSystemWatcher fileWatcher;
        private string selectedFilePath;
        private string outputDirectory; // Added variable to store output directory
        private bool isChangeHandled = true; // Flag to track if change is being handled
        private System.Timers.Timer systemTimer;
        private General oGeneral = new General();

        public save_file_form()
        {
            InitializeComponent();
            fileWatcher = new FileSystemWatcher();
            fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            fileWatcher.Changed += FileChanged;

            // Initialize system timer
            systemTimer = new System.Timers.Timer();
            systemTimer.Interval = 5000; // 5 seconds delay
            systemTimer.AutoReset = false;
            systemTimer.Elapsed += SystemTimerElapsed;

            //Initialize dropdown and other controls
            InitializeControls();
        }

        private void InitializeControls()
        {
            foreach (General.TimeFormat timeFormat in Enum.GetValues(typeof(General.TimeFormat)))
            {
                string description = oGeneral.GetEnumDescription(timeFormat);
                cbTimestampFormat.Items.Add(description);
            }
            cbTimestampFormat.SelectedIndex = (Int32)General.TimeFormat.DateTimeFormatUTC;
        }

        private void FileChanged(object sender, FileSystemEventArgs e)
        {
            Debug.WriteLine("FileChanged event triggered.");
            if (!isChangeHandled)
            {
                Debug.WriteLine("Change not handled.");
                return;
            }

            // Set the flag to false to indicate that change is being handled
            isChangeHandled = false;

            string timeStamp;
            string description = GetSelectedDescription();

            // Use the format described in the enum description
            timeStamp = DateTime.Now.ToString(description);

            string fileName = Path.GetFileNameWithoutExtension(selectedFilePath);
            string customName = tbCustomSaveFileName.Text;
            string extension = Path.GetExtension(selectedFilePath);

            // Validate custom name
            if (!string.IsNullOrWhiteSpace(customName))
                customName = oGeneral.RemoveInvalidFileNameChars(customName);

            // Create the new file path. If custom name is provided and is not empty, use it in the file name
            string copyFilePath = Path.Combine(lblOutputDir.Text, !string.IsNullOrWhiteSpace(customName) ? $"{fileName}_{customName}_{timeStamp}{extension}" : $"{fileName}_{timeStamp}{extension}");

            // Copy the file to the new location
            try
            {
                File.Copy(selectedFilePath, copyFilePath);
                Debug.WriteLine($"File copied to: {copyFilePath}");

                // Display status message on UI thread and empty the custom file name field
                UpdateStatusOnUiThread($"File {Path.GetFileName(selectedFilePath)} has been changed. Copy created: {copyFilePath}");
                EmptyCustomFileNameFieldOnUIThread();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error copying file: {ex.Message}");

            }

            // Start the system timer
            try
            {
                Debug.WriteLine($"Starting timer");
                systemTimer.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error starting timer: {ex.Message}");
            }
        }

        private void SystemTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Debug.WriteLine("SystemTimerElapsed triggered.");
            // Reset the flag to indicate that change handling is complete
            isChangeHandled = true;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*";
            openFileDialog.Title = "Select a File to Monitor";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                lblSelectFile.Text = selectedFilePath;
                lblOutputDir.Text = Path.GetDirectoryName(selectedFilePath);
                // Begin monitoring the selected file
                fileWatcher.Path = Path.GetDirectoryName(selectedFilePath);
                fileWatcher.Filter = Path.GetFileName(selectedFilePath);
                fileWatcher.EnableRaisingEvents = true;

                // Display status message
                UpdateStatusOnUiThread($"Now monitoring file: {selectedFilePath}");
            }
        }

        private void btnSelectOutputDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                outputDirectory = folderBrowserDialog.SelectedPath;
                lblOutputDir.Text = outputDirectory;

                // Display status message
                UpdateStatusOnUiThread($"Output Directory set to: {outputDirectory}");
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }

        private string GetSelectedDescription()
        {
            if (cbTimestampFormat.InvokeRequired)
            {
                //Invoke required, execute on UI thread
                return (string)cbTimestampFormat.Invoke((Func<string>)delegate
                {
                    General.TimeFormat selectedFormat = (General.TimeFormat)cbTimestampFormat.SelectedIndex;
                    return oGeneral.GetEnumDescription(selectedFormat);
                });
            }
            else
            {
                //No invoke required, execute directly
                General.TimeFormat selectedFormat = (General.TimeFormat)cbTimestampFormat.SelectedIndex;
                return oGeneral.GetEnumDescription(selectedFormat);
            }
        }

        private void UpdateStatusOnUiThread(string message)
        {
            if (lblStatus.InvokeRequired)
            {
                // Invoke required, execute on UI thread
                lblStatus.Invoke((MethodInvoker)delegate
                {
                    lblStatus.Text = message;
                });
            }
            else
            {
                // No invoke required, execute directly
                lblStatus.Text = message;
            }
        }

        private void EmptyCustomFileNameFieldOnUIThread()
        {
            if (tbCustomSaveFileName.InvokeRequired)
            {
                // Invoke required, execute on UI thread
                tbCustomSaveFileName.Invoke((MethodInvoker)delegate
                {
                    tbCustomSaveFileName.Text = String.Empty;
                });
            }
            else
            {
                // No invoke required, execute directly
                tbCustomSaveFileName.Text = String.Empty;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
