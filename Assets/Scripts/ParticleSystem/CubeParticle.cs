using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace particleSystem
{
    public class CubeParticle : MonoBehaviour
    {
        public Vector2 jumpSpeed;

        void Update()
        {
            float jump = Random.Range(jumpSpeed.x, jumpSpeed.y);
            GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, jump);
        }

        void OnTriggerEnter2D(Collider2D col) 
        {
            if (col.gameObject.CompareTag("Floor"))
            {
                Destroy(gameObject);
            }
        }
    }
}