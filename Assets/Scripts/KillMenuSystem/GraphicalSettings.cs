using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace KillMenuSystem
{
    [ExecuteInEditMode]
    public class GraphicalSettings : MonoBehaviour
    {
        public bool executeInEditMode;
        public TMP_Text graphicsText;
        public Button UpperGraphics, LowerGraphics;
        public string[] settings;
        public bool isTesting;
        public Vector2 testResolution;
        public Vector2[] factor;
        public static Vector2[] resolution;
        Resolution currentResolution;
        public Vector2 CurrentResolution;
        public Vector2 currentGameResolution;
        public int currentSetting;
        [Tooltip ("x = minOption, y = maxOption")]
        public Vector2 graphicsOptions;
        public int defaultOption;

        public static bool isSpawned;
        bool isSpawned2;

        private static Vector2 vrel; 
        void Start()
        {
            //if (!isSpawned)
            //{
                //Screen.SetResolution((int)Mathf.Round(Screen.width / 2), (int)Mathf.Round(Screen.height / 2), true);
                //isSpawned = true;
            //}
            
            if (isSpawned2)
            {
                //Screen.SetResolution(5000, 5000, true);
                //Screen.SetResolution(1200, 5000, true);
                if (!PlayerPrefs.HasKey("GraphicalSettings"))
                {
                    PlayerPrefs.SetInt("GraphicalSettings", defaultOption);
                }

                if (PlayerPrefs.HasKey("GraphicalSettings"))
                {
                    if (PlayerPrefs.GetInt("GraphicalSettings") > graphicsOptions.y)
                    {
                        PlayerPrefs.SetInt("GraphicalSettings", defaultOption);
                    }

                    else {currentSetting = PlayerPrefs.GetInt("GraphicalSettings");}
                }

                if (!isSpawned)
                {
                    currentResolution = Screen.currentResolution;
                    CurrentResolution = new Vector2(currentResolution.width, currentResolution.height);
                    currentGameResolution = new Vector2(Screen.width, Screen.height);
                    if (executeInEditMode && !Application.isPlaying || Application.isPlaying)
                    {
                        graphicsText.text = "Graphics: " + settings[currentSetting];
                        if (currentSetting == graphicsOptions.x) {LowerGraphics.interactable = false;}
                        else {LowerGraphics.interactable = true;}

                        if (currentSetting == graphicsOptions.y) {UpperGraphics.interactable = false;}
                        else {UpperGraphics.interactable = true;}

                        for (int i = 0; i < resolution.Length; i++)
                        {
                            if (i == resolution.Length) {i = 0;}
                            else
                            {
                                if (isTesting)
                                {
                                    resolution[i] = new Vector2(
                                        Mathf.Round(testResolution.x / factor[i].x * factor[i].y), 
                                        Mathf.Round(testResolution.y / factor[i].x * factor[i].y));
                                }

                                else
                                {
                                    resolution[i] = new Vector2(
                                        Mathf.Round(CurrentResolution.x / factor[i].x * factor[i].y), 
                                        Mathf.Round(CurrentResolution.y / factor[i].x * factor[i].y));
                                }
                            }
                        }
                    }

                    int x = (int)resolution[currentSetting].x;
                    int y = (int)resolution[currentSetting].y;
                    Screen.SetResolution(x, y, true);
                    graphicsText.text = "Graphics: " + settings[currentSetting];
                }
                
                isSpawned = true;
            }
        }

        void Update()
        {
            //QualitySettings.SetQualityLevel(currentSetting);
        }

        public void LowerGraphicsButton()
        {
            Screen.SetResolution(10000, 10000, true);
            currentSetting--;
            PlayerPrefs.SetInt("GraphicalSettings", currentSetting);
            graphicsText.text = "Graphics: " + settings[currentSetting];
            if (currentSetting == graphicsOptions.x) {LowerGraphics.interactable = false;}
            else {LowerGraphics.interactable = true;}

            if (currentSetting == graphicsOptions.y) {UpperGraphics.interactable = false;}
            else {UpperGraphics.interactable = true;}

            for (int i = 0; i < resolution.Length; i++)
            {
                if (i == resolution.Length) {i = 0;}
                else
                {
                    if (isTesting)
                    {
                        resolution[i] = new Vector2(
                            Mathf.Round(testResolution.x / factor[i].x * factor[i].y), 
                            Mathf.Round(testResolution.y / factor[i].x * factor[i].y));
                    }

                    else
                    {
                        resolution[i] = new Vector2(
                            Mathf.Round(CurrentResolution.x / factor[i].x * factor[i].y), 
                            Mathf.Round(CurrentResolution.y / factor[i].x * factor[i].y));
                    }
                }
            }
            int x = (int)resolution[currentSetting].x;
            int y = (int)resolution[currentSetting].y;
            Screen.SetResolution(x, y, true);
        }

        public void UpperGraphicsButton()
        {
            Screen.SetResolution(10000, 10000, true);
            currentSetting++;
            PlayerPrefs.SetInt("GraphicalSettings", currentSetting);
            graphicsText.text = "Graphics: " + settings[currentSetting];
            if (currentSetting == graphicsOptions.x) {LowerGraphics.interactable = false;}
            else {LowerGraphics.interactable = true;}

            if (currentSetting == graphicsOptions.y) {UpperGraphics.interactable = false;}
            else {UpperGraphics.interactable = true;}

            for (int i = 0; i < resolution.Length; i++)
            {
                if (i == resolution.Length) {i = 0;}
                else
                {
                    if (isTesting)
                    {
                        resolution[i] = new Vector2(
                            Mathf.Round(testResolution.x / factor[i].x * factor[i].y), 
                            Mathf.Round(testResolution.y / factor[i].x * factor[i].y));
                    }

                    else
                    {
                        resolution[i] = new Vector2(
                            Mathf.Round(CurrentResolution.x / factor[i].x * factor[i].y), 
                            Mathf.Round(CurrentResolution.y / factor[i].x * factor[i].y));
                    }
                }
            }
            int x = (int)resolution[currentSetting].x;
            int y = (int)resolution[currentSetting].y;
            Screen.SetResolution(x, y, true);
        }

        public void LowerDefaultEditor()
        {
            if (defaultOption != graphicsOptions.x) {defaultOption--;}
        }

        public void UpperDefaultEditor()
        {
            if (defaultOption != graphicsOptions.y) {defaultOption++;}
        }
    }
}