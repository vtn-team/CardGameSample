
public enum TargetType
{
    None,
    RandomOne,
    SelectOne,
    SelectFriend,
    SelectOpponent,
    AllFriends,
    AllOpponents,
    All,
}

interface ITarget
{
    TargetType TargetType { get; }
}