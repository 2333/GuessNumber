using System;
using System.IO;
using System.Collections.Generic;

namespace GuessNumber
{
	public class StartGame
	{
		static int difNum;

		public void newGame (int diffi)
		{
			while(true){
				//创建新数字
				NumberGenerator NG = new NumberGenerator ();
				int[] numbers = NG.getNumbers ();
				int[] number = new int[diffi + 3];

				difNum = diffi + 3;

				for (int j = 0; j <= diffi + 2; j++) {
					number [j] = numbers [j];
				}

				string tmp;
				int[] playerInput = new int[difNum];//用户可输入的容量
//				foreach(int num in number)
//					Console.Write(num);
				Console.WriteLine ();
				Console.WriteLine ("此次数字将"+difNum+"位数字");
				showExample (difNum);
				Console.WriteLine("您有10次机会猜出正确数字~ Good Luck!");

				//StreamReader SR = new StreamReader (stream);

				//开始游戏，读取玩家猜得数字
				int i = 1;
				for (; i <= 10; i++) {
					Console.Write ("第" + i + "次：");
					do{
						tmp = Console.ReadLine ();
						try {
							//作弊。。。。
							if(tmp.Equals("answer"))
							{
								foreach(int num in number)
									Console.Write(num);
								Console.WriteLine();
								continue;
							}

							for (int n = 0; n <= playerInput.Length - 1; n++)//清空input内容
								playerInput [n] = 0;
							for (int j = 0; j <= playerInput.Length - 1; j++) {
//								if (tmp [j] == '\0' || tmp [j] == '0')
//									break;
								playerInput [j] = (int)(tmp [j] - 48);
							}
							if(playerInput.Length<tmp.Length)
								Console.WriteLine("只截取了前"+difNum+"位哦");
						} catch (Exception ex) {
							Console.WriteLine (ex);
						}
					}
					while(!FormatCheck (tmp,playerInput));
//					foreach (int num in playerInput)
//						Console.Write (num);
					if (CheckNumber (number, playerInput)) {
						if (1 <= i && i <= 3)
							Console.WriteLine ("碉堡了，你真牛逼!");
						else if (4 <= i && i <= 6)
							Console.WriteLine ("少侠真是一代奇才！");
						else
							Console.WriteLine("真棒！猜出来了~！");
						break;
					}
					else
						continue;
				}
				if (i == 11) {
					Console.WriteLine ("很遗憾，游戏结束~");
					Console.Write("答案是: ");
					foreach(int num in number)
						Console.Write(num);
					Console.WriteLine ();
				}

				int[] restart = Restart(diffi);
				if (restart[0] == 1 ) {
					diffi = restart [1];
					continue;
				}
				else
					break;
			}
		}

		//判断每次猜测，是否与题目数字相同
		private bool CheckNumber (int[] number, int[] playerInput)
		{
			List<int> numberList = new List<int> (number);
			int A = 0;
			int B = 0;
//			string tmp;

			//判断玩家输入的数字长度相同
//			if (number.Length != playerInput.Length) {
//				Console.WriteLine ("输入的数字不符合格式，请重试");
//				tmp = Console.ReadLine();
//				for(int j = 0; j<tmp.Length-1; j++)
//				{
//					playerInput [j] = (int)tmp [j];
//				}
//			}
			//进行判断，输入数是否与题目数相同
			for (int i = 0; i <= number.Length - 1; i++) {
				if ((numberList.IndexOf (playerInput [i]) ) == -1)
					continue;
				else if (number [i] == playerInput [i]) {
					A++;
				}
				else
					B++;
			}
			if (A == difNum)
				return true;
			else {
				Console.WriteLine (A + "A" + B + "B");
				return false;
			}
		}

		//检查输入格式是否正确
		private bool FormatCheck(string tmp, int[] playerInput)
		{
			List<int> checkNum = new List<int> (playerInput);
			bool[] sameCheck = new bool[11];
			int temp = 0;
			bool flag = true;

			if(tmp!= "")
				flag = int.TryParse (tmp,out temp);
			for (int i = 0; i < sameCheck.Length; i++)
				sameCheck [i] = true;

			//判断是否有重复数字
			for (int i = 0; i < playerInput.Length; i++) {
//				Console.WriteLine ((int)'z'+" "+(int)'A');
				if (playerInput [i] < 1 || playerInput[i]>=10)
					continue;
				if (sameCheck [playerInput [i] - 1] != false)
					sameCheck [playerInput [i] - 1] = false;
				else
					sameCheck [10] = false;//如果有，则第11位数组反转。
			}

			if (playerInput.Length!=difNum || checkNum.Contains (0) || !sameCheck [10]||flag == false) {//检查是否是难度的位数
				Console.WriteLine ("输入格式错误!");
				Console.Write ("请重试：");
				return false;
			}
			else
				return true;
		}

		private int[] Restart(int diffi)
		{
			Console.WriteLine ("再来一局？按任意键开始新游戏，Esc键退出");
			ConsoleKeyInfo tmp = Console.ReadKey ();
			int[] result = new int[2]; 

			if (tmp.Key == ConsoleKey.Escape) {
				result [0] = 0;
				result [1] = 0;
			}
			else {
				diffi = ChangeDif(diffi);
				result [0] = 1;
				result [1] = diffi;
			}
			return result;
		}

		void showExample (int difNum)
		{
			switch (difNum) {
			case 4:
				Console.WriteLine ("实例：\n生成数：1234\n输入：1345\n反馈：1A2B\n");
				break;
			case 5:
				Console.WriteLine ("实例：\n生成数：12345\n输入：13456\n反馈：1A3B\n");
				break;
			case 6:
				Console.WriteLine ("实例：\n生成数：123456\n输入：134567\n反馈：1A4B\n");
				break;
			}
		}

		int ChangeDif (int diffi)
		{
			Console.WriteLine ("换个难度试试？");
			Console.WriteLine("1、简单 2、正常 3、困难");
			int dif = Console.ReadKey().KeyChar;
			switch (dif) {
			case 49:
				diffi = 1;
				break;
			case 50:
				diffi = 2;
				break;
			case 51:
				diffi = 3;
				break;
			default :
				diffi = 1;
				break;
			}
			return diffi;
		}
	}
}

