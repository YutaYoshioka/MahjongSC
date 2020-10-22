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

namespace MahjongSC_for_Windows
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ResetButton_Click(object sender, RoutedEventArgs e)
		{
			LogLabel.Content = "子\n平和,七対子以外: 20符\n門前ロン: 10符\n中張牌2明刻: 4符\n幺九字牌1暗刻: 8符\n役牌頭: 2符\n待ち両面・シャボ以外: 2符\n符合計: 46→50符\nーーーーーーーーーーーーーーーーーーーーー\n4翻50符  満貫(8000点)";
		}
	}
}
