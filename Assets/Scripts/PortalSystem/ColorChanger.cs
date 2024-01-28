using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalSystem
{
    public class ColorChanger : MonoBehaviour
    {
        [System.Serializable]
        public class Colors
        {
            public Color[] color;
        }

        public Colors[] colors;
    }
}