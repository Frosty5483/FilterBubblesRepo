using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenButtons : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider loadingSlider;
    [SerializeField] Toggle fullscreenToggle;


    private void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        loadingScreen.SetActive(false);

        if (fullscreenToggle != null)
        {
            fullscreenToggle.isOn = Screen.fullScreen;
            fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
        }

    }

    private void Update()
    {
        
    }

    public void StartGame()
    {
        LoadLevelBGR(1);
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.ExternalEval("window.close();");
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


    void LoadLevelBGR(int levelId)
    {
        loadingScreen.SetActive(true);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);

        StartCoroutine(LoadLevelAsync(levelId));
    }

    IEnumerator LoadLevelAsync(int levelId)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelId);

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;
        }
    }
}
