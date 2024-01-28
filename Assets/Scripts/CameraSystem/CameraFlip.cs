using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraSystem
{
    public class CameraFlip : MonoBehaviour
    {
        public bool autoAjustar;
        private Camera mainCamera;
        public bool invert;
        [Range (0.001f, 1f)]
        public float add = 0.1f;
        public float x = 1f;
        [Range (0.001f, 0.5f)]
        public float delay = 0.02f;

        public bool doAction;
        bool canChange = true;

        public Vector3 cameraScale;

        private void Start()
        {
            canChange = true;
            mainCamera = GetComponent<Camera>();

            // Obtén la matriz de proyección actual de la cámara
            Matrix4x4 projectionMatrix = mainCamera.projectionMatrix;

            // Extrae la escala en los ejes X, Y y Z
            cameraScale = new Vector3(
                projectionMatrix.m00, // Escala en el eje X
                projectionMatrix.m11, // Escala en el eje Y
                projectionMatrix.m22  // Escala en el eje Z
            );
        }

        private void Update()
        {
            /*
            // Invertir la cámara en el eje X
            mainCamera.ResetProjectionMatrix(); // Restablecer la matriz de proyección a su valor predeterminado
            mainCamera.projectionMatrix *= Matrix4x4.Scale(new Vector3(-1, 1, 1)); // Invertir en el eje X

            // Aplicar efectos adicionales aquí
            // Por ejemplo, para aplicar un efecto de aplastamiento en el eje Y:
            float scaleY = 0.5f; // Cambiar el valor según sea necesario
            mainCamera.projectionMatrix *= Matrix4x4.Scale(new Vector3(1, scaleY, 1));
            */

            //if (x >= 1f - cameraScale.x) {x = 1f - cameraScale.x;}
            //if (x <= -1f + cameraScale.x) {x = -1f + cameraScale.x;}
            
            if (autoAjustar)
            {
                if (x >= 1f) {x = 1f;}
                if (x <= -1f) {x = -1f;}
            }

            mainCamera.ResetProjectionMatrix(); // Restablecer la matriz de proyección a su valor predeterminado
            mainCamera.projectionMatrix *= Matrix4x4.Scale(new Vector3(x, 1, 1));

            if (doAction)
            {
                doAction = false;
                ChangeCameraEffect();
            }
        }

        public void ChangeCameraEffect()
        {
            if (canChange)
            {
                invert = !invert;
                StartCoroutine(Invert());
                StartCoroutine(CanChange());
                canChange = false;
            }
        }

        IEnumerator CanChange()
        {
            yield return new WaitForSeconds(0.1f);
            canChange = true;
        }

        public IEnumerator Invert()
        {
            if (invert)
            {
                x -= add;
                mainCamera.ResetProjectionMatrix(); // Restablecer la matriz de proyección a su valor predeterminado
                mainCamera.projectionMatrix *= Matrix4x4.Scale(new Vector3(x, 1, 1));

                yield return new WaitForSeconds(delay);
                //if (x >= -1f + cameraScale.x) {StartCoroutine(Invert());}
                if (x >= -0.99f) {StartCoroutine(Invert());}
            }

            else
            {
                x += add;
                mainCamera.ResetProjectionMatrix(); // Restablecer la matriz de proyección a su valor predeterminado
                mainCamera.projectionMatrix *= Matrix4x4.Scale(new Vector3(x, 1, 1));

                yield return new WaitForSeconds(delay);
                //if (x <= 1f - cameraScale.x) {StartCoroutine(Invert());}
                if (x <= 0.99f) {StartCoroutine(Invert());}
            }
        }
    }
}