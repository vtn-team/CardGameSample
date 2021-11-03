using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class GameLauncher : MonoBehaviour
{
    void Awake()
    {

    }

    void Start()
    {
        GameManager.Instance.Setup();
    }
}
