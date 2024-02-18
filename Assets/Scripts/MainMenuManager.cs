using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MapView;
    public GameObject OptionsMenu;
    public bool open;

    private int currentSceneIndex;

    private int sceneToContinue;

    public void OpenLevel(int levelId)
    {
        SceneManager.LoadScene(levelId);
    }
    
    public void OnClickPlayContinue()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");
        if (sceneToContinue > 1)
        {
            SceneManager.LoadScene(sceneToContinue);
        }
        else
            SceneManager.LoadScene(1);

    }
    public void OnclickMaps()
    {
        MapView.SetActive(true);
    }
    public void OnclickOptions()
    {
        open = true;
        OptionsMenu.SetActive(true);
    }
    public void OnclickQuit()
    {
        Application.Quit();
    }
    public void OnClickReset()
    {
        PlayerPrefs.DeleteAll();
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
    public void OnClickRestart()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentSceneIndex);
    }
    public void OnClickBack()
    {
        open = false;
        OptionsMenu.SetActive(false);
    }
    public void OnClickBackToMenu()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadSceneAsync(0);
    }
}
