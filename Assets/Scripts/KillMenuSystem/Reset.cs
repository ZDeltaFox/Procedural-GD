using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KillMenuSystem
{
    [ExecuteInEditMode]
    public class Reset : MonoBehaviour
    {
        void Update()
        {
            if (!Application.isPlaying)
            {
                InMenu.i = true;
                Death.isDeath = false;
            }
        }
    }
}