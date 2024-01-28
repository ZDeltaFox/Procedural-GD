using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CustomizationSystem
{
    public class ColorSelector : MonoBehaviour
    {
        public int selectedColor1;
        public int selectedColor2;

        public Color color1;
        public Color color2;

        public Image[] image;

        public bool primary;
        [Tooltip ("x = primary, y = secundary")] 
        public Vector2 defaultColor;

        public TMP_Text colorText;
        public string primaryText;
        public string secundaryText;
        public Image button;

        [ExecuteInEditMode]
        void LateUpdate()
        {
            defaultColor = new Vector2(Mathf.Round(defaultColor.x), Mathf.Round(defaultColor.y));
        }

        void Start()
        {
            primary = false;
            if (!PlayerPrefs.HasKey("PrimaryColor"))
            {
                selectedColor1 = (int)defaultColor.x;
                color1 = image[(int)defaultColor.x].color;
                PlayerPrefs.SetInt("PrimaryColor", (int)defaultColor.x);
            }

            else
            {
                int i = PlayerPrefs.GetInt("PrimaryColor");
                selectedColor1 = i;
                color1 = image[i].color;
            }

            if (!PlayerPrefs.HasKey("SecundaryColor"))
            {
                selectedColor2 = (int)defaultColor.y;
                color2 = image[(int)defaultColor.y].color;
                PlayerPrefs.SetInt("SecundaryColor", (int)defaultColor.y);
            }

            else
            {
                int i = PlayerPrefs.GetInt("SecundaryColor");
                selectedColor2 = i;
                color2 = image[i].color;
            }
        }

        void Update()
        {  
            if (primary) 
            {
                string colorString = ColorUtility.ToHtmlStringRGB(color2);
                colorText.text = "<color=#" + colorString + ">" + secundaryText;
                button.color = color1;
            }
            else 
            {
                string colorString = ColorUtility.ToHtmlStringRGB(color1);
                colorText.text = "<color=#" + colorString + ">" + primaryText;
                button.color = color2;
            }
        }

        public void SelectColor(int i)
        {
            if (primary)
            {
                selectedColor1 = i;
                color1 = image[i].color;
                PlayerPrefs.SetInt("PrimaryColor", i);
            }

            else
            {
                selectedColor2 = i;
                color2 = image[i].color;
                PlayerPrefs.SetInt("SecundaryColor", i);
            }
        }

        public void ChangePrimary()
        {
            primary = !primary;
        }
    }
}