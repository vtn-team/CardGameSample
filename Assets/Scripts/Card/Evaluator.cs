using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Evaluator
{
    public class CharacterParam
    {
        public int AfterHP;
        public int AfterAtk;
    }

    List<IAbility> _effects = new List<IAbility>();
    List<CharacterParam> _param = new List<CharacterParam>();

    public void Stack(IAbility a)
    {
        _effects.Add(a);
    }
}
