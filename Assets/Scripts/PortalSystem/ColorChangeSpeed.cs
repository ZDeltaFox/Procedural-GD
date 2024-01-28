using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalSystem
{
    public class ColorChangeSpeed : MonoBehaviour
    {
        public float speed;

        void Update()
        {
            BackgroundColorChange.cambioDeColorSpeed = speed;
        }
    }
}