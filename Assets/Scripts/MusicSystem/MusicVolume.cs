using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MusicSystem
{
    public class MusicVolume : MonoBehaviour
    {
        public AudioSource audio;
        public Image image;
        public float f;
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Color c = image.color;
            audio.volume = 1 - c.a;
            audio.pitch = 1 - c.a;
            f = 1 - c.a;
        }
    }
}