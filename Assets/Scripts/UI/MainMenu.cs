using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : UIBehaviour
{
    [SerializeField]
    private Button m_PlayButton;
    [SerializeField]
    private Button m_OptionsButton;
    [SerializeField]
    private Button m_ExitButton;
    [SerializeField]
    private OptionsMenu m_OptionsMenu;
    [SerializeField]
    private RectTransform m_Background;

    protected override void Awake() {
        base.Awake();

        m_PlayButton.onClick.AddListener(OnPlayButtonClick);
        m_OptionsButton.onClick.AddListener(OnOptionsButtonClick);
        m_ExitButton.onClick.AddListener(OnExitButtonClick);

        //Application.quitting += Application_OnQuit;
    }

    private void OnPlayButtonClick() {
        // start the game
        gameObject.SetActive(false);
        m_Background.gameObject.SetActive(false);
    }

    private void OnOptionsButtonClick() {
        // show options menu
        gameObject.SetActive(false);
        m_OptionsMenu.gameObject.SetActive(true);
    }

    private void OnExitButtonClick() {
        Application.Quit();
    }

    private void Application_OnQuit() {
        // optional; save progress of the game
    }
}
