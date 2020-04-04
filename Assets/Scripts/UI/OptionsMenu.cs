using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsMenu : UIBehaviour
{
    [SerializeField]
    private Slider m_MusicSlider;

    [SerializeField]
    private Slider m_SoundSlider;

    [SerializeField]
    private Button m_BackButton;

    [SerializeField]
    private MainMenu m_MainMenu;

    protected override void Start() {
        base.Start();

        m_MusicSlider.onValueChanged.AddListener(OnMusicValueChanged);
        m_SoundSlider.onValueChanged.AddListener(OnSoundValueChanged);

        m_BackButton.onClick.AddListener(OnBackButtonClick);
    }

    private void OnMusicValueChanged(float value) {

    }

    private void OnSoundValueChanged(float value) {

    }

    private void OnBackButtonClick() {
        gameObject.SetActive(false);
        m_MainMenu.gameObject.SetActive(true);
    }
}