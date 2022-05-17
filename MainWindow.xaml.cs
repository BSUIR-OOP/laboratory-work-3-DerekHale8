using OOP3.Classes;
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
using System.Windows.Shapes;

namespace OOP3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DenizensOfAzeroth denizensList = new DenizensOfAzeroth();
        public MainWindow()
        {
            InitializeComponent();
            ChooseRace.Items.Add(new Pandaren());
            ChooseRace.Items.Add(new Orc());
            ChooseRace.Items.Add(new Worgen());
            ChooseRace.Items.Add(new Troll());
            ChooseRace.Items.Add(new Human());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Type type = ChooseRace.SelectedItem.GetType();
            Race t = (Race)Activator.CreateInstance(type);
            if (t != null)
            {
                t.CurrentLevel = Convert.ToInt32(AddCurrentLevel.Text);
                t.Health = Convert.ToInt32(AddCurrentHealth.Text);
                t.Power = Convert.ToInt32(AddPower.Text);
                t.DenizenName = AddName.Text;
            }
            denizensList.Add(t);
            ShowDenizens.Items.Clear();
            foreach (Race tr in denizensList)
                ShowDenizens.Items.Add(tr.ShowInfo());
        }

        private void Serialize_Click(object sender, RoutedEventArgs e)
        {
            BinarySerializator s = new BinarySerializator();
            File.WriteAllBytes(FileToSerialize.Text, s.Serialize(denizensList));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            denizensList.Remove(denizensList.Get(ShowDenizens.SelectedIndex));
            ShowDenizens.Items.Clear();
            foreach (Race tr in denizensList)
                ShowDenizens.Items.Add(tr.ShowInfo());
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Race t = denizensList.Get(ShowDenizens.SelectedIndex);
            t.Health = Convert.ToInt32(EditCurrentHealth.Text);
            t.CurrentLevel = Convert.ToInt32(EditCurrentLevel.Text);
            t.Power = Convert.ToInt32(EditPower.Text);
            t.DenizenName = EditName.Text;
            ShowDenizens.Items.Clear();
            foreach (Race tr in denizensList)
                ShowDenizens.Items.Add(tr.ShowInfo());
        }

        private void Deserialize_Click(object sender, RoutedEventArgs e)
        {
            BinarySerializator s = new BinarySerializator();
            DenizensOfAzeroth tmp = s.Deserialize(File.ReadAllBytes(FileToDeserialize.Text));
            foreach (Race tr in tmp)
                denizensList.Add(tr);
            ShowDenizens.Items.Clear();
            foreach (Race tr in denizensList)
                ShowDenizens.Items.Add(tr.ShowInfo());
        }
    }
}
