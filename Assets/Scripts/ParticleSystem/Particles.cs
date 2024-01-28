using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace particleSystem
{
    public class Particles : MonoBehaviour
    {
        public enum Type 
        {
            Background, 
            Player
        }
        
        public GameObject particle;
        public Type particleType;
        
        [Header ("Position")]
        public float posX;
        public Vector2 limit;
        [Header ("Scale")]
        public Vector2 scale;
        [Header ("Scale")]
        public Vector2 minScale;
        public Vector2 maxScale; 

        [Header ("Spawn")]
        public Vector2 time;
        public Vector2 spawn;
        int i;
        bool started;

        int runningCoroutines;

        void Start()
        {
            StartCoroutine(SpawnIE());
            StartCoroutine(LateStart());
        }

        IEnumerator LateStart()
        {
            yield return new WaitForSeconds(0.5f);
            if (!started) 
            {
                runningCoroutines = 0;
                StartCoroutine(SpawnIE()); 
                Debug.Log("Restarting particles...");
                StartCoroutine(LateStart());
            }
        }

        IEnumerator SpawnIE()
        {
            if (runningCoroutines == 0)
            {
                runningCoroutines++;
                if (KillMenuSystem.Settings.IsOn[0])
                {
                    float c = Random.Range(spawn.x, spawn.y);
                    for (i = 0; i < c; i++)
                    {
                        GameObject obj = Instantiate(particle);
                        obj.transform.position = new Vector2(posX, Random.Range(limit.x, limit.y));
                        if (particleType == Type.Background)
                        {
                            obj.transform.localScale = new Vector2(Random.Range(scale.x, scale.y), obj.transform.localScale.y);
                            obj.GetComponent<Movement>().enabled = true;
                        }

                        if (particleType == Type.Player)
                        {
                            obj.transform.localScale = new Vector2(Random.Range(minScale.x, minScale.y), Random.Range(maxScale.x, maxScale.y));
                            obj.GetComponent<CubeParticle>().enabled = true;
                        }
                        float t = Random.Range(time.x, time.y);
                        yield return new WaitForSeconds(t / c);
                    }
                    started = true;
                    i = 0;
                    runningCoroutines = 0;
                    StartCoroutine(SpawnIE());
                }

                else
                {
                    started = true;
                    i = 0;
                    yield return new WaitForSeconds(1f);
                    runningCoroutines = 0;
                    StartCoroutine(SpawnIE());
                }
            }
        }

        public void SetMaxPos()
        {
            limit = new Vector2(limit.x, particle.transform.position.y);
        }

        public void SetMinPos()
        {
            limit = new Vector2(particle.transform.position.y, limit.y);
        }

        public void SetMaxScale()
        {
            if (particleType == Type.Background)
            {
                scale = new Vector2(scale.x, particle.transform.localScale.x);
            }

            if (particleType == Type.Player)
            {
                maxScale = new Vector2(particle.transform.localScale.x, particle.transform.localScale.y);
            }
        }

        public void SetMinScale()
        {
            if (particleType == Type.Background)
            {
                scale = new Vector2(particle.transform.localScale.x, scale.y);
            }

            if (particleType == Type.Player)
            {
                minScale = new Vector2(particle.transform.localScale.x, particle.transform.localScale.y);
            }
        }
    }
}