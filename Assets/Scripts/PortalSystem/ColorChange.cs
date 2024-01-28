using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalSystem
{
    public class ColorChange : MonoBehaviour
    {
        public Color colorInicio;
        public Color colorFin;
        public float velocidadCambio = 1.0f;

        private SpriteRenderer spriteRenderer;
        private float t = 0.0f;
        private bool cambiarAColorFin = true;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            // Incrementa el valor 't' con el tiempo
            t += velocidadCambio * Time.deltaTime;

            // Calcula el nuevo color interpolando entre colorInicio y colorFin
            Color nuevoColor;

            if (cambiarAColorFin)
            {
                nuevoColor = Color.Lerp(colorInicio, colorFin, Mathf.PingPong(t, 1.0f));
            }
            else
            {
                nuevoColor = Color.Lerp(colorFin, colorInicio, Mathf.PingPong(t, 1.0f));
            }

            // Asigna el nuevo color al SpriteRenderer
            spriteRenderer.color = nuevoColor;

            // Si hemos alcanzado uno de los colores, cambia la dirección
            if (t >= 1.0f)
            {
                t = 0.0f;
                cambiarAColorFin = !cambiarAColorFin;
            }
        }
    }
}