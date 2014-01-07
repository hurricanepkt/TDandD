//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TDandD.NSpecExamples
//{
//	class custom_assertions
//	{
//		void it_is_a_custom_assertion()
//		{
//			16.is_less_than(31);
//		}
//	} 

//	public static class AssertionExtensions
//	{
//		public static void is_less_than(this int left, int right)
//		{
//			if(left >= right)
//			{
//				throw new InvalidOperationException(
//				   string.Format("{0} was not less than {1}", left, right));
//			}
//		}
//	}
//}
