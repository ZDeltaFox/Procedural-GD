using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem
{
    public class Spikes : MonoBehaviour
    {
        public CharacterController cscc;

        public void ButtonSpike()
        { 
            cscc.AppearOrDisappear();
        }
    }
}