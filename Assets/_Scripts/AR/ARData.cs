using UnityEngine;

// класс содержит данные для активации отслеживаня
// и сброса внешнего вида в сцене
public class ARData : MonoBehaviour
{
    private Vector3 _defailtARCamPosition;

    public Vector3 DefaultARCamPosion
    {
        get { return _defailtARCamPosition; }
        set { _defailtARCamPosition = value; }
    }


    private Quaternion _defailtARCamRotation;

    public Quaternion DefaultARCamRotation
    {
        get { return _defailtARCamRotation; }
        set { _defailtARCamRotation = value; }
    }

    [SerializeField]
    private string[] _trackableDataSetsNames;

    public string[] TrackableDataSetNames
    {
        get { return _trackableDataSetsNames; }
        private set { _trackableDataSetsNames = value; }
    }
}
