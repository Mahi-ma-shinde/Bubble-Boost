using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        RespondToDebugKeys();
    }
    public void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape Button hit");
            Application.Quit();
        }
    }
}
