using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public GameObject deathPanel, pausePanel;
    public Text scoreValueText;
    public Text scoreValueTextDeath;
    public Slider volumeSlider;

    public string ScoreText 
    { 
        get { return scoreValueText.text; }
        set { scoreValueText.text = value; scoreValueTextDeath.text = value; } 
    }

    public static MenuButtons Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        volumeSlider.value = AudioListener.volume;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void Die()
    {
        deathPanel.SetActive(true);
    }

    #region Buttons

    public void MainMenuButton()
    {
        GameManager.Instance.StartTime();
        SceneManager.LoadScene(0);
    }

    public void RestartButton()
    {
        GameManager.Instance.StartTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TogglePause()
    {
        if (pausePanel.activeSelf)
        {
            GameManager.Instance.StartTime();
            pausePanel.SetActive(false);
            return;
        }
        
        GameManager.Instance.StopTime();
        pausePanel.SetActive(true);
    }

    #endregion

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

}
