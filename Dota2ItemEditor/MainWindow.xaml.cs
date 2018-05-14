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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dota2ItemEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProjectContext _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new ProjectContext();
            this.DataContext = _context;
            _context.Items.Add(new Dota2Item("item_example"));
            _context.Items[0].Fields.Add(new StringField("foo", "bar"));
            var table = new TableField("tableBaz");
            _context.Items[0].Fields.Add(table);
            table.Fields.Add(new StringField("a", "1"));
            table.Fields.Add(new StringField("b", "2"));
            table.Fields.Add(new StringField("c", "3"));
        }

        public void newItem(string name = "item_new")
        {
            if (_context != null)
            {
                _context.Items.Add(new Dota2Item(name));
            }
        }

        private void NewItem_Click(object sender, RoutedEventArgs e)
        {
            newItem();
        }
    }
}
