using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSpec;

namespace TDandD
{
    class describe_CharacterDexterity : nspec
    {
        Character bob;
        private const int default_ArmorClass = Character.DEFAULT_ARMORCLASS;

        void before_each()
        {
            bob = new Character();
        }
        void when_Dexterity_modifier_applies()
        {
            context["given Dexterity Value is 20"] = () =>
            {
                before = () => bob.Dexterity.Value = 20;
                it["ArmorClass should be increased by 5"] = () => bob.ArmorClass.should_be(default_ArmorClass + 5);
            };

            context["given Dexterity Value is 1"] = () =>
            {
                before = () => bob.Dexterity.Value = 1;
                it["ArmorClass should be decreased by 5"] = () => bob.ArmorClass.should_be(default_ArmorClass - 5);
            };

            context["given Dexterity Value is 10"] = () =>
            {
                before = () => bob.Dexterity.Value = 10;
                it["ArmorClass should remain the same"] = () => bob.ArmorClass.should_be(default_ArmorClass);
            };
        }
    }
}
