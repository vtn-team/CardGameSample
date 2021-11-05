using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class GameLauncher : MonoBehaviour
{
    [SerializeField] List<CardData> _hands = new List<CardData>();

    void Awake()
    {

    }

    void Start()
    {
        List<CardData> cloneData = new List<CardData>();
        _hands.ForEach(h => cloneData.Add(Instantiate(h)));
        GameManager.Instance.Setup(cloneData);
    }
}
