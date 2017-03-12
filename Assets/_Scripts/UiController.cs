using UnityEngine;
using UnityEngine.UI;

// класс контролирует работу графического интерфейса

public class UiController : MessagingElement
{
    public Button StartGameButton;
    public Button StartAnimationTestButton;

    // метод стартует сценарий приложения
    public void OnStartGameButtonClick() //called from UI button
    {
        Notify(MessagesList.GameStarted);

        StartGameButton.gameObject.SetActive(false);

        StartAnimationTestButton.gameObject.SetActive(true);
    }

    // метод стартует тестовые анимации и отключает кнопку его вызова. кнопка включится по колбэку
    public void OnStartAnimationTestButtonClick()  //called from UI button
    {
        StartAnimationTestButton.interactable = false;

        System.Action callback = OnAnimationTestEnd;

        Notify(MessagesList.AnimationTestStarted, callback);
    }

    // метод колбэк. вызывается по выходу из тестовой анимации
    void OnAnimationTestEnd()
    {
        StartAnimationTestButton.interactable = true;
    }

    // инициализация
    void Start()
    {
        StartAnimationTestButton.gameObject.SetActive(false);
    }

    public override void OnNotification(string p_event, params object[] p_data)
    {
        
    }
}
