using System;

namespace GuessNumber
{
	public class NumberGenerator
	{
		static int maxlength = 6;
		int[] numbers = new int[maxlength];

		public NumberGenerator ()
		{
			Random rm = new Random (unchecked((int)DateTime.Now.Ticks));
			int tmp = 0;
			int minValue = 1;
			int maxValue = 10;

			for (int n = 0; n < maxlength; n++) {
				tmp = rm.Next (minValue, maxValue);
				numbers[n] = getNumber (numbers, tmp, minValue, maxValue, rm);
			}

		}
		//用递归的方法生成随机数，并检查是否与数组内的数字相同
		private int getNumber (int[] numbers, int tmp, int minValue, int maxValue, Random rm)
		{
			int n = 0;
			while (n <= numbers.Length - 1) {
				if (numbers[n] == tmp) {
					tmp = rm.Next (minValue, maxValue);
					tmp = getNumber (numbers, tmp, minValue, maxValue, rm); //递归生成
				}
				n++;
			}
			return tmp;
		}
		public int[] getNumbers()
		{
			return numbers;
		}
	}
}

