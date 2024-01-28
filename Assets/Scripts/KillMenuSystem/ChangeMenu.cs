using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KillMenuSystem
{
    public class ChangeMenu : MonoBehaviour
    {
        public GameObject menu;
        public GameObject mainMenu;
        public GameObject settingsMenu;
        public GameObject customMenu;

        void Start()
        {
            menu.SetActive(true);
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);
            customMenu.SetActive(false);
        }

        public void StartGame()
        {
            InMenu.i = false;
            menu.SetActive(false);
            Time.timeScale = 1f;
        }

        public void Change(int i)
        {
            if (i == 0)
            {
                mainMenu.SetActive(true);
                settingsMenu.SetActive(false);
                customMenu.SetActive(false);
            }

            if (i == 1)
            {
                mainMenu.SetActive(false);
                settingsMenu.SetActive(true);
                customMenu.SetActive(false);
            }

            if (i == 2)
            {
                mainMenu.SetActive(false);
                settingsMenu.SetActive(false);
                customMenu.SetActive(true);
            }
        }
    }
}