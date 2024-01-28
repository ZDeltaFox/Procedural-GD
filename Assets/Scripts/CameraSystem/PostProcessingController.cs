using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace CameraSystem
{
    public class PostProcessingController : MonoBehaviour
    {
        PostProcessLayer postProcessLayer;
        private PostProcessVolume volume;
        
        void Start() 
        {
            // Obtener el volumen de post-procesado
            postProcessLayer = GetComponent<Camera>().GetComponent<PostProcessLayer>();
            volume = GetComponent<PostProcessVolume>();
        }

        void Update() 
        {
            postProcessLayer.enabled = KillMenuSystem.Settings.IsOn[1];
            volume.enabled = KillMenuSystem.Settings.IsOn[1];
        }

        public void DisablePostProcessing()
        {
            // Deshabilitar el volumen para deshabilitar todos los efectos
            volume.enabled = false;

            // Otra opción es deshabilitar efectos individuales:
            //PostProcessProfile profile = volume.profile;
            //profile.GetSetting<Vignette>().enabled = false;
        }

        public void EnablePostProcessing()
        {
            // Re-habilitar el volumen y los efectos
            volume.enabled = true;
        
            // Habilitar efectos individuales
            //PostProcessProfile profile = volume.profile;
            //profile.GetSetting<Vignette>().enabled = true; 
        }
    }
}