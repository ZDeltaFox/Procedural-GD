using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterController : MonoBehaviour
    {
        [System.Serializable]
        public class PlayerType
        {
            public GameObject cube;
            public Collider2D cubeCollider;
            public GameObject ship;
            public Collider2D shipCollider;
            public GameObject ufo;
            public Collider2D ufoCollider;
        }

        [System.Serializable]
        public class Animations
        {
            public Animator upSpikes;
            public Animator downSpikes;
        }

        public enum Type 
        {
            Cube,
            Ship,
            UFO
        }
        public Type type;
        public PlayerType playerType;
        public Animations animations;
        private bool isColliding;
        private bool isColliding2;
        public Quaternion quat;
        [Header ("Cube")]
        public float rotation;
        public float jump;
        Quaternion q;
        private float timer;
        public bool autoRotate;
        public GameObject particleSystem;
        public float rotationSpeed;
        public float cubeGravity;

        [Header ("Ship")]
        public Vector2 shipRotation;
        public Vector2 shipVelocity;
        public float shitSmoothRotation;
        public float shipGravity;
        bool Changed;

        [Header ("UFO")]
        public float ufoJump;
        public float ufoCooldown;
        float ufoTimer;

        void Start()
        {
            Changed = false;
        }

        public static bool appeared;

        public void AppearOrDisappear()
        {
            appeared = animations.upSpikes.GetBool("Active");
            animations.upSpikes.SetBool("Active", !appeared);
            animations.downSpikes.SetBool("Active", !appeared);
            appeared = animations.upSpikes.GetBool("Active");
        }

        void FixedUpdate()
        {
            appeared = animations.upSpikes.GetBool("Active");
            if (KillMenuSystem.Death.isDeath)
            {
                transform.position = new Vector2(-6, transform.position.y);
                gameObject.transform.rotation = quat;
                q = gameObject.transform.rotation;
                quat = Quaternion.Euler(quat.x, quat.y, -Mathf.Round(q.eulerAngles.z / 90) * 90);
            }
            if (!KillMenuSystem.Death.isDeath)
            {
                //transform.Translate(x, 0, 0);
                if (Mathf.Round(transform.position.x) != -6)
                {
                    transform.position = new Vector2(-6, transform.position.y);
                }
                //gameObject.transform.rotation = Quaternion.Euler(quat.x, quat.y, quat.z);
                gameObject.transform.rotation = quat;
                q = gameObject.transform.rotation;

                #region Cube
                if (type == Type.Cube)
                {
                    if (Changed)
                    {
                        animations.upSpikes.SetBool("Active", false);
                        animations.downSpikes.SetBool("Active", false);
                    }
                    animations.upSpikes.SetBool("Active", false);
                    animations.downSpikes.SetBool("Active", false);

                    if (cubeGravity != GetComponent<Rigidbody2D>().gravityScale || cubeGravity != -GetComponent<Rigidbody2D>().gravityScale)
                    {
                        if (0 <= GetComponent<Rigidbody2D>().gravityScale)
                        {
                            GetComponent<Rigidbody2D>().gravityScale = cubeGravity;
                        }

                        else {GetComponent<Rigidbody2D>().gravityScale = -cubeGravity;}
                    }
                    playerType.cube.SetActive(true);
                    playerType.ship.SetActive(false);
                    playerType.ufo.SetActive(false);
                    playerType.cubeCollider.enabled = true;
                    playerType.shipCollider.enabled = false;
                    playerType.ufoCollider.enabled = false;
                    if (Input.GetKey("space") || Input.GetKey("mouse 0"))
                    {
                        if (isColliding2)
                        {
                            GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, jump);
                        }
                    }

                    if (!isColliding || Input.GetKey("space") || Input.GetKey("mouse 0"))
                    {
                        gameObject.transform.rotation = quat;
                        transform.Rotate(0, 0, rotation, Space.Self);
                        quat = gameObject.transform.rotation;
                    }
                }
                #endregion
                #region Ship
                if (type == Type.Ship)
                {
                    if (!Changed) {Changed = true;}
                    animations.upSpikes.SetBool("Active", true);
                    animations.downSpikes.SetBool("Active", true);

                    if (shipGravity != GetComponent<Rigidbody2D>().gravityScale || shipGravity != -GetComponent<Rigidbody2D>().gravityScale)
                    {
                        if (0 <= GetComponent<Rigidbody2D>().gravityScale)
                        {
                            GetComponent<Rigidbody2D>().gravityScale = shipGravity;
                        }

                        GetComponent<Rigidbody2D>().gravityScale = shipGravity;
                    }
                    playerType.cube.SetActive(false);
                    playerType.ship.SetActive(true);
                    playerType.ufo.SetActive(false);
                    playerType.cubeCollider.enabled = false;
                    playerType.shipCollider.enabled = true;
                    playerType.ufoCollider.enabled = false;
                    if (Input.GetKey("space") || Input.GetKey("mouse 0"))
                    {
                        targetRotation = Quaternion.Euler(0, 0, shipRotation.y);
                        savedRotation = Quaternion.Euler(0, 0, q.eulerAngles.z);
                        GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, shipVelocity.y);
                    }

                    if (!isColliding && !Input.GetKey("space") && !Input.GetKey("mouse 0"))
                    {
                        targetRotation = Quaternion.Euler(0, 0, shipRotation.x);
                        savedRotation = Quaternion.Euler(0, 0, q.eulerAngles.z);
                        GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, shipVelocity.x);
                    }

                    if (isColliding && timer >= 0.1f && !Input.GetKey("space") && !Input.GetKey("mouse 0")) 
                    {
                        quat = Quaternion.Lerp(quat, targetRotation, Time.deltaTime * shitSmoothRotation);
                    }

                    if (isColliding2 && !Input.GetKey("space") && !Input.GetKey("mouse 0"))
                    {
                        if (timer <= 0.1f) {quat = Quaternion.Lerp(quat, targetRotation, Time.deltaTime * rotationSpeed);}
                        else {quat = Quaternion.Euler(quat.x, quat.y, -Mathf.Round(q.eulerAngles.z / 90) * 90);}
                    }

                    quat = Quaternion.Lerp(quat, targetRotation, Time.deltaTime * rotationSpeed);
                }
                #endregion
                #region UFO
                if (type == Type.UFO)
                {
                    if (Changed)
                    {
                        animations.upSpikes.SetBool("Active", false);
                        animations.downSpikes.SetBool("Active", false);
                    }
                    animations.upSpikes.SetBool("Active", false);
                    animations.downSpikes.SetBool("Active", false);

                    if (cubeGravity != GetComponent<Rigidbody2D>().gravityScale || cubeGravity != -GetComponent<Rigidbody2D>().gravityScale)
                    {
                        if (0 <= GetComponent<Rigidbody2D>().gravityScale)
                        {
                            GetComponent<Rigidbody2D>().gravityScale = cubeGravity;
                        }

                        else {GetComponent<Rigidbody2D>().gravityScale = -cubeGravity;}
                    }
                    playerType.cube.SetActive(false);
                    playerType.ship.SetActive(false);
                    playerType.ufo.SetActive(true);
                    playerType.cubeCollider.enabled = false;
                    playerType.shipCollider.enabled = false;
                    playerType.ufoCollider.enabled = true;
                    if (Input.GetKey("space") || Input.GetKey("mouse 0"))
                    {
                        if (ufoTimer >= ufoCooldown)
                        {
                            ufoTimer = 0;
                            GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, ufoJump);
                        }
                    }

                    ufoTimer += Time.deltaTime;
                    quat = Quaternion.Euler(0, 0, 0);

                    if (!isColliding || Input.GetKey("space") || Input.GetKey("mouse 0"))
                    {

                    }
                }
                #endregion

                timer += Time.deltaTime;
                if (timer >= 0.1f && !isColliding2)
                {
                    isColliding = false;
                    //particleSystem.GetComponent<ParticleSystem>().emission.enabled = false;
                    //particleSystem.GetComponent<ParticleSystem>().Clear();
                    particleSystem.GetComponent<ParticleSystem>().Stop();
                }

                if (isColliding2 && !Input.GetKey("space") && !Input.GetKey("mouse 0"))
                {
                    if (type != Type.Ship)
                    {
                        if (timer <= 0.1f) {quat = Quaternion.Lerp(quat, targetRotation, Time.deltaTime * rotationSpeed);}
                        else {quat = Quaternion.Euler(quat.x, quat.y, -Mathf.Round(q.eulerAngles.z / 90) * 90);}
                    }
                }
            }
        }

        public void Jumper(float jumper)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(GetComponent<Rigidbody2D>().velocity.x, jumper);
        }

        public void Gravity()
        {
            Debug.Log("Gravity Changed");
            if (canChangeGravity)
            {
                canChangeGravity = false;
                GetComponent<Rigidbody2D>().gravityScale = -GetComponent<Rigidbody2D>().gravityScale;
                StartCoroutine(GravityIE());
            }
        }

        bool canChangeGravity = true;

        IEnumerator GravityIE()
        {
            yield return new WaitForSeconds(0.1f);
            canChangeGravity = true;
        }
        //public float savedRotation;
        //public float targetRotation;
        public Quaternion savedRotation;
        public Quaternion targetRotation;
        
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Floor"))
            {
                if (quat.z != Mathf.Round(quat.z))
                {
                    if (!Input.GetKey("space") || !Input.GetKey("mouse 0"))
                    {  
                        if (autoRotate)
                        {
                            if (!isColliding)
                            {
                                
                                //targetRotation = Mathf.Round(q.eulerAngles.z / 90) * 90;
                                //savedRotation = q.eulerAngles.z;
                                targetRotation = Quaternion.Euler(0, 0, Mathf.Round(q.eulerAngles.z / 90) * 90);
                                savedRotation = Quaternion.Euler(0, 0, q.eulerAngles.z);
                                //quat = Quaternion.Euler(quat.x, quat.y, -Mathf.Round(q.eulerAngles.z / 90) * 90);
                                //quat = Quaternion.Euler(quat.x, quat.y, 0);
                                //particleSystem.GetComponent<ParticleSystem>().emission.enabled = true;
                                particleSystem.GetComponent<ParticleSystem>().Play();
                            }
                        }
                    }

                    timer = 0;
                    isColliding = true;
                    isColliding2 = true;
                }
            }

            if (col.gameObject.CompareTag("Spike"))
            {
                KillMenuSystem.Death.isDeath = true;
            }
        }

        void OnCollisionExit2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Floor")) isColliding2 = false;
        }

        void OnCollisionStay2D(Collision2D col)
        {
            
        }
    }
}