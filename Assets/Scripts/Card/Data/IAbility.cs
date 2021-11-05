
public interface IAbility
{
    int Value { get; }
    AbilityType AbilityType { get; }

    void Evaluate(Evaluator eval);
    void Execute();
}
