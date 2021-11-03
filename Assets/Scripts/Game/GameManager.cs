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

    List<Character> _chars = new List<Character>();
    UIManager _uiManager = new UIManager();
    
    public void Setup()
    {
        //本当は敵を動的に作ったりするので、管理方法を変えた方がいいが、いまは手を抜く
        _chars = GameObject.FindObjectsOfType<Character>().ToList();

        _uiManager.Setup();
    }

}
