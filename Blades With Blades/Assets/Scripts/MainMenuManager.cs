using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject settingsPanel, creditsPanel, howToPanel;
    public Button playButton;
    public Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = AudioListener.volume;
    }

    #region buttons
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void ToggleSettingsPanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
        creditsPanel.SetActive(false);
        howToPanel.SetActive(false);
    }

    public void ToggleCreditsPanel()
    {
        creditsPanel.SetActive(!creditsPanel.activeSelf);
        settingsPanel.SetActive(false);
        howToPanel.SetActive(false);
    }

    public void ToggleHowToPanel()
    {
        playButton.interactable = true;
        howToPanel.SetActive(!howToPanel.activeSelf);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
    #endregion
}
