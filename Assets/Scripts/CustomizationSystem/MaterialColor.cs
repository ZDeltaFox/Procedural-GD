using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomizationSystem
{
    public class MaterialColor : MonoBehaviour
    {
        public bool primary;
        public ColorSelector colorSelector;
        public Material material;

        void Start()
        {

        }

        void Update()
        {
            if (primary) {material.SetColor("_EmissionColor", colorSelector.color1);}
            else {material.SetColor("_EmissionColor", colorSelector.color2);}
        }
    }
}
