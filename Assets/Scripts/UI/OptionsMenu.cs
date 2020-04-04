using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsMenu : Menu
{
    [SerializeField]
    private Slider m_MusicSlider;
    [SerializeField]
    private Slider m_SoundSlider;
    [SerializeField]
    private Button m_BackButton;
    [SerializeField]
    private Menu m_BackMenu;

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
        Hide();
        m_BackMenu.Show();
    }
}