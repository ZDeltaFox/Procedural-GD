using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CustomizationSystem
{
    public class PlayerColor : MonoBehaviour
    {
        public enum ImageType
        {
            SpriteRenderer,
            Image
        }
        public ImageType type;
        public bool primary;
        public ColorSelector colorSelector;
        Image im;
        SpriteRenderer sr;

        void Start()
        {
            if (type == ImageType.SpriteRenderer) {sr = GetComponent<SpriteRenderer>();}
            if (type == ImageType.Image) {im = GetComponent<Image>();}
        }

        void Update()
        {
            if (primary) {if (type == ImageType.SpriteRenderer) {sr.color = colorSelector.color1;}
            if (type == ImageType.Image) {im.color = colorSelector.color1;}}

            else {if (type == ImageType.SpriteRenderer) {sr.color = colorSelector.color2;}
                if (type == ImageType.Image) {im.color = colorSelector.color2;}}
        }
    }
}
