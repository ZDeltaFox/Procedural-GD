using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFadeIn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartIE());
    }

    IEnumerator StartIE()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
