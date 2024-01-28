using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterSystem
{
    public class Modifiers : MonoBehaviour
    {
        [System.Serializable]
        public class Timer
        {
            [HideInInspector] public bool a;
            public bool active;
            [Range (0.1f, 10)] public float activeTime = 3;
            [HideInInspector] public float timer;
            [Range (10, 120)] public float cooldown = 60;
            public Image cooldownTime;
            public Button button;
            [Range (0.1f, 1)] public float scale = 0.5f;
        }

        [System.Serializable]
        public class Destroy
        {
            [HideInInspector] public bool a;
            public bool active;
            [Range (0.1f, 10)] public float activeTime = 3;
            [HideInInspector] public float timer;
            [Range (10, 120)] public float cooldown = 60;
            public Image cooldownTime;
            public Button button;
        }

        public static bool DestroyActive;

        float TimeScale;
        public Timer timerClass;
        public Destroy destroyClass;

        void Update()
        {
            if (timerClass.active)
            {
                timerClass.a = timerClass.active;
                Time.timeScale = timerClass.scale;
                if (timerClass.timer >= timerClass.activeTime)
                {
                    timerClass.active = false;
                }
            }

            else 
            {
                if (timerClass.a != timerClass.active)
                {
                    timerClass.a = timerClass.active;
                    Time.timeScale = TimeScale;
                }
            }

            if (timerClass.timer <= timerClass.cooldown)
            {
                timerClass.button.interactable = false;
            }

            else {timerClass.button.interactable = true;}

            DestroyActive = destroyClass.active;
            if (destroyClass.active)
            {
                destroyClass.a = destroyClass.active;
                if (destroyClass.timer >= destroyClass.activeTime)
                {
                    destroyClass.active = false;
                }
            }

            else 
            {
                if (destroyClass.a != destroyClass.active)
                {
                    destroyClass.a = destroyClass.active;
                }
            }

            if (destroyClass.timer <= destroyClass.cooldown)
            {
                destroyClass.button.interactable = false;
            }

            else
            {
                destroyClass.button.interactable = true;
            }

            if (!InMenu.i)
            {
                timerClass.timer += Time.deltaTime / Time.timeScale;
                destroyClass.timer += Time.deltaTime / Time.timeScale;
            }

            timerClass.cooldownTime.fillAmount = 1 - (timerClass.timer / timerClass.cooldown);
            destroyClass.cooldownTime.fillAmount = 1 - (destroyClass.timer / destroyClass.cooldown);

            if (timerClass.button.interactable) 
            {
                if (Input.GetKeyDown("z"))
                {
                    Active(0);
                }
            }

            if (timerClass.button.interactable) 
            {
                if (Input.GetKeyDown("x"))
                {
                    Active(1);
                }
            }
        }

        public void Active(int i)
        {
            Debug.Log("Modifier active: " + i.ToString());
            TimeScale = Time.timeScale;
            if (i == 0) {timerClass.active = true; timerClass.timer = 0;}
            if (i == 1) {destroyClass.active = true; destroyClass.timer = 0;}
        }
    }
}