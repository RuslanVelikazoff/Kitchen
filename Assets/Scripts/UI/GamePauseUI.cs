using System;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField]
    private Button resumeButton;
    [SerializeField] 
    private Button mainMenuButton;
    [SerializeField] 
    private Button OptionsButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(()=>
        {
            KitchenGameManager.Instance.TogglePauseGame();
        });
        
        mainMenuButton.onClick.AddListener(()=>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
        
        OptionsButton.onClick.AddListener(() =>
        {
            OptionsUI.Instance.Show();
        });
    }

    private void Start()
    {
        KitchenGameManager.Instance.OnGamePaused += KitchenGameManager_OnGamePaused;
        KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;
        
        Hide();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void KitchenGameManager_OnGamePaused(object sender, EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
