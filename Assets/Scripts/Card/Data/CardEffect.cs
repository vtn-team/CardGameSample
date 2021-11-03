using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CardEffect : ITarget
{
    [SerializeField] TargetType _targetType = TargetType.None;

    [SerializeField, SerializeReference, SubclassSelector]
    List<ICondition> _condition = new List<ICondition>();

    [SerializeField, SerializeReference, SubclassSelector]
    List<AbilityBase> _ability = new List<AbilityBase>();

    public TargetType TargetType => _targetType;

    virtual public Evaluator Evaluate(Evaluator eval)
    {
        if(_condition.All(c => c.Check(eval)))
        {
            _ability.ForEach(a => a.Evaluate(eval));
        }
        return eval;
    }
}
