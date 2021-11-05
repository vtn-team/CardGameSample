using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class DamageAbility : IAbility
{
    [SerializeField] int _damage;

    int TempVal { get; set; }
    public int Value => _damage;
    public AbilityType AbilityType => AbilityType.Damage;

    public void Evaluate(Evaluator eval)
    {
        TempVal = _damage;
    }

    public void Execute(Evaluator eval)
    {
        //tbd
        eval.Targets.ForEach(c => c.Damage(TempVal));
    }
}
