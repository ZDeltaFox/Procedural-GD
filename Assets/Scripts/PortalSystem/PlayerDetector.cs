using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalSystem
{
    public class PlayerDetector : MonoBehaviour
    {
        public enum PortalType
        {
            Camera,
            Gravity,
            Velocity,
            Cube,
            Ship,
            UFO
        }

        public int uses;

        public PortalType type;
        IEnumerator ResetUses()
        {
            yield return new WaitForSeconds(0.2f);
            uses = 0;
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            float ts = Time.timeScale;
            if (col.gameObject.CompareTag("Player"))
            {
                if (type == PortalType.Camera)
                {
                    Debug.Log("Invert Camera");
                    GameObject.Find("Main Camera").GetComponent<CameraSystem.CameraFlip>().ChangeCameraEffect();
                }

                if (type == PortalType.Gravity)
                {
                    CharacterSystem.CharacterController cc = GameObject.Find("Player/Cube").GetComponent<CharacterSystem.CharacterController>();
                    cc.Gravity();
                }

                if (type == PortalType.Velocity)
                {
                    if (uses == 0)
                    {
                        StartCoroutine(ResetUses());
                        uses++;
                        if (ts == 1.25f) 
                        {
                            Time.timeScale = 1f;
                        }

                        if (ts == 1f) 
                        {
                            Time.timeScale = 1.25f;
                        }
                    }
                }

                if (type == PortalType.Cube)
                {
                    CharacterSystem.CharacterController pccscc = GameObject.Find("Player/Cube").GetComponent<CharacterSystem.CharacterController>();
                    pccscc.type = CharacterSystem.CharacterController.Type.Cube;
                }

                if (type == PortalType.Ship)
                {
                    CharacterSystem.CharacterController pccscc = GameObject.Find("Player/Cube").GetComponent<CharacterSystem.CharacterController>();
                    pccscc.type = CharacterSystem.CharacterController.Type.Ship;
                }

                if (type == PortalType.UFO)
                {
                    CharacterSystem.CharacterController pccscc = GameObject.Find("Player/Cube").GetComponent<CharacterSystem.CharacterController>();
                    pccscc.type = CharacterSystem.CharacterController.Type.UFO;
                }
            }
        }
    }
}