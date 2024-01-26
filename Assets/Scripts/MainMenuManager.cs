using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MapView;
    public GameObject OptionsMenu;
    public bool open;
    public void OnClickPlay()
    {
        SceneManager.LoadScene("GameScene");
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
    public void OnClickBack()
    {
        open = false;
        OptionsMenu.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
