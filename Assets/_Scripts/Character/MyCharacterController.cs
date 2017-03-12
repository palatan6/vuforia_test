using System;
using UnityEngine;

// класс контролирует поведение персонажа при поступлении
//различных оповещений
public class MyCharacterController : MessagingElement
{
    [SerializeField]
    private CharacterAnimations _characterAnimations;

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

            case MessagesList.AllTrackablesFound:

                GlobalMessagesOnTrakableObjectFoundEvent();

                break;

            case MessagesList.AnimationTestStarted:

                GlobalMessagesOnStartTestAnimationsEvent((Action) p_data[0]);

                break;
        }
    }

    private bool _isInited;

    void Init()
    {
        _isInited = true;
    }

    private void GlobalMessagesOnGameStartedEvent() // инициализируем объект при старте 
    {
        Init();
    }

    private void GlobalMessagesOnStartTestAnimationsEvent(Action callback)  // стартуем тестовые анимации
    {                                                                       // по окончании анимаций будет вызван колбэк
        _characterAnimations.StartTestAnimations(callback);
    }

    private void GlobalMessagesOnTrakableObjectLostEvent()  // здесь я говорю сбросить тест анимаций. я подумал, что так лучше отразится фраза из задания "исходное положение"
    {                                                       
        if (!_isInited) return;

        _characterAnimations.RestartAnimations();
    }

    void GlobalMessagesOnTrakableObjectFoundEvent()     // запускаем айдл анимацию при первом распознавании. анимация циклическая
    {
        if (!_isInited) return;

        _characterAnimations.StartIdleAnimation();
    }
}
