using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalSystem
{
    public class SpikesCollision : MonoBehaviour
    {
        Collider2D[] allColliders;
        public bool activeColliders;
        bool i;
        void Start()
        {
            allColliders = GetComponentsInChildren<Collider2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (i != activeColliders)
            {
                if (activeColliders) {Active();}
                if (!activeColliders) {Deactive();}
                i = activeColliders;
            }
        }

        void Active()
        {
            foreach(Collider2D c in allColliders) 
            {
                c.enabled = true;
            }
        }

        void Deactive()
        {
            foreach(Collider2D c in allColliders) 
            {
                c.enabled = false;
            }
        }
    }
}