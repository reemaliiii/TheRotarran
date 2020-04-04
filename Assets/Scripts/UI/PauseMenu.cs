using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : Menu
{
    [SerializeField]
    private Button m_ResumeButton;
    [SerializeField]
    private Button m_OptionsButton;
    [SerializeField]
    private Button m_MainMenuButton;
    [SerializeField]
    private OptionsMenu m_OptionsMenu;
    [SerializeField]
    private GameObject m_Overlay;

    protected override void Start() {
        base.Start();

        m_ResumeButton.onClick.AddListener(OnResumeButtonClick);
        m_OptionsButton.onClick.AddListener(OnOptionsButtonClick);
        m_MainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
    }

    public override void Show() {
        base.Show();
        m_Overlay.SetActive(true);
    }

    public override void Hide() {
        base.Hide();

        if (m_OptionsMenu.Visible) {
            m_OptionsMenu.Hide();
        }
    }

    public void HandleGameManagerEscape() {
        if (m_OptionsMenu.Visible) {
            m_OptionsMenu.Hide();
            Show();
            return;
        }

        var gameManager = GameManager.instace;
        if (!gameManager.pauseMenuActive) {
            Show();
        } else {
            Hide();
            HideOverlay();
        }

        gameManager.pauseMenuActive = !gameManager.pauseMenuActive;
    }

    public void HideOverlay() {
        m_Overlay.SetActive(false);
    }

    private void OnResumeButtonClick() {
        Hide();
        HideOverlay();
        GameManager.instace.pauseMenuActive = false;
    }

    private void OnOptionsButtonClick() {
        Hide();
        m_OptionsMenu.Show();
    }

    private void OnMainMenuButtonClick() {
        SceneManager.LoadScene(0);
    }
}
