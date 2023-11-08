using LilithModConfigureTool.Localization;
using LilithModConfigureTool.Types;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace LilithModConfigureTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var typesListView = this.ModFileTypesListView;
            typesListView.ItemsSource = AppResources.AvailableType;
            typesListView.SelectionChanged += TypesListView_SelectionChanged;
        }

        private string? currentPath = null;
        private ModType? _currentType = null;

        internal ModType? CurrentType
        {
            get { return _currentType; }
            set
            {
                _currentType = value;
                UpdateTypeItems(_currentType);
            }
        }

        private void InitializeProject(string newPath)
        {
            if (newPath == currentPath) return;
            currentPath = newPath;
            AppResources.AvailableType.ForEach(type => type.ClearFile());

            DirectoryInfo dir = new DirectoryInfo(newPath);
            var xmlFiles = dir.GetFiles("*.xml", SearchOption.AllDirectories);
            foreach (var file in xmlFiles)
            {
                var relativePath = file.FullName.Substring(newPath.Length + 1);
                var type = AppResources.AvailableType.Find(type => relativePath.Contains(type.UsualPath));
                if (type != null)
                {
                    type.AddFile(relativePath);
                }
            }

        }


        private void UpdateTypeItems(ModType? newType)
        {
            if (newType == null) return;
            var typeItemsListView = this.TypeItemsListView;
            typeItemsListView.ItemsSource = newType.ModFiles;
        }

        private void TypesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentType = (sender as ListView)?.SelectedItems[0] as ModType;
        }

        private void MenuFileNew_Click(object sender, RoutedEventArgs e)
        {
            // open folder browser dialog
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowDialog();

            var selectPath = dialog.SelectedPath;
            if (selectPath == null) return;
            // if not an empty folder
            if (System.IO.Directory.GetFiles(selectPath).Length != 0)
            {
                MessageBox.Show(LocalizationProvider.GetLocalizaedValue<string>("NewNonEmptyFile"));
                return;
            }

            InitializeProject(selectPath);
        }

        private void MenuFileOpen_Click(object sender, RoutedEventArgs e)
        {
            // open folder browser dialog
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowDialog();

            var selectPath = dialog.SelectedPath;
            if (selectPath == null) return;

            InitializeProject(selectPath);
        }

        private void MenuLanguage_Click(object sender, RoutedEventArgs e)
        {
            LocalizationProvider.ChangeLocalization((sender as MenuItem)?.Uid ?? "");
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            if (currentPath == null) return;
            var typeItemsListView = this.TypeItemsListView;
        }

        private void ButtonMod_Click(object sender, RoutedEventArgs e)
        {
            if (currentPath == null) return;
            var typeItemsListView = this.TypeItemsListView;

            var selectedItem = typeItemsListView.SelectedItem;

            if (selectedItem == null) return;
            var path = selectedItem as string;
            var fullPath = Path.Combine(currentPath, path);
            var type = CurrentType;
            if (type.Name == "Item")
            {
                var item = new ItemType(fullPath);
                item.Parse();
            }

        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            if (currentPath == null) return;

            // confirm dialog
            var result = MessageBox.Show(
                LocalizationProvider.GetLocalizaedValue<string>("ConfirmDelete"), 
                LocalizationProvider.GetLocalizaedValue<string>("ConfirmDeleteTitle"), 
                MessageBoxButton.YesNo);
            
            if (result == MessageBoxResult.No) return;

            var typeItemsListView = this.TypeItemsListView;
        }
    }
}
