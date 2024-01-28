using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultRes : MonoBehaviour
{
    public KeyCode[] keys;
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Screen.SetResolution((int)Mathf.Round(Screen.width / 2), (int)Mathf.Round(Screen.height / 2), true);
        }

        else
        {
            Screen.SetResolution((int)Mathf.Round(5000), (int)Mathf.Round(5000), true);
        }
    }

    void Update()
    {
        if (Input.GetKey(keys[0]))
        {
            if (Input.GetKey(keys[1]))
            {
                if (Input.GetKey(keys[2]))
                {
                    Screen.SetResolution((int)Mathf.Round(5000), (int)Mathf.Round(5000), true);
                }
            }
        }
    }
}
