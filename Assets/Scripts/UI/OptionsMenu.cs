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
    private AudioSource m_MusicSource;
    [SerializeField]
    private AudioSource m_SoundSource;
    [SerializeField]
    private Button m_BackButton;
    [SerializeField]
    private Menu m_BackMenu;

    protected override void Start()
    {
        base.Start();

        m_MusicSlider.onValueChanged.AddListener(OnMusicValueChanged);
        m_SoundSlider.onValueChanged.AddListener(OnSoundValueChanged);
        m_MusicSlider.value = m_MusicSource.volume;
        m_SoundSlider.value = m_SoundSource.volume;

        m_BackButton.onClick.AddListener(OnBackButtonClick);
    }

    private void OnMusicValueChanged(float value)
    {
        m_MusicSource.volume = m_MusicSlider.value;

    }

    private void OnSoundValueChanged(float value)
    {
        m_SoundSource.volume = m_SoundSlider.value;

    }

    private void OnBackButtonClick()
    {
        Hide();
        m_BackMenu.Show();
    }
}