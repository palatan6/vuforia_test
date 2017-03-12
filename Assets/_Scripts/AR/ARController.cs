using UnityEngine;
using Vuforia;

// класс отвечает за активацию отслеживания объектов
// и возврат "в исходное состояние" из сценария
public class ARController : MessagingElement
{
    [SerializeField]
    private VuforiaBehaviour _aRCamera;
    [SerializeField]
    private ARData _aRData;
    
    [SerializeField]
    private TrackableSettings _trackableSettings;

    protected override void OnEnable()
    {
        base.OnEnable();

        _aRData.DefaultARCamPosion = _aRCamera.transform.position;      // инициализируем исходное положение
        _aRData.DefaultARCamRotation = _aRCamera.transform.rotation;
    }

    public override void OnNotification(string p_event, params object[] p_data)
    {
        switch (p_event)
        {
            case MessagesList.GameStarted:

                GlobalMessagesOnGameStartedEvent();

                break;


            case MessagesList.AllTrackablesLost:

                GlobalMessagesOnTrakableObjectLostEvent();

                break;
        }
    }

    private bool _isInited;

    void Init()
    {
        _isInited = true;
    }

    private void GlobalMessagesOnGameStartedEvent()
    {
        Init();

        ActivateTracking();
    }

    private void GlobalMessagesOnTrakableObjectLostEvent()  // при потере всех отслеживаемых объектов приводим внешний вид в "исходное положение"
    {
        if(!_isInited) return;

        _aRCamera.transform.position = _aRData.DefaultARCamPosion;
        _aRCamera.transform.rotation = _aRData.DefaultARCamRotation;
    }

    void ActivateTracking()     // активация отслеживания объектов
    {
        for (int i = 0; i < _aRData.TrackableDataSetNames.Length; i++)
        {
            _trackableSettings.ActivateDataSet(_aRData.TrackableDataSetNames[i]);
        }
    }
}
