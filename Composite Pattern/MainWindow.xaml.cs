using Composite_Pattern.Models.Concretes;
using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Composite_Pattern
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private Folder? _currentFolder;

        public Folder? CurrentFolder
        {
            get { return _currentFolder; }
            set
            {
                _currentFolder = value;
                NotifyPropertyChanged(nameof(CurrentFolder));
            }
        }




        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VistaFolderBrowserDialog folderDialog = new();

            if (folderDialog.ShowDialog() is true)
            {
                DirectoryInfo directory = new DirectoryInfo(folderDialog.SelectedPath);

                CurrentFolder = new Folder(directory.Name, directory.FullName);
                AddAllFiles(CurrentFolder, directory);
                string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };
                int counter = 0;
                decimal number = (decimal)CurrentFolder.Size;

                while (Math.Round(number / 1024) >= 1)
                {
                    number = number / 1024;
                    counter++;
                }
                txtSize.Text = number.ToString() + suffixes[counter];
            }

        }



        public void AddAllFiles(Folder folder, DirectoryInfo directory)
        {

            var lCurrentDir = directory.GetFiles();

            foreach (var file in lCurrentDir)
                folder.Add(new Models.Concretes.File(file.Name, file.Length, file.FullName));

            lCurrentDir = null;

            var lDirCurrentDir = directory.GetDirectories();


            if (lDirCurrentDir.Length != 0)
            {
                foreach (var dir in lDirCurrentDir)
                {
                    var subF = new Folder(dir.Name, dir.FullName);
                    folder.Add(subF);

                    AddAllFiles(subF, dir);
                }
            }

            lDirCurrentDir = null;

        }

    }
}
