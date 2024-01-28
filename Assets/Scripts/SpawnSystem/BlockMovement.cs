using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem
{
    public class BlockMovement : MonoBehaviour
    {
        public enum Type 
        {
            Cube,
            Ship,
            UFO
        }
        public Type type;
        public float velocity;
        float spawnSpeed;
        float substract = -0.1f;
        float add = 0.005f;
        public Vector3 spawnCoordinates;
        public bool isSpawned;
        public float limit;
        SpawnSystem.Spawner sp;
        bool shrink = true;
        float shrinkSpeed = 5f;
        Collider2D[] allColliders;
        bool destroyActive;

        void Start()
        {
            spawnSpeed = velocity;
            sp = GameObject.Find("Spawner").GetComponent<SpawnSystem.Spawner>();
            if (isSpawned)
            {
                allColliders = GetComponentsInChildren<Collider2D>();  
                gameObject.transform.position = spawnCoordinates;
            }
        }

        void FixedUpdate()
        {
            if (KillMenuSystem.Death.isDeath)
            {
                if (spawnSpeed - 15 <= velocity)
                {
                    velocity += substract;
                    substract -= add;
                }

                else
                {
                    velocity = spawnSpeed - 15;
                }
            }
            if (isSpawned)
            {
                if (CharacterSystem.Modifiers.DestroyActive) {destroyActive = true;}
                float x = gameObject.transform.position.x;
                float y = gameObject.transform.position.y;
                float z = gameObject.transform.position.z;

                gameObject.transform.position = new Vector3(x - velocity / 100, y, z);

                if (x <= limit)
                {
                    Destroy(gameObject);
                }

                if ((Type)sp.mode != type || destroyActive)
                {
                    if (x >= -50)
                    {
                        //Destroy(gameObject);
                        if (shrink)
                        {
                            foreach(Collider2D c in allColliders) 
                            {
                                c.enabled = false;
                            }

                            transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed) * Time.deltaTime;
        
                            if(transform.localScale.x <= 0f) 
                            {
                                transform.localScale = Vector3.zero;
                                shrink = false; 
                                Destroy(gameObject);
                            }
                        }
                    }
                }
            }
        }
    }
}