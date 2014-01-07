//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NSpec;

//namespace TDandD.NSpecExamples
//{
//	class describe_contexts : nspec
//	{
//		//context methods require an underscore. For more info see DefaultConventions.cs.
//		void describe_Account()
//		{
//			//contexts can be nested n-deep and contain befores and specifications
//			context["when withdrawing cash"] = () =>
//			{
//				before = () => account = new Account();
//				context["account is in credit"] = () =>
//				{
//					before = () => account.Balance = 500;
//					it["the Account dispenses cash"] = () => account.CanWithdraw(60).should_be_true();
//				};
//				context["account is overdrawn"] = () =>
//				{
//					before = () => account.Balance = -500;
//					it["the Account does not dispense cash"] = () => account.CanWithdraw(60).should_be_false();
//				};
//			};
//		}
//		private Account account;
//	}
//}
