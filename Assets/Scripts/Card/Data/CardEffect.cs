using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class CardEffect : ITarget
{
    [SerializeField] TargetType _targetType = TargetType.None;
    [SerializeField] int Priority = 0;

    [SerializeField, SerializeReference, SubclassSelector]
    List<ICondition> _condition = new List<ICondition>();

    [SerializeField, SerializeReference, SubclassSelector]
    IAbility _ability = null;

    public TargetType TargetType => _targetType;
    public int Value => _ability != null ? _ability.Value : 0;
    public AbilityType AbilityType => _ability != null ? _ability.AbilityType : AbilityType.Invalid;

    virtual public Evaluator Evaluate(Evaluator eval)
    {
        if(_condition.All(c => c.Check(eval)))
        {
            _ability.Evaluate(eval);
        }
        return eval;
    }

    virtual public void Execute(Evaluator eval)
    {
        if (_condition.All(c => c.Check(eval)))
        {
            _ability.Execute(eval);
        }
    }
}
