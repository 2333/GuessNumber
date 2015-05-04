using System;

namespace GuessNumber
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			StartGame game = new StartGame ();
			//开始游戏提示	
			Console.WriteLine("Welcome to BroK's NumberGuess Game!\n");
			Console.WriteLine("游戏规则请按‘h’");
			Console.WriteLine("按‘回车键’开始游戏~");
			ConsoleKeyInfo reader = Console.ReadKey ();

			if (reader.Key == ConsoleKey.Enter || reader.KeyChar == '\r') {
				Console.WriteLine("选择一个难度吧？1、正常 2、中等 3、困难");
				chooseDif (game);
			}
			else if (reader.KeyChar == 'h') {
				Helper();
			} else {
				Console.WriteLine ("下次再来玩~");
				Console.Read ();
			}
		}
		public static void Helper()
		{
			Console.WriteLine ("");
			Console.WriteLine ("根据难度不同，生成一个四-六位数，形如：12345，玩家有10次机会猜出该数字。\n" +
				"数字范围为1-9\n" +
				"每次结果将以xAxB的方式反馈\n" +
				"如果有一个数字正确，而位置不正确，显示1B\n" +
				"如果有一个数字位置都正确，显示1A\n" +
				"游戏结束后将给出答案~\n\n" +
				"按‘回车键’开始游戏，任意其他键键退出游戏");
			ConsoleKeyInfo reader = Console.ReadKey ();
			if (reader.Key == ConsoleKey.Enter || reader.KeyChar == '\r') {
				StartGame game = new StartGame ();
				chooseDif (game);
//				game.newGame ();
			}
			else{
				Console.WriteLine("再见！~");
				Console.Read();
			}
		}
		public static void chooseDif(StartGame game)
		{
			int diffi = Console.ReadKey().KeyChar;
			switch (diffi) {
			case 49:
				game.newGame (1);
				break;
			case 50:
				game.newGame (2);
				break;
			case 51:
				game.newGame (3);
				break;
			default :
				game.newGame (1);
				break;
			}
		}
}
}
