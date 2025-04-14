using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject menu;
    [SerializeField] MonoBehaviour fpsController;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject playerUI;
    [SerializeField] Slider sensitivitySlider;
    [SerializeField] float lookSensitivity;
    bool isOpen;

    private void Start()
    {
        menu.SetActive(false);
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            OpenPauseMenu();
        }
    }

    private void OpenPauseMenu()
    {
        isOpen = !isOpen;
        playerUI.SetActive(false);
        menu.SetActive(true);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        fpsController.enabled = false;
        Cursor.lockState = isOpen ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isOpen;
    }
    public void ClosePauseMenu()
    {
        isOpen = !isOpen;
        menu.SetActive(false);
        Time.timeScale = 1;
        playerUI.SetActive(true);
        fpsController.enabled = true;
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
        pauseMenu.SetActive(false);

    }

    public void CloseSettings()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void UpdateSensitivity(float newValue)
    {
        lookSensitivity = newValue;
    }

}
