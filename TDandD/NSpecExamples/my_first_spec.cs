//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NSpec;

//namespace TDandD.NSpecExamples
//{
//	class my_first_spec : nspec
//	{
//		//System.Diagnostics.Debugger.Launch();

//		string name;

//		void before_each() { name = "NSpec"; }

//		void it_works()
//		{
//			name.should_be("NSpec");
//		}

//		void describe_nesting()
//		{
//			before = () => name += " BDD";

//			it["works here"] = () => name.should_be("NSpec BDD");

//			it["and here"] = () => name.should_be("NSpec BDD");
//		}
//	}
//}