using UnityEngine;
using Vuforia;

public class TrakableObjectController : MessagingElement    // в этом классе происходит работа с отслеживаемыми объектами
{
    [SerializeField]
    private TrakableObject[] _trakableObjectList;

    public override void OnNotification(string p_event, params object[] p_data)
    {
        switch (p_event)
        {
            case MessagesList.GameStarted:

                Init();

                break;
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        for (int i = 0; i < _trakableObjectList.Length; i++)
        {
            _trakableObjectList[i].OnFound += OnTrakableFound;
            _trakableObjectList[i].OnLost += OnTrakableLost;
        }

    }

    protected override void OnDisable()
    {
        base.OnDisable();

        for (int i = 0; i < _trakableObjectList.Length; i++)
        {
            _trakableObjectList[i].OnFound -= OnTrakableFound;
            _trakableObjectList[i].OnLost -= OnTrakableLost;
        }
    }

    private bool _isInited;

    private void Init()
    {
        _isInited = true;
    }

    private int _currentTrackableCount = 0;

    private void OnTrakableFound()  // при обнаружении всех отслеживаемых объектов отправляем соответсвующее оповещение
    {
        if (!_isInited) return;

        ++_currentTrackableCount;


        if (_currentTrackableCount >= _trakableObjectList.Length)
        {
            Notify(MessagesList.AllTrackablesFound);
        }
    }

    private void OnTrakableLost()   // при потере всех отслеживаемых объектов отправляем оповещение
    {
        if (!_isInited) return;

        --_currentTrackableCount;

        if (_currentTrackableCount <= 0 )
        {
            Notify(MessagesList.AllTrackablesLost);
        }
    }
}
