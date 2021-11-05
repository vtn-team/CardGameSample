using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class GameManager
{
    static GameManager _instance = new GameManager();
    private GameManager() { }
    static public GameManager Instance => _instance;

    static public List<Character> Characters => _instance._chars;
    static public PlayerController Player => _instance._player;

    List<Character> _chars = new List<Character>();
    UIManager _uiManager = new UIManager();
    PlayerController _player = new PlayerController();

    public void Setup(List<CardData> hands)
    {
        //本当は手札や敵を動的に作ったりするので、管理方法を変えた方がいいが、いまは手を抜く
        _chars = GameObject.FindObjectsOfType<Character>().ToList();
        _player.Setup(hands);
        _chars.ForEach(c => c.Setup());

        _uiManager.Setup();
    }

    public void EvaluateCard(Evaluator eval)
    {
        //バフを加算する
    }

    public void ExecuteCard()
    {
        Evaluator eval = _player.Hand[_selectHand].Evaluate();
        eval.SetTarget(_target);
        _player.Hand[_selectHand].Execute(eval);

        _uiManager.StartMain();
    }


    //tbd 
    int _selectHand = 0;
    Character _target = null;

    public void SelectCard(int index)
    {
        _selectHand = index;
    }

    public void SetTarget(Character target)
    {
        _target = target;
    }
}
