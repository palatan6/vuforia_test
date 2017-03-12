using System.Collections.Generic;
using UnityEngine;

//я не наставиваю на подобной реализации. просто вдохновился фрэймворками 
//типа https://github.com/cgarciae/karma , но ещё полностью в нём не разобрался, 
//поэтому описал свой упрощённый вариант. Для нужд подобного задания вполне
//хватило.  



public class GlobalMessaging : MonoBehaviour    // класс занимается обслуживанием списка подписавшихся на оповещения и отправкой оповещений по списку
{
    private List<MessagingElement> _notificationListeners;  // список подписавшихся на оповещение

    public void Notify(string p_event, params object[] p_data)  // метод оповещения. несёт имя события и список параметров
    {
        if (_notificationListeners == null || _notificationListeners.Count ==0)
        {
            return;
        }

        foreach (MessagingElement c in _notificationListeners)
        {
            c.OnNotification(p_event, p_data);
        }
    }

    public void RegisterListener(MessagingElement newListener)  // добавляем в список нового слушателя оповещений
    {
        if(_notificationListeners == null)
            _notificationListeners = new List<MessagingElement>();

        if (!_notificationListeners.Contains(newListener))
        {
            _notificationListeners.Add(newListener);
        }
    }

    public void UnRegisterListener(MessagingElement toDeleteListener)   // удаляем из списка подписчика
    {
        if (_notificationListeners == null)
            return;

        if (_notificationListeners.Contains(toDeleteListener))
        {
            _notificationListeners.Remove(toDeleteListener);
        }
    }
}
