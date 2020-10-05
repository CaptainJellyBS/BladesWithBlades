using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public GameObject deathPanel, pauzePanel;
    public Text scoreValueText;
    public Text scoreValueTextDeath;

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

    #endregion

}
