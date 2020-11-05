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
		Brush GrayBrush;

		/// <summary>
		/// 3人麻雀
		/// </summary>
		bool isThreePlayers = false;

		/// <summary>
		/// 親
		/// </summary>
		bool isLeader = false;

		/// <summary>
		/// ツモ
		/// </summary>
		bool win_IsPick = false;

		/// <summary>
		/// 門前ロン
		/// </summary>
		bool win_IsConcealedHandDuck = false;

		/// <summary>
		/// 頭が役牌
		/// </summary>
		bool head_IsSlum = false;

		/// <summary>
		/// 頭が連風牌
		/// </summary>
		bool head_IsDoubleWindTile = false;

		/// <summary>
		/// 両面・シャボ待ち
		/// </summary>
		bool wait_Is2Gates = false;

		/// <summary>
		/// 翻数
		/// </summary>
		int doubles = 0;

		/// <summary>
		/// 中張牌 明刻
		/// </summary>
		int tiles28MT = 0;

		/// <summary>
		/// 中張牌 暗刻
		/// </summary>
		int tiles28CT = 0;

		/// <summary>
		/// 中張牌 明槓
		/// </summary>
		int tiles28MF = 0;

		/// <summary>
		/// 中張牌 暗槓
		/// </summary>
		int tiles28CF = 0;

		/// <summary>
		/// 幺九字牌 明刻
		/// </summary>
		int tiles19hMT = 0;

		/// <summary>
		/// 幺九字牌 暗刻
		/// </summary>
		int tiles19hCT = 0;

		/// <summary>
		/// 幺九字牌 明槓
		/// </summary>
		int tiles19hMF = 0;

		/// <summary>
		/// 幺九字牌 暗槓
		/// </summary>
		int tiles19hCF = 0;

		/// <summary>
		/// 平和
		/// </summary>
		bool isAllSequenceHand = false;

		/// <summary>
		/// 七対子
		/// </summary>
		bool isSevenPairs = false;


		public MainWindow()
		{
			InitializeComponent();

			GrayBrush = new SolidColorBrush(Color.FromRgb(0xff, 0xff, 0x90));

		}

		private void ResetButton_Click(object sender, RoutedEventArgs e)
		{
			// 初期化書く時間ないからとりあえずリスタートさせる
			// でもWPFだといろいろ面倒だからWinFormのを無理やり呼び出してみた
			// 要修正！！

			System.Windows.Forms.Application.Restart();
			System.Windows.Application.Current.Shutdown();


			/*
			isThreePlayers = false;


			isLeader = false;


			win_IsPick = false;


			 win_IsConcealedHandDuck = false;


			 head_IsSlum = false;


			 head_IsDoubleWindTile = false;


			 wait_Is2Gates = false;


			 doubles = 0;


			 tiles28MT = 0;


			 tiles28CT = 0;


			 tiles28MF = 0;


			 tiles28CF = 0;


			 tiles19hMT = 0;


			 tiles19hCT = 0;


			 tiles19hMF = 0;


			 tiles19hCF = 0;


			 isAllSequenceHand = false;


			isSevenPairs = false;
			*/

		}

		/// <summary>
		/// 3人麻雀
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void IsThreePlayers_Click(object sender, RoutedEventArgs e)
		{
			if (isThreePlayers)
			{
				isThreePlayers = false;
				IsThreePlayers.Background = Brushes.LightGray;
			}
			else
			{
				isThreePlayers = true;
				IsThreePlayers.Background = Brushes.Gray;
			}
		}

		/// <summary>
		/// 親
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void IsLeader_Click(object sender, RoutedEventArgs e)
		{
			if (isLeader)
			{
				isLeader = false;
				IsLeader.Background = Brushes.LightGray;
			}
			else
			{
				isLeader = true;
				IsLeader.Background = Brushes.Gray;
			}
		}

		/// <summary>
		/// ツモ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Win_IsPick_Click(object sender, RoutedEventArgs e)
		{
			if (win_IsPick)
			{
				win_IsPick = false;
				Win_IsPick.Background = Brushes.LightGray;
			}
			else
			{
				win_IsPick = true;
				Win_IsPick.Background = Brushes.Gray;

				if (win_IsConcealedHandDuck)
				{
					win_IsConcealedHandDuck = false;
					Win_IsConcealedHandDuck.Background = Brushes.LightGray;
				}
			}
		}

		/// <summary>
		/// 門前ロン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Win_IsConcealedHandDuck_Click(object sender, RoutedEventArgs e)
		{
			if (win_IsConcealedHandDuck)
			{
				win_IsConcealedHandDuck = false;
				Win_IsConcealedHandDuck.Background = Brushes.LightGray;
			}
			else
			{
				win_IsConcealedHandDuck = true;
				Win_IsConcealedHandDuck.Background = Brushes.Gray;

				if (win_IsPick)
				{
					win_IsPick = false;
					Win_IsPick.Background = Brushes.LightGray;
				}
			}
		}

		/// <summary>
		/// 役牌頭
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Head_IsSlum_Click(object sender, RoutedEventArgs e)
		{
			if (head_IsSlum)
			{
				head_IsSlum = false;
				Head_IsSlum.Background = Brushes.LightGray;
			}
			else
			{
				head_IsSlum = true;
				Head_IsSlum.Background = Brushes.Gray;

				if (head_IsDoubleWindTile)
				{
					head_IsDoubleWindTile = false;
					Head_IsDoubleWindTile.Background = Brushes.LightGray;
				}
			}
		}

		/// <summary>
		/// 連風牌頭
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Head_IsDoubleWindTile_Click(object sender, RoutedEventArgs e)
		{
			if (head_IsDoubleWindTile)
			{
				head_IsDoubleWindTile = false;
				Head_IsDoubleWindTile.Background = Brushes.LightGray;
			}
			else
			{
				head_IsDoubleWindTile = true;
				Head_IsDoubleWindTile.Background = Brushes.Gray;

				if (head_IsSlum)
				{
					head_IsSlum = false;
					Head_IsSlum.Background = Brushes.LightGray;
				}
			}
		}

		/// <summary>
		/// 両面・シャボ待ち
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Wait_Is2Gates_Click(object sender, RoutedEventArgs e)
		{
			if (wait_Is2Gates)
			{
				wait_Is2Gates = false;
				Wait_Is2Gates.Background = Brushes.LightGray;
			}
			else
			{
				wait_Is2Gates = true;
				Wait_Is2Gates.Background = Brushes.Gray;
			}
		}

		/// <summary>
		/// 翻数プラス
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DoublesPlus_Click(object sender, RoutedEventArgs e)
		{
			doubles++;
			DoublesNum.Content = doubles.ToString() + "翻";
		}

		/// <summary>
		/// 翻数マイナス
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DoublesMinus_Click(object sender, RoutedEventArgs e)
		{
			if (doubles > 0)
				doubles--;
			DoublesNum.Content = doubles.ToString() + "翻";
		}

		/// <summary>
		/// 翻数のラベルをクリックされたときリセット
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DoublesNum_MouseDown(object sender, MouseButtonEventArgs e)
		{
			doubles = 0;
			DoublesNum.Content = doubles.ToString() + "翻";
		}

		private void Tiles28MT_MouseDown(object sender, MouseButtonEventArgs e)
		{
			tiles28MT++;
			Tiles28MT.Content = tiles28MT.ToString() + "組";
		}

		private void Tiles28CT_MouseDown(object sender, MouseButtonEventArgs e)
		{
			tiles28CT++;
			Tiles28CT.Content = tiles28CT.ToString() + "組";
		}

		private void Tiles28MF_MouseDown(object sender, MouseButtonEventArgs e)
		{
			tiles28MF++;
			Tiles28MF.Content = tiles28MF.ToString() + "組";
		}

		private void Tiles28CF_MouseDown(object sender, MouseButtonEventArgs e)
		{
			tiles28CF++;
			Tiles28CF.Content = tiles28CF.ToString() + "組";
		}

		private void Tiles19hMT_MouseDown(object sender, MouseButtonEventArgs e)
		{
			tiles19hMT++;
			Tiles19hMT.Content = tiles19hMT.ToString() + "組";
		}

		private void Tiles19hCT_MouseDown(object sender, MouseButtonEventArgs e)
		{
			tiles19hCT++;
			Tiles19hCT.Content = tiles19hCT.ToString() + "組";
		}

		private void Tiles19hMF_MouseDown(object sender, MouseButtonEventArgs e)
		{
			tiles19hMF++;
			Tiles19hMF.Content = tiles19hMF.ToString() + "組";
		}

		private void Tiles19hCF_MouseDown(object sender, MouseButtonEventArgs e)
		{
			tiles19hCF++;
			Tiles19hCF.Content = tiles19hCF.ToString() + "組";
		}

		/// <summary>
		/// 平和
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void IsAllSequenceHand_Click(object sender, RoutedEventArgs e)
		{

		}

		/// <summary>
		/// 七対子
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void IsSevenPairs_Click(object sender, RoutedEventArgs e)
		{

		}

		/// <summary>
		/// 計算ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Run_Click(object sender, RoutedEventArgs e)
		{
			if (doubles == 0)
			{
				LogLabel.Content = "エラー: 翻数を入力してください";
			}

			// 符数
			var subPoints = 0;

			// 最終点数
			var points = 0;

			// 親が払う点数
			var leaderPoints = 0;

			// 子が払う点数
			var nonLeaderPoints = 0;

			// 計算過程
			var processDocument = "";

			// 親？
			if (isLeader)
			{
				processDocument += "親\n";
			}
			else
			{
				processDocument += "子\n";
			}

			// 平和・七対子・その他のどれか
			if (isAllSequenceHand)
			{
				// 平和
				subPoints = 20;
				processDocument += "平和: 20符\n";

				// ロンの場合は+10符
				if (!win_IsPick)
				{
					subPoints += 10;
					processDocument += "門前ロン: 10符\n";
				}

				processDocument += "符合計: " + subPoints.ToString() + "符";
			}
			else if (isSevenPairs)
			{
				// 七対子
				subPoints = 25;
				processDocument += "七対子: 25符\n";

				//点パネはなし
				processDocument += "符合計: " + subPoints.ToString() + "符";
			}
			else
			{
				// その他
				subPoints += 20;
				processDocument += "平和,七対子以外: 20符\n";

				// あがり方
				if (win_IsPick)
				{
					subPoints += 2;
					processDocument += "ツモ: 2符\n";
				}
				else if (win_IsConcealedHandDuck)
				{
					subPoints += 10;
					processDocument += "門前ロン: 10符\n";
				}


				// 刻子・槓子の符計算
				if (tiles28MT != 0)
				{
					subPoints += tiles28MT * 2;
					processDocument += "中張牌" + tiles28MT.ToString() + "明刻: " + (tiles28MT * 2).ToString() + "符\n";
				}

				if (tiles28CT != 0)
				{
					subPoints += tiles28CT * 4;
					processDocument += "中張牌" + tiles28CT.ToString() + "暗刻: " + (tiles28CT * 4).ToString() + "符\n";
				}

				if (tiles28MF != 0)
				{
					subPoints += tiles28MF * 8;
					processDocument += "中張牌" + tiles28MF.ToString() + "明槓: " + (tiles28MF * 8).ToString() + "符\n";
				}

				if (tiles28CF != 0)
				{
					subPoints += tiles28CF * 16;
					processDocument += "中張牌" + tiles28CF.ToString() + "暗槓: " + (tiles28CF * 16).ToString() + "符\n";
				}

				if (tiles19hMT != 0)
				{
					subPoints += tiles19hMT * 4;
					processDocument += "幺九字牌" + tiles19hMT.ToString() + "明刻: " + (tiles19hMT * 4).ToString() + "符\n";
				}

				if (tiles19hCT != 0)
				{
					subPoints += tiles19hCT * 8;
					processDocument += "幺九字牌" + tiles19hCT.ToString() + "暗刻: " + (tiles19hCT * 8).ToString() + "符\n";
				}

				if (tiles19hMF != 0)
				{
					subPoints += tiles19hMF * 16;
					processDocument += "幺九字牌" + tiles19hMF.ToString() + "明槓: " + (tiles19hMF * 16).ToString() + "符\n";
				}

				if (tiles19hCF != 0)
				{
					subPoints += tiles19hCF * 32;
					processDocument += "幺九字牌" + tiles19hCF.ToString() + "暗槓: " + (tiles19hCF * 32).ToString() + "符\n";
				}


				// 頭
				if (head_IsSlum)
				{
					// 役牌
					subPoints += 2;
					processDocument += "役牌頭: 2符\n";
				}
				else if (head_IsDoubleWindTile)
				{
					// 連続風牌
					subPoints += 4;
					processDocument += "連風牌: 4符\n";
				}


				// 待ち牌
				if (!wait_Is2Gates)
				{
					// 両面・シャボ以外
					subPoints += 2;
					processDocument += "待ち両面・シャボ以外: 2符\n";
				}

				// 点パネ
				processDocument += "符合計: " + subPoints.ToString() + "→";
				subPoints = (int)(Math.Ceiling(subPoints / 10.0) * 10);
				processDocument += subPoints.ToString() + "符\n";
			}


			// ここから平和・七対子も同じ処理

			processDocument += "ーーーーーーーーーーーーーーーーーーーーー\n";

			// 3人麻雀か4人麻雀かで点数計算が異なる
			if (isThreePlayers)
			{

			}
			else
			{
				var point = PointCalculate_Four(doubles, subPoints, win_IsPick, isLeader);
				if (isLeader)
				{
					if (win_IsPick)
					{
						processDocument += doubles.ToString() + "翻" + subPoints.ToString() + "符　" + point[0].ToString() + "点 (" + point[1].ToString() + "点オール)";
						LogLabel.Content = processDocument;
					}
					else
					{
						processDocument += doubles.ToString() + "翻" + subPoints.ToString() + "符　" + point[0].ToString() + "点";
						LogLabel.Content = processDocument;
					}

					switch (point[0])
					{
						case 12000:
							SlumDisplay.Content = "満貫！";
							break;
						case 18000:
							SlumDisplay.Content = "跳満！";
							break;
						case 24000:
							SlumDisplay.Content = "倍満！";
							break;
						case 36000:
							SlumDisplay.Content = "三倍満！";
							break;
						case 48000:
							SlumDisplay.Content = "数え役満！";
							break;
						default:
							SlumDisplay.Content = "";
							break;
					}
				}
				else
				{
					if (win_IsPick)
					{
						processDocument += doubles.ToString() + "翻" + subPoints.ToString() + "符　" + point[0].ToString() + "点 (親:" + point[1].ToString() + "点, 子:" + point[2].ToString() + "点)";
						LogLabel.Content = processDocument;

						ResultPoint_Leader.Content = "親: " + point[1].ToString() + "点";
						ResultPoint_NonLeader.Content = "子: " + point[2].ToString() + "点";
					}
					else
					{
						processDocument += doubles.ToString() + "翻" + subPoints.ToString() + "符　" + point[0].ToString() + "点";
						LogLabel.Content = processDocument;
					}

					switch (point[0])
					{
						case 8000:
							SlumDisplay.Content = "満貫！";
							break;
						case 12000:
							SlumDisplay.Content = "跳満！";
							break;
						case 16000:
							SlumDisplay.Content = "倍満！";
							break;
						case 24000:
							SlumDisplay.Content = "三倍満！";
							break;
						case 32000:
							SlumDisplay.Content = "数え役満！";
							break;
						default:
							SlumDisplay.Content = "";
							break;
					}
				}

				ResultPoint.Content = point[0].ToString() + "点";
			}



		}

		/// <summary>
		/// 翻数と符数から4人麻雀における点数を計算します。
		/// </summary>
		/// <param name="doubles">翻数</param>
		/// <param name="subPoint">符数</param>
		/// <param name="isPick">ツモ？</param>
		/// <param name="isLeader">親？</param>
		/// <returns>点数。子がツモあがりの場合は 0:合計, 1:親，2:子 の払う点数。親がツモあがりの場合は 0:合計, 1:子が払う点数。ロンの場合は 0:合計 のみ。</returns>
		private int[] PointCalculate_Four(int doubles, int subPoint, bool isPick, bool isLeader)
		{
			if (isLeader)
			{
				// 親のあがり
				var point = 0;
				var sumPoint = 0;

				if (isPick)
				{
					// ツモ
					if (doubles == 1)
					{
						switch (subPoint)
						{
							case 30:
								point = 500;
								sumPoint = point * 3;
								break;
							case 40:
								point = 700;
								sumPoint = point * 3;
								break;
							case 50:
								point = 800;
								sumPoint = point * 3;
								break;
							case 60:
								point = 1000;
								sumPoint = point * 3;
								break;
							case 70:
								point = 1200;
								sumPoint = point * 3;
								break;
							case 80:
								point = 1300;
								sumPoint = point * 3;
								break;
							case 90:
								point = 1500;
								sumPoint = point * 3;
								break;
							case 100:
								point = 1600;
								sumPoint = point * 3;
								break;
							case 110:
								point = 1800;
								sumPoint = point * 3;
								break;
						}
					}
					else if (doubles == 2)
					{
						switch (subPoint)
						{
							case 20:
								point = 700;
								sumPoint = point * 3;
								break;
							case 30:
								point = 1000;
								sumPoint = point * 3;
								break;
							case 40:
								point = 1300;
								sumPoint = point * 3;
								break;
							case 50:
								point = 1600;
								sumPoint = point * 3;
								break;
							case 60:
								point = 2000;
								sumPoint = point * 3;
								break;
							case 70:
								point = 2300;
								sumPoint = point * 3;
								break;
							case 80:
								point = 2600;
								sumPoint = point * 3;
								break;
							case 90:
								point = 2900;
								sumPoint = point * 3;
								break;
							case 100:
								point = 3200;
								sumPoint = point * 3;
								break;
							case 110:
								point = 3600;
								sumPoint = point * 3;
								break;
						}
					}
					else if (doubles == 3)
					{
						switch (subPoint)
						{
							case 20:
								point = 1300;
								sumPoint = point * 3;
								break;
							case 25:
								point = 1600;
								sumPoint = point * 3;
								break;
							case 30:
								point = 2000;
								sumPoint = point * 3;
								break;
							case 40:
								point = 2600;
								sumPoint = point * 3;
								break;
							case 50:
								point = 3200;
								sumPoint = point * 3;
								break;
							case 60:
								point = 3900;
								sumPoint = point * 3;
								break;
							default:
								point = 4000;
								sumPoint = point * 3;
								break;
						}
					}
					else if (doubles == 4)
					{
						switch (subPoint)
						{
							case 20:
								point = 2600;
								sumPoint = point * 3;
								break;
							case 25:
								point = 3200;
								sumPoint = point * 3;
								break;
							case 30:
								point = 3900;
								sumPoint = point * 3;
								break;
							default:
								point = 4000;
								sumPoint = point * 3;
								break;
						}
					}
					else if (doubles == 5)
					{
						point = 4000;
						sumPoint = point * 3;
					}
					else if (doubles <= 7)
					{
						// 6,7
						point = 6000;
						sumPoint = point * 3;
					}
					else if (doubles <= 10)
					{
						// 8,9,10
						point = 8000;
						sumPoint = point * 3;
					}
					else if (doubles <= 12)
					{
						// 11,12
						point = 12000;
						sumPoint = point * 3;
					}
					else
					{
						// 13以上
						point = 16000;
						sumPoint = point * 3;
					}

					return new int[] { sumPoint, point };
				}
				else
				{
					// ロン
					if (doubles == 1)
					{
						switch (subPoint)
						{
							case 30:
								point = 1500;
								break;
							case 40:
								point = 2000;
								break;
							case 50:
								point = 2400;
								break;
							case 60:
								point = 2900;
								break;
							case 70:
								point = 3400;
								break;
							case 80:
								point = 3900;
								break;
							case 90:
								point = 4400;
								break;
							case 100:
								point = 4800;
								break;
							case 110:
								point = 5300;
								break;
						}
					}
					else if (doubles == 2)
					{
						switch (subPoint)
						{
							case 20:
								point = 2000;
								break;
							case 25:
								point = 2400;
								break;
							case 30:
								point = 2900;
								break;
							case 40:
								point = 3900;
								break;
							case 50:
								point = 4800;
								break;
							case 60:
								point = 5800;
								break;
							case 70:
								point = 6800;
								break;
							case 80:
								point = 7700;
								break;
							case 90:
								point = 8700;
								break;
							case 100:
								point = 9600;
								break;
							case 110:
								point = 10600;
								break;
						}
					}
					else if (doubles == 3)
					{
						switch (subPoint)
						{
							case 20:
								point = 3900;
								break;
							case 25:
								point = 4800;
								break;
							case 30:
								point = 5800;
								break;
							case 40:
								point = 7700;
								break;
							case 50:
								point = 9600;
								break;
							case 60:
								point = 11600;
								break;
							default:
								point = 12000;
								break;
						}
					}
					else if (doubles == 4)
					{
						switch (subPoint)
						{
							case 20:
								point = 7700;
								break;
							case 25:
								point = 9600;
								break;
							case 30:
								point = 11600;
								break;
							default:
								point = 12000;
								break;
						}
					}
					else if (doubles == 5)
					{
						point = 12000;
					}
					else if (doubles <= 7)
					{
						// 6,7
						point = 18000;
					}
					else if (doubles <= 10)
					{
						// 8,9,10
						point = 24000;
					}
					else if (doubles <= 12)
					{
						// 11,12
						point = 36000;
					}
					else
					{
						// 13以上
						point = 48000;
					}

					return new int[] { point };
				}
			}
			else
			{
				// 子のあがり

				// 親
				var Lpoint = 0;
				// 子
				var Npoint = 0;

				var sumPoint = 0;

				if (isPick)
				{
					// ツモ
					if (doubles == 1)
					{
						switch (subPoint)
						{
							case 30:
								Lpoint = 500;
								Npoint = 300;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 40:
								Lpoint = 700;
								Npoint = 400;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 50:
								Lpoint = 800;
								Npoint = 400;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 60:
								Lpoint = 1000;
								Npoint = 500;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 70:
								Lpoint = 1200;
								Npoint = 600;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 80:
								Lpoint = 1300;
								Npoint = 700;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 90:
								Lpoint = 1500;
								Npoint = 800;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 100:
								Lpoint = 1600;
								Npoint = 800;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 110:
								Lpoint = 1800;
								Npoint = 900;
								sumPoint = Lpoint + Npoint * 2;
								break;
						}
					}
					else if (doubles == 2)
					{
						switch (subPoint)
						{
							case 20:
								Lpoint = 700;
								Npoint = 400;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 30:
								Lpoint = 1000;
								Npoint = 500;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 40:
								Lpoint = 1300;
								Npoint = 700;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 50:
								Lpoint = 1600;
								Npoint = 800;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 60:
								Lpoint = 2000;
								Npoint = 1000;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 70:
								Lpoint = 2300;
								Npoint = 1200;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 80:
								Lpoint = 2600;
								Npoint = 1300;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 90:
								Lpoint = 2900;
								Npoint = 1500;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 100:
								Lpoint = 3200;
								Npoint = 1600;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 110:
								Lpoint = 3600;
								Npoint = 1800;
								sumPoint = Lpoint + Npoint * 2;
								break;
						}
					}
					else if (doubles == 3)
					{
						switch (subPoint)
						{
							case 20:
								Lpoint = 1300;
								Npoint = 700;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 25:
								Lpoint = 1600;
								Npoint = 800;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 30:
								Lpoint = 2000;
								Npoint = 1000;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 40:
								Lpoint = 2600;
								Npoint = 1300;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 50:
								Lpoint = 3200;
								Npoint = 1600;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 60:
								Lpoint = 3900;
								Npoint = 2000;
								sumPoint = Lpoint + Npoint * 2;
								break;
							default:
								Lpoint = 4000;
								Npoint = 2000;
								sumPoint = Lpoint + Npoint * 2;
								break;
						}
					}
					else if (doubles == 4)
					{
						switch (subPoint)
						{
							case 20:
								Lpoint = 2600;
								Npoint = 1300;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 25:
								Lpoint = 3200;
								Npoint = 1600;
								sumPoint = Lpoint + Npoint * 2;
								break;
							case 30:
								Lpoint = 3900;
								Npoint = 2000;
								sumPoint = Lpoint + Npoint * 2;
								break;
							default:
								Lpoint = 4000;
								Npoint = 2000;
								sumPoint = Lpoint + Npoint * 2;
								break;
						}
					}
					else if (doubles == 5)
					{
						Lpoint = 4000;
						Npoint = 2000;
						sumPoint = Lpoint + Npoint * 2;
					}
					else if (doubles <= 7)
					{
						// 6,7
						Lpoint = 6000;
						Npoint = 3000;
						sumPoint = Lpoint + Npoint * 2;
					}
					else if (doubles <= 10)
					{
						// 8,9,10
						Lpoint = 8000;
						Npoint = 4000;
						sumPoint = Lpoint + Npoint * 2;
					}
					else if (doubles <= 12)
					{
						// 11,12
						Lpoint = 12000;
						Npoint = 6000;
						sumPoint = Lpoint + Npoint * 2;
					}
					else
					{
						// 13以上
						Lpoint = 16000;
						Npoint = 8000;
						sumPoint = Lpoint + Npoint * 2;
					}

					return new int[] { sumPoint, Lpoint, Npoint };
				}
				else
				{
					// ロン
					if (doubles == 1)
					{
						switch (subPoint)
						{
							case 30:
								Lpoint = 1000;
								break;
							case 40:
								Lpoint = 1300;
								break;
							case 50:
								Lpoint = 1600;
								break;
							case 60:
								Lpoint = 2000;
								break;
							case 70:
								Lpoint = 2300;
								break;
							case 80:
								Lpoint = 2600;
								break;
							case 90:
								Lpoint = 2900;
								break;
							case 100:
								Lpoint = 3200;
								break;
							case 110:
								Lpoint = 3600;
								break;
						}
					}
					else if (doubles == 2)
					{
						switch (subPoint)
						{
							case 20:
								Lpoint = 1300;
								break;
							case 25:
								Lpoint = 1600;
								break;
							case 30:
								Lpoint = 2000;
								break;
							case 40:
								Lpoint = 2600;
								break;
							case 50:
								Lpoint = 3200;
								break;
							case 60:
								Lpoint = 3900;
								break;
							case 70:
								Lpoint = 4500;
								break;
							case 80:
								Lpoint = 5200;
								break;
							case 90:
								Lpoint = 5800;
								break;
							case 100:
								Lpoint = 6400;
								break;
							case 110:
								Lpoint = 7100;
								break;
						}
					}
					else if (doubles == 3)
					{
						switch (subPoint)
						{
							case 20:
								Lpoint = 2600;
								break;
							case 25:
								Lpoint = 3200;
								break;
							case 30:
								Lpoint = 3900;
								break;
							case 40:
								Lpoint = 5200;
								break;
							case 50:
								Lpoint = 6400;
								break;
							case 60:
								Lpoint = 7700;
								break;
							default:
								Lpoint = 8000;
								break;
						}
					}
					else if (doubles == 4)
					{
						switch (subPoint)
						{
							case 20:
								Lpoint = 5200;
								break;
							case 25:
								Lpoint = 6400;
								break;
							case 30:
								Lpoint = 7700;
								break;
							default:
								Lpoint = 8000;
								break;
						}
					}
					else if (doubles == 5)
					{
						Lpoint = 8000;
					}
					else if (doubles <= 7)
					{
						// 6,7
						Lpoint = 12000;
					}
					else if (doubles <= 10)
					{
						// 8,9,10
						Lpoint = 16000;
					}
					else if (doubles <= 12)
					{
						// 11,12
						Lpoint = 24000;
					}
					else
					{
						// 13以上
						Lpoint = 32000;
					}

					return new int[] { Lpoint };
				}
			}
		}

	}
}
