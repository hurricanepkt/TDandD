//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NSpec;

//namespace TDandD.NSpecExamples
//{
//	class describe_NSpec : nspec
//	{
//		void before_each()
//		{
//			Console.WriteLine("I run before each test.");
//		}

//		void it_works_here()
//		{
//			"hello".should_be("hello");
//		}

//		void a_category_of_examples()
//		{
//			before = () => Console.WriteLine("I run before each test defined in this context.");

//			it["also works here"] = () => "hello".should_be("hello");

//			it["works here too"] = () => "hello".should_be("hello");
//		}
//	}

//	class category_of_examples : describe_NSpec
//	{
//		void before_each()
//		{
//			Console.WriteLine("I run before each test defined in this context.");
//		}

//		void it_also_works_here()
//		{
//			"hello".should_be("hello");
//		}

//		void it_works_here_too()
//		{
//			"hello".should_be("hello");
//		}
//	}
//}
