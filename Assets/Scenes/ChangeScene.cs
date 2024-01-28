using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public float time;
    public string scene;
    void Start()
    {
        StartCoroutine(StartIE());
    }

    IEnumerator StartIE()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene);
    }
}
