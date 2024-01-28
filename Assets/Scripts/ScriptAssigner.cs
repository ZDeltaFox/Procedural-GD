using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

[ExecuteInEditMode]
public class ScriptAssigner : MonoBehaviour
{
    public bool set;
    public MonoBehaviour scriptAAsignar; // El script que deseas asignar a los objetos
    public Sprite spriteObjetivo; // El sprite cuya textura quieres detectar
    public Color colorObjetivo; // El color que quieres detectar

    private static void CopiarParametros(MonoBehaviour origen, MonoBehaviour destino)
    {
        FieldInfo[] campos = origen.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (FieldInfo campo in campos)
        {
            campo.SetValue(destino, campo.GetValue(origen));
        }
    }

    void Update()
    {
        if (set)
        {
            set = false;
            Debug.Log("Se ha añadido un script a varios objetos");
            if (spriteObjetivo == null)
            {
                Debug.LogError("Por favor, establece el sprite objetivo en el Inspector.");
                return;
            }

            // Busca todos los objetos en la escena con un componente SpriteRenderer o Image
            SpriteRenderer[] spriteRenderers = FindObjectsOfType<SpriteRenderer>();
            Image[] images = FindObjectsOfType<Image>();

            // Combina los objetos con SpriteRenderer y Image en una lista
            Component[] components = new Component[spriteRenderers.Length + images.Length];
            spriteRenderers.CopyTo(components, 0);
            images.CopyTo(components, spriteRenderers.Length);

            // Asigna el script a los objetos con el sprite objetivo y el color objetivo
            foreach (Component component in components)
            {
                SpriteRenderer spriteRenderer = component.GetComponent<SpriteRenderer>();
                Image image = component.GetComponent<Image>();

                if (spriteRenderer != null && spriteRenderer.sprite == spriteObjetivo)
                {
                    // Comprueba el color del objeto
                    if (spriteRenderer.color == colorObjetivo)
                    {
                        // Añade el script al objeto
                        GameObject objeto = spriteRenderer.gameObject;
                        MonoBehaviour nuevoScript = objeto.AddComponent(scriptAAsignar.GetType()) as MonoBehaviour;

                        // Copia los parámetros del script original al nuevo script
                        CopiarParametros(scriptAAsignar, nuevoScript);
                    }
                }
                else if (image != null && image.sprite == spriteObjetivo)
                {
                    // Comprueba el color del objeto
                    if (image.color == colorObjetivo)
                    {
                        // Añade el script al objeto
                        GameObject objeto = image.gameObject;
                        MonoBehaviour nuevoScript = objeto.AddComponent(scriptAAsignar.GetType()) as MonoBehaviour;

                        // Copia los parámetros del script original al nuevo script
                        CopiarParametros(scriptAAsignar, nuevoScript);
                    }
                }
            }
        }
    }
}
