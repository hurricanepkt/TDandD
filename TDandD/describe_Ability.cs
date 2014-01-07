using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSpec;

namespace TDandD
{
    class describe_Ability : nspec
    {
        Ability ability = new Ability();

        void given_an_Ability()
        {
            context["given it has a Value"] = () =>
            {
                it["the default should be 10"] = () => ability.Value.should_be(10);

                it["should allow value to be set to one"] = () =>
                {
                    ability.Value = 1;
                    ability.Value.should_be(1);
                };

                it["should allow value to be set to 7"] = () =>
                {
                    ability.Value = 7;
                    ability.Value.should_be(7);
                };

                it["should allow value to be set to 20"] = () =>
                {
                    ability.Value = 20;
                    ability.Value.should_be(20);
                };

                it["should throw an exception when trying to set the value to less than one"] =
                    expect<ArgumentOutOfRangeException>(() => ability.Value = 0);

                it["should throw an exception when trying to set the value to greater than 20"] =
                    expect<ArgumentOutOfRangeException>(() => ability.Value = 21);
            };

            context["given it has a Modifier"] = () =>
            {
                it["should have Modifier of -5 when value is 1"] = () =>
                {
                    ability.Value = 1;
                    ability.Modifier.should_be(-5);
                }; 
				it["should have Modifier of -4 when value is 2"] = () =>
				{
					ability.Value = 2;
					ability.Modifier.should_be(-4);
				};
                it["should have Modifier of 0 when value is 10"] = () =>
                {
                    ability.Value = 10;
                    ability.Modifier.should_be(0);
                };
                it["should have Modifier of 3 when value is 17"] = () =>
                {
                    ability.Value = 17;
                    ability.Modifier.should_be(3); 
                };
            };
        }
    }
}
