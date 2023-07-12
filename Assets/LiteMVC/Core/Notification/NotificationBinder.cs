using System;
using System.Collections.Generic;

namespace LiteMVC.Core
{
    internal class NotificationBinder<T> : INotificationBinder
    {
        Type valueType = typeof(T);
        List<Action<T>> bindActions;
        public int BindCount { get { return bindActions.Count; } }
        public Type ValueType { get { return valueType; } }
        public NotificationBinder()
        {
            bindActions = new List<Action<T>>();
        }
        public void Bind(Action<T> action)
        {
            if (!bindActions.Contains(action))
                bindActions.Add(action);
        }
        public void Unbind(Action<T> action)
        {
            bindActions.Remove(action);
        }
        public void Execute(object data)
        {
            var length = bindActions.Count;
            for (int i = 0; i < length; i++)
            {
             bindActions[i]?.Invoke((T)data);
            }
        }
        public void Clear()
        {
            bindActions.Clear();
        }
    }
}
