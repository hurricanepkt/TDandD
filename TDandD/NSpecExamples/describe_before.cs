//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NSpec;

//namespace TDandD.NSpecExamples
//{
//	class describe_before : nspec
//	{
//		int number;
//		void they_run_before_each_example()
//		{
//			before = () => number = 1;
//			it["number should be 2"] = () => (number = number + 1).should_be(2);
//			//even though it was incremented in the previous example
//			//the before runs again for each spec resetting it to 1
//			it["number should be 1"] = () => number.should_be(1);
//		}
//	}
//}
