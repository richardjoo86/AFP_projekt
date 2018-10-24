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

namespace AFP_projekt
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			using (AFP_DBEntities db = new AFP_DBEntities())
			{
				User usr = db.User.FirstOrDefault(p => p.Id == 1);
				if (usr != null)
				{
					lblName.Content = usr.Name;
				}
			}

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			using (AFP_DBEntities db = new AFP_DBEntities())
			{
				User usr = new User();
				int maxId = db.User.Select(p => p.Id).Max();
				usr.Id = maxId + 1;
				usr.Name = "Teszt felhasználó";

				db.User.Add(usr);
				db.SaveChanges();
			}
		}
	}
}
