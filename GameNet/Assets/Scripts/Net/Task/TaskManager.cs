using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Stars
{
    public class TaskManager : IGameSubSystem
    {
        public void update(float time)
        {
            for (int i = 0; i < _updateList.Count; ++i)
            {
                if (!(_updateList[i].doUpdate(time)))
                {
                    _removeList.Add(_updateList[i]);
                }
            }
            for (int j = 0; j < _removeList.Count; ++j)
            {
                _updateList.Remove(_removeList[j]);

            }
            _removeList.Clear();
        }

        public void addTask(Task task)
        {
            task.enable();
            if (task.isUpdating())
            {
                _updateList.Add(task);
            }
            _disableList.Add(task);
        }

        public void removeTask(Task task)
        {
            task.disable();
            _updateList.Remove(task);
            _disableList.Remove(task);
        }

        public void clearAll()
        {
            for (int i = 0; i < _disableList.Count; ++i)
            {
                _disableList[i].disable();
            }
            _disableList.Clear();
            _updateList.Clear();
            _removeList.Clear();
        }


        /// <summary>
        /// 接口实现
        /// </summary>
        /// <param name="deltaTime"></param>
        public void fixUpdate(float deltaTime) { }
        /// <summary>
        /// 接口实现
        /// </summary>
        public void init() { }
        /// <summary>
        /// 接口实现
        /// </summary>
        /// <param name="deltaTime"></param>
        public void lateUpdate(float deltaTime) { }
        /// <summary>
        /// 接口实现
        /// </summary>
        public void regEvent() { }
        /// <summary>
        /// 接口实现
        /// </summary>
        public void removeEvent() { }
        /// <summary>
        /// 接口实现
        /// </summary>
        public void resetWhenBackToLogin() { }
        /// <summary>
        /// 接口实现
        /// </summary>
        public void shutdown() { }
        public void onPause()
        {
        }

        public void onResume()
        {
        }
        List<Task> _updateList = new List<Task>();
        List<Task> _disableList = new List<Task>();
        List<Task> _removeList = new List<Task>();
    };


}