using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class UITargetSelect : UISelectable
{
    TargetType _type;
    List<Character> _targets = new List<Character>();

    static public UITargetSelect Build(TargetType type)
    {
        var prefab = Resources.Load<UITargetSelect>("TargetSelect");
        var go = Instantiate(prefab, GameObject.Find("UI").transform);
        go._type = type;
        return go;
    }

    public override void StartSelect()
    {
        var chars = GameManager.Characters;
        _targets.Clear();
        foreach (var c in chars)
        {
            switch (_type)
            {
                case TargetType.SelectOpponent:
                    if (c.Force == ForceType.Friend) continue;
                    break;

                case TargetType.SelectFriend:
                    if (c.Force == ForceType.Opponent) continue;
                    break;
            }
            _targets.Add(c);
        }

        Select(0);
    }

    public override void Select(int select)
    {
        _selectIndex += select;

        if (_targets.Count > 0)
        {
            if (_selectIndex >= _targets.Count) _selectIndex = _targets.Count - 1;
            if (_selectIndex < 0) _selectIndex = 0;
        }
        else
        {
            _selectIndex = 0;
        }

        this.RectTransform.position = _targets[_selectIndex].RectTransform.position;
    }

    public override UIResultCode Decide()
    {
        GameManager.Instance.SetTarget(_targets[_selectIndex]);
        return UIResultCode.Execute;
    }

    //来ない
    public override UISelectable GetNext()
    {
        return null;
    }

    public override void Term()
    {
        Destroy(this.gameObject);
    }
}
