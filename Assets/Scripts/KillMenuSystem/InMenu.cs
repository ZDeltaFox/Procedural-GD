using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InMenu : MonoBehaviour
{
    public static bool i;
    public bool I;
    public GameObject panel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        I = i;
        i = panel.activeSelf;
    }
}
