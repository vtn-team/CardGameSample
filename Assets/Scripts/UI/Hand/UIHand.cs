using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class UIHand : UISelectable
{
    const int MAX_HAND = 10;
    [SerializeField] UICard _prefab = null;
    List<UICard> _cards = new List<UICard>();

    void Awake()
    {
        for (int i = 0; i < MAX_HAND; ++i)
        {
            _cards.Add(Instantiate(_prefab, this.transform));
        }
        _cards.ForEach(c => c.Disactive());
    }

    void Setup()
    {
        var hand = GameManager.Player.Hand;
        var width = _prefab.Width;
        var left = -width * hand.Count / 2 + width / 2;
        for (int i = 0; i < MAX_HAND; ++i)
        {
            if (i >= hand.Count)
            {
                _cards[i].Disactive();
                continue;
            }
            _cards[i].Setup(hand[i]);
            _cards[i].RectTransform.localPosition = new Vector3(left + width * i, 0, _cards[i].RectTransform.position.z);
            _cards[i].Active();
        }

        Select(0);
    }

    public override void StartSelect()
    {
        Setup();
    }

    public override void Select(int select)
    {
        _selectIndex += select;
        var hand = GameManager.Player.Hand;

        if (_selectIndex >= hand.Count) _selectIndex = hand.Count - 1;
        if (_selectIndex < 0) _selectIndex = 0;

        for(int i=0; i< _cards.Count; ++i)
        {
            Vector3 pos = _cards[i].RectTransform.localPosition;
            if (i == _selectIndex)
            {
                _cards[i].RectTransform.localPosition = new Vector3(pos.x, 30, 0);
            }
            else
            {
                _cards[i].RectTransform.localPosition = new Vector3(pos.x, 0, 0);
            }
        }
    }

    public override UIResultCode Decide()
    {
        if(_cards[_selectIndex].HasTargetSelect)
        {
            return UIResultCode.NextUI;
        }

        return UIResultCode.Execute;
    }

    public override UISelectable GetNext()
    {
        return UITargetSelect.Build(_cards[_selectIndex].TargetType);
    }

    public override void Term()
    {
        _cards.ForEach(c => c.Disactive());
    }
}
