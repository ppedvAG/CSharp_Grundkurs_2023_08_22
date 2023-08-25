using System;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using Microsoft.Win32;

namespace M015_WPF
{
	public partial class MainWindow : Window
	{
		private int counter = 0;

		public MainWindow()
		{
			InitializeComponent();
			TB.Text = counter.ToString();
			//CB.ItemsSource = new []{ "1", "2", "3" };
			CB.ItemsSource = Enum.GetValues<DayOfWeek>();
			LB.ItemsSource = Enum.GetValues<DayOfWeek>();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			TB.Text = (++counter).ToString();
		}

		private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ComboBox combo = (ComboBox) sender;
			TB.Text = "Ausgewählt (CB): " + combo.SelectedItem;
		}

		private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			TB.Text = string.Join(',', LB.SelectedItems.OfType<DayOfWeek>().Select(e => e.ToString())) + " wurde ausgewählt";
		}

		private void CheckBox_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
		{

		}

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Du hast Datei geklickt", "Datei geklickt", MessageBoxButton.YesNo, MessageBoxImage.Information);
			if (result == MessageBoxResult.Yes)
			{
				Window1 w1 = new Window1();
				w1.ShowDialog();
				DialogResult = true;
			}
			else
			{
				OpenFileDialog ofd = new OpenFileDialog(); //SaveFileDialog
				ofd.ShowDialog();
				TB.Text = ofd.FileName;

				//Close();
			}
		}
	}
}
