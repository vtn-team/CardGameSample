using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class TaskManagerAttachment : MonoBehaviour
{
    public delegate void MonoEvent();
    MonoEvent _updateCall = null;

    private void Awake()
    {
        TaskManager.Instance.SetAttachment(this);
    }

    public void SetUpdateCallback(MonoEvent evt)
    {
        _updateCall = evt;
    }

    private void Update()
    {
        _updateCall?.Invoke();
    }
}
