using LilithModConfigureTool.Types;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace LilithModConfigureTool
{
    /// <summary>
    /// EditWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow(IType type)
        {
            InitializeComponent();
            currentType = type;
            currentType.Parse();
            currentType.AddControl(this);
        }

        public IType currentType { get; }

        ItemCollection tabItems
        {
            get
            {
                return this.ComponentTabControl.Items;
            }
        }

        public void AddTab(string tabName)
        {
            var tabItem = new TabItem();
            tabItem.Name = tabName;
            tabItem.Header = tabName;

            var grid = new Grid();
            for (int i = 0; i < 3; i++)
            {
                var cd = new ColumnDefinition();
                cd.Width = new GridLength(1, GridUnitType.Star);
                var rd = new RowDefinition();
                rd.Height = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions.Add(cd);
                grid.RowDefinitions.Add(rd);
            }

            tabItem.Content = grid;

            tabItems.Add(tabItem);
        }

        public void AddToGrid(FrameworkElement controlToAdd, int columnSpan = 1, int rowSpan = 1)
        {
            if (tabItems.Count == 0)
            {
                this.AddTab("test");
            }
            controlToAdd.SetValue(Grid.ColumnSpanProperty, columnSpan);
            controlToAdd.SetValue(Grid.RowSpanProperty, rowSpan);
            ((tabItems[0] as TabItem)?.Content as Grid)?.Children.Add(controlToAdd);
        }
    }
}
