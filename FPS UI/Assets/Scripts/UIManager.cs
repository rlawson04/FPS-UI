using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject menu;
    [SerializeField] FirstPersonController fpsController;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject playerUI;
    [SerializeField] Slider sensitivitySlider;
    public TextMeshProUGUI sensitivityText;
    bool isOpen;

    private void Start()
    {
        menu.SetActive(false);
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        sensitivitySlider.value = fpsController.mouseSensitivity;
        sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);
        UpdateSensitivity(fpsController.mouseSensitivity);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isOpen){
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
        Cursor.lockState = isOpen ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isOpen;
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
        // Testing Debug.Log(newValue);
        fpsController.mouseSensitivity = newValue;
        sensitivityText.SetText(newValue.ToString("0.00"));
    }

}
