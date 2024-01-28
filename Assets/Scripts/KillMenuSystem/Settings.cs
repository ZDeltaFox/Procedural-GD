using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KillMenuSystem
{
    public class Settings : MonoBehaviour
    {
        public static bool[] IsOn;
        public bool[] isOn;
        public Toggle[] toggle;
        int[] on;

        void Awake()
        {
            //isOn = new bool[toggle.Length];
            on = new int[toggle.Length];
            for (int i = 0; i < toggle.Length; i++)
            {
                if (PlayerPrefs.HasKey("Setting" + i.ToString()))
                {
                    on[i] = PlayerPrefs.GetInt("Setting" + i.ToString()); 
                    if (on[i] == 0) {isOn[i] = true;}
                    if (on[i] == 1) {isOn[i] = false;}
                    toggle[i].isOn = isOn[i];
                    Debug.Log("PlayerPrefs: " + i.ToString() + " = " + on[i].ToString());
                }

                else
                {
                    isOn[i] = true;
                    on[i] = 0;
                    PlayerPrefs.SetInt("Setting" + i.ToString(), on[i]);
                    toggle[i].isOn = isOn[i];
                    Debug.Log("PlayerPrefs: " + i.ToString() + " = " + on[i].ToString());
                }
            }
        }

        void Update() {IsOn = isOn;}

        public void ChangeSettings(int i)
        {
            isOn[i] = toggle[i].isOn;
            if (!isOn[i]) {on[i] = 1;}
            if (isOn[i]) {on[i] = 0;}
            PlayerPrefs.SetInt("Setting" + i.ToString(), on[i]);

            Debug.Log("Value: " + i.ToString() + " changed to: " + on[i].ToString());
        }
    }
}