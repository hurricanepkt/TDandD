﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NSpec;

//namespace TDandD.NSpecExamples
//{
//	class describe_specifications : nspec
//	{
//		object someObject = null;

//		void when_creating_specifications()
//		{
//			//some of these specifications are meant to fail so you can see what the output looks like
//			it["true should be false"] = () => true.should_be_false();
//			it["enumerable should be empty"] = () => new int[] { }.should_be_empty();
//			it["enumerable should contain 1"] = () => new[] { 1 }.should_contain(1);
//			it["enumerable should not contain 1"] = () => new[] { 1 }.should_not_contain(1);
//			it["1 should be 2"] = () => 1.should_be(2);
//			it["1 should be 1"] = () => 1.should_be(1);
//			it["1 should not be 1"] = () => 1.should_not_be(1);
//			it["1 should not be 2"] = () => 1.should_not_be(2);
//			it["\"\" should not be null"] = () => "".should_not_be_null();
//			it["some object should not be null"] = () => someObject.should_not_be_null();
//			//EXPERIMENTAL - specify only takes a lambda and does 
//			//its best to make a sentence out of the code. YMMV.
//			specify = () => "ninja".should_not_be("pirate");
//		}
//	}
//}
