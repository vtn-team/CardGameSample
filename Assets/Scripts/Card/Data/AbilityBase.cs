using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class AbilityBase : IAbility, ITarget
{
    public TargetType TargetType { get; protected set; }

    public abstract void Evaluate(Evaluator eval);

    public abstract void Execute();
}
