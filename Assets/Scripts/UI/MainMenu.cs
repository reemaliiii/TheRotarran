using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : Menu
{
    [SerializeField]
    private Button m_PlayButton;
    [SerializeField]
    private Button m_OptionsButton;
    [SerializeField]
    private Button m_ExitButton;
    [SerializeField]
    private OptionsMenu m_OptionsMenu;

    protected override void Awake() {
        base.Awake();

        m_PlayButton.onClick.AddListener(OnPlayButtonClick);
        m_OptionsButton.onClick.AddListener(OnOptionsButtonClick);
        m_ExitButton.onClick.AddListener(OnExitButtonClick);

        //Application.quitting += Application_OnQuit;
    }

    private void OnPlayButtonClick() {
        SceneManager.LoadScene(1);
        Hide();
    }

    private void OnOptionsButtonClick() {
        // show options menu
        Hide();
        m_OptionsMenu.Show();
    }

    private void OnExitButtonClick() {
        Application.Quit();
    }

    private void Application_OnQuit() {
        // optional; save progress of the game
    }
}
