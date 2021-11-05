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

    List<Character> _targets = new List<Character>();
    public List<Character> Targets => _targets;

    public void SetTarget(Character c)
    {
        _targets.Add(c);
    }

    //将来的にこのクラスが予測表示などを請け負う
    //今はサンプルなので作らない、設計思想だけある感じ
}
