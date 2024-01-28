using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MusicSystem
{
    public class RandomMusic : MonoBehaviour
    {
        public AudioSource audioSource;
        public int currentMusic;
        int lastMusic;
        public AudioClip[] music;
        public int[] bpm;
        int i;

        public Vector2 current;

        void Start()
        {
            currentMusic = Random.Range(0, music.Length);
            lastMusic = currentMusic;
            BeatManager.BPM = bpm[currentMusic];
            audioSource.clip = music[currentMusic];
            audioSource.Play();
        }

        void Update()
        {
            current = new Vector2(audioSource.time, music[currentMusic].length);
            if (Mathf.Round(audioSource.time) == Mathf.Round(music[currentMusic].length) - 1)
            {
                if (i == 0)
                {
                    i++;
                    StartCoroutine(Change());
                }
            }

            if (Mathf.Round(audioSource.time) <= 10f)
            {
                i = 0;
            }
        }

        IEnumerator Change()
        {
            yield return new WaitForSeconds(2f);

            while (currentMusic == lastMusic) 
            {
                currentMusic = Random.Range(0, music.Length);
            }

            if (currentMusic != lastMusic) 
            {
                lastMusic = currentMusic;
                BeatManager.BPM = bpm[currentMusic];
                audioSource.clip = music[currentMusic];
                audioSource.Play();
            }
        }
    }
}