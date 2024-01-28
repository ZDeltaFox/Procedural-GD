using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.IO;

namespace KillMenuSystem
{
    public class Death : MonoBehaviour
    {
        public GameObject killScreen;
        public GameObject[] transforms;
        public GameObject particles;
        public static bool isDeath;
        AudioSource deathSound;
        bool actived;
        string filePath;
        bool canDeath = true;
        bool autoRestart;
        string text;

        void Start()
        {
            canDeath = true;
            filePath = Path.Combine(Application.persistentDataPath, "Cheats.dat");
            if (File.Exists(filePath))
            {
                text = File.ReadAllText(filePath);
                if (text.Contains("Cheat.NoClip = 1"))
                {
                    canDeath = false;
                }

                if (text.Contains("Cheat.AutoRestart = 1"))
                {
                    autoRestart = true;
                }
            }

            deathSound = GameObject.Find("Audio/Death").GetComponent<AudioSource>();
            InMenu.i = true;
            isDeath = false;
            killScreen.SetActive(false);
            Time.timeScale = 1f;
        }

        void Update()
        {
            if (!canDeath)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Restart();
                }
            }
            if (canDeath)
            {
                if (isDeath)
                {
                    if (!actived)
                    {
                        deathSound.Play();
                        actived = false;
                    }
                    killScreen.SetActive(true);
                    InMenu.i = true;
                    //isDeath = false;
                    //Time.timeScale = 1f;
                    if (autoRestart)
                    {
                        Invoke("Restart", 1f);
                    }

                    particles.SetActive(true);
                    for (int i = 0; i < transforms.Length; i++)
                    {
                        transforms[i].SetActive(false);
                    }
                }
            }
        }

        void OnCollisionEnter2D(Collision2D col) 
        {
            if (canDeath)
            {
                if (!col.gameObject.CompareTag("Player"))
                {
                    if (col.gameObject.CompareTag("Floor"))
                    {
                        killScreen.SetActive(true);
                        isDeath = true;
                        InMenu.i = true;
                        //Time.timeScale = 1f;
                    }
                }
            }
        }

        public void Restart()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}