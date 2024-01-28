using UnityEngine;
using UnityEngine.UI;

namespace PortalSystem
{
    public class BackgroundColorChange : MonoBehaviour
    {
        public enum Type
        {
            SpriteRenderer,
            Background
        }
        public enum Mode
        {
            Cube,
            Ship,
            UFO
        }
        
        public int objectType;
        public Type type;
        public SpriteRenderer material;  // El material del objeto que cambiará de color
        public Camera camera;
        public static float cambioDeColorSpeed;  // Velocidad de cambio de color
        public Color[] colores;  // Array de colores que deseas usar
        public Mode mode;  // Enum que controla el cambio de color

        private Color colorActual;
        private int colorIndex = 0;
        private Renderer rend;

        int i;
        private CharacterSystem.CharacterController characterController;
        private ColorChanger cc;

        private void Start()
        {
            if (type == Type.SpriteRenderer) {material = GetComponent<SpriteRenderer>();}
            if (type == Type.Background) {camera = GetComponent<Camera>();}
            cc = GameObject.Find("Global vars").GetComponent<ColorChanger>();
            colores = cc.colors[objectType].color;
            characterController = GameObject.Find("Player/Cube").GetComponent<CharacterSystem.CharacterController>();
            rend = GetComponent<Renderer>();
            colorActual = colores[0]; // Establece el color inicial
        }

        private void Update()
        {
            mode = (Mode)characterController.type;
            if (mode == Mode.Cube) {i = 0;}
            if (mode == Mode.Ship) {i = 1;}
            if (mode == Mode.UFO) {i = 2;}

            // Cambia gradualmente el color hacia el color actual
            colorActual = Color.Lerp(colorActual, colores[i], cambioDeColorSpeed * Time.deltaTime);
            if (type == Type.SpriteRenderer) {material.color = colorActual;}
            if (type == Type.Background) {camera.backgroundColor = colorActual;}
        }
    }
}