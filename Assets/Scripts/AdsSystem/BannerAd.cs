using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BannerAd : MonoBehaviour
{
    public bool open;
    void Update()
    {
        if (open)
        {
            open = false;
            Application.OpenURL(Application.persistentDataPath);
        }
    }
}
