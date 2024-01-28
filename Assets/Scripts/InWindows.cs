using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWindows : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            Debug.Log("Juego ejecutándose en Windows");
        }
        else
        {
            Debug.Log("Juego NO ejecutándose en Windows");
            Destroy(gameObject);
        }
    }
}
