using UnityEngine;


public abstract class MessagingElement : MonoBehaviour  // класс, от которого наследуются все возможные подписчики на систему оповещений
{
    private GlobalMessaging _globalMessagesInstance;

    protected GlobalMessaging globalMessages    // содержит кешированную ссылку на глобальную систему оповещений
    {
        get { return _globalMessagesInstance = Assert(_globalMessagesInstance, true); }
    }

    public GlobalMessaging Assert(GlobalMessaging p_var, bool p_global = false) 
    {
        return p_var ?? (p_global ? GameObject.FindObjectOfType<GlobalMessaging>() : transform.GetComponentInChildren<GlobalMessaging>());
    }

    public abstract void OnNotification(string p_event, params object[] p_data);    // метод вызываемый у всех подписчиков при появлении нового оповещения

    protected virtual void OnEnable()   // подписка 
    {
        if (globalMessages != null)
        {
            globalMessages.RegisterListener(this);
        }
    }

    protected virtual void OnDisable()  // отписка
    {
        if (globalMessages != null )
        {
            globalMessages.UnRegisterListener(this);
        }
    }

    protected void Notify(string p_event, params object[] p_data)
    {
        globalMessages.Notify( p_event, p_data);
    }
}
