using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Text;

namespace FileDialog
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO 1 open file dialog and choose directoy to start
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C:\Users\Justin\Google Drive\Course Work\CSIS 2530\FileDialog\bin\Debug";

            if (dialog.ShowDialog() == true)
            {
                string path = dialog.FileName;
                try
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        StringBuilder sb = new StringBuilder();
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            sb.Append(line).Append(Environment.NewLine);
                            ContentTb.Text = sb.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    StatusLb.Content = "A problem occured opening" + path;
                }
            }

            // TODO 2 if the user selected a file display file/dir name and text
            DirectoryTb.Text = dialog.InitialDirectory;
            FileTb.Text = dialog.SafeFileName;
        }

        private void saveFileButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO 4 open the save file dialog, set director to start, save content to file

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO 3 clear all text fields
            ContentTb.Text = string.Empty;
            DirectoryTb.Text = string.Empty;
            FileTb.Text = string.Empty;
        }
    }
}
