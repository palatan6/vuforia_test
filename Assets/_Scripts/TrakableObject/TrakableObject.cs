using UnityEngine;
using Vuforia;

// это релизация встроенного интерфейса для наших нужд. отправляем сообщения 
// при каждом обнаружении\потере объекта

public class TrakableObject : MonoBehaviour, ITrackableEventHandler
{
    public event System.Action OnFound;
    public event System.Action OnLost;

    private TrackableBehaviour.Status _status;

    public TrackableBehaviour.Status Status
    {
        get { return _status; }
    }

    void Start()
    {
        TrackableBehaviour mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        _status = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
              newStatus == TrackableBehaviour.Status.TRACKED ||
              newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            if (OnFound != null)
                OnFound();
        }
        else
        {
            if (OnLost != null)
                OnLost();
        }
    }
}
