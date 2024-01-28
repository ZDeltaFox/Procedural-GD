using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace particleSystem
{
    public class Movement : MonoBehaviour
    {
        public float velocity;
        public Vector2 movement;

        [Header ("Color")]
        public Gradient colorGradient;
        public Vector2 alpha;
        public Gradient colorShadow;
        public Vector2 alphaShadow;

        void Start()
        {
            velocity = Random.Range(movement.x, movement.y);
            float randomIndex = Random.value;
            Color col = GetComponent<SpriteRenderer>().color;
            col = colorGradient.Evaluate(randomIndex);
            col.a = Random.Range(alpha.x / 255, alpha.y / 255);
            GetComponent<SpriteRenderer>().color = col;
            Transform child = transform.GetChild(0);
            Color colShadow = child.GetComponent<SpriteRenderer>().color;
            colShadow = colorShadow.Evaluate(randomIndex);
            colShadow.a = Random.Range(alphaShadow.x / 255, alphaShadow.y / 255);
            child.GetComponent<SpriteRenderer>().color = colShadow;
        }

        void Update()
        {
            float x = gameObject.transform.position.x;
            float y = gameObject.transform.position.y;
            float z = gameObject.transform.position.z;
            gameObject.transform.position = new Vector3(x - (velocity / 10), y, z);

            if (x <= -20)
            {
                Destroy(gameObject);
            }
        }
    }
}