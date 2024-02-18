using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotToDestroy : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
