using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraSystem
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform objetoASeguir;
        public float suavidad = 5.0f;

        private Vector3 offset;

        void Start()
        {
            if (objetoASeguir == null)
            {
                Debug.LogError("Por favor, asigna un objeto para seguir en el inspector.");
                enabled = false;
                return;
            }

            offset = transform.position - objetoASeguir.position;
        }

        void LateUpdate()
        {
            if (objetoASeguir != null)
            {
                Vector3 objetivoPosicion = objetoASeguir.position + offset;
                transform.position = Vector3.Lerp(transform.position, objetivoPosicion, suavidad * Time.deltaTime);
            }
        }
    }
}