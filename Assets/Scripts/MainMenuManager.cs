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

    public void OpenLevel(int levelId)
    {
        SceneManager.LoadScene(levelId);
    }
    
    public void OnClickPlay()
    {
        SceneManager.LoadSceneAsync(1);
        
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
    public void OnClickBack()
    {
        open = false;
        OptionsMenu.SetActive(false);
    }
    public void OnClickResetBut()
    {

        
    }
    public void OnClickBackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
