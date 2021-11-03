using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class TaskManager
{
    static private TaskManager _instance = new TaskManager();
    static public TaskManager Instance => _instance;
    private TaskManager() { }

    public delegate int UpdateCall();

    /// <summary>
    /// 優先度付きキュー
    /// 
    /// NOTE: 優先度で並び替えが行われる
    /// </summary>
    class PriorityQueue
    {
        public int Priority { get; private set; }   //優先度
        object _obj;
        UpdateCall _call;

        /// <summary>
        /// 初期化
        /// </summary>
        public PriorityQueue(int p, object o, UpdateCall c)
        {
            Priority = p;
            _obj = o;
            _call = c;
        }

        public int Update()
        {
            if (_obj == null) return 1;
            return _call();
        }
    }

    TaskManagerAttachment _attach;
    LinkedList<PriorityQueue> _tasks = new LinkedList<PriorityQueue>();
    List<PriorityQueue> _addQueue = new List<PriorityQueue>();             // 更新処理の追加用キュー
    List<PriorityQueue> _delQueue = new List<PriorityQueue>();             // 更新処理の削除用キュー

    public void SetAttachment(TaskManagerAttachment attach)
    {
        _attach = attach;
        _attach.SetUpdateCallback(Update);
    }

    public void Register(UpdateCall call, object obj, int priority = 0)
    {
        _addQueue.Add(new PriorityQueue(priority, obj, call));
    }

    void Update()
    {
        foreach (var t in _tasks)
        {
            int ret = t.Update();
            if(ret == 1)
            {
                _delQueue.Add(t);
            }
        }

        //追加する更新処理があれば追加する
        if (_delQueue.Count > 0)
        {
            foreach (var q in _delQueue)
            {
                _tasks.Remove(q);
            }
            _delQueue.Clear();
        }
        if (_addQueue.Count > 0)
        {
            //優先度に応じて追加
            foreach (var q in _addQueue)
            {
                var node = _tasks.LastOrDefault(u => u.Priority <= q.Priority);
                if (node == null)
                {
                    _tasks.AddFirst(q);
                }
                else
                {
                    _tasks.AddAfter(_tasks.Find(node), q);
                }
            }
            _addQueue.Clear();
        }
    }
}
