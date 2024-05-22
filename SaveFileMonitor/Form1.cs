using System;
using System.IO;
using System.Windows.Forms;

namespace SaveFileMonitor
{
    public partial class save_file_form : Form
    {
        private FileSystemWatcher fileWatcher;
        private string selectedFilePath;
        private string outputDirectory; // Added variable to store output directory
        private bool isChangeHandled = true; // Flag to track if change is being handled

        public save_file_form()
        {
            InitializeComponent();
            fileWatcher = new FileSystemWatcher();
            fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            fileWatcher.Changed += FileChanged;
        }

        private void FileChanged(object sender, FileSystemEventArgs e)
        {
            if (!isChangeHandled)
                return;

            // Set the flag to false to indicate that change is being handled
            isChangeHandled = false;

            // Create a timestamp for the copy file name
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string fileName = Path.GetFileNameWithoutExtension(selectedFilePath);
            string extension = Path.GetExtension(selectedFilePath);
            string copyFilePath = Path.Combine(outputDirectory, $"{fileName}_{timeStamp}{extension}");

            // Copy the file to the new location
            File.Copy(selectedFilePath, copyFilePath);

            // Display status message
            UpdateStatus($"File {Path.GetFileName(selectedFilePath)} has been changed. Copy created: {copyFilePath}");

            // Start the timer
            timer1.Start();
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
                UpdateStatus($"Now monitoring file: {selectedFilePath}");
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
                UpdateStatus($"Output Directory set to: {selectedFilePath}");
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }

        private void UpdateStatus(string message)
        {
            // Update the status label text
            lblStatus.Text = message;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Reset the flag to indicate that change handling is complete
            isChangeHandled = true;

            // Stop the timer
            timer1.Stop();
        }
    }
}
