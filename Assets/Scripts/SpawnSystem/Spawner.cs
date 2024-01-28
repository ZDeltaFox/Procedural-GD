using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnSystem
{
    public class Spawner : MonoBehaviour
    {
        public enum Mode
        {
            Cube,
            Ship,
            UFO
        }

        /*public enum Velocity 
        {
            x05,
            x1,
            x2,
            x3,
            x4
        }*/

        public enum Gravity
        {
            Normal,
            Invert
        }

        public Mode mode;
        //public Velocity velocity;
        public Gravity gravity;
        public SpawnableObject[] spawnableObjects;

        [Header ("Time")]
        public Vector2 randomTime;
        public float time;

        [Header ("Spawned")]
        public int lastSpawned;

        bool i;

        bool myCoroutineActive;

        public string searchObject;

        //string a;
        string b;
        string c;

        public float timer;

        public CharacterSystem.CharacterController characterController;

        void Start()
        {
            InMenu.i = true;
            spawnableObjects = FindObjectsOfType<SpawnableObject>();
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
            StartCoroutine(Spawn());
        }

        void Update()
        {
            mode = (Mode)characterController.type;
            if (i != InMenu.i)
            {
                i = InMenu.i;
                StartCoroutine(Spawn());
            }

            if (!myCoroutineActive)
            {
                //timer = 0;
                //StartCoroutine(Spawn());
            }

            timer += Time.deltaTime;

            if (timer >= 5)
            {
                myCoroutineActive = false;
                StartCoroutine(Spawn());
            }

            if (timer >= time)
            {
                if (!InMenu.i)
                {
                    myCoroutineActive = true;

                    if (gravity == Gravity.Normal) {b = "Normal";}
                    if (gravity == Gravity.Invert) {b = "Invert";}

                    if (mode == Mode.Cube) {c = "Cube";}
                    if (mode == Mode.Ship) {c = "Ship";}
                    if (mode == Mode.UFO) {c = "UFO";}
                    //searchObject = "SpawningCube/" + a + "/" + b + "/" + c;
                    searchObject = "SpawningCube/" + b + "/" + c;
                    //spawnableObjects = FindObjectsOfType<SpawnableObject>();
                    spawnableObjects = GameObject.Find(searchObject).GetComponentsInChildren<SpawnableObject>();
                    lastSpawned = Random.Range(0, spawnableObjects.Length);
                    GameObject obj = Instantiate(spawnableObjects[lastSpawned]).gameObject;
                    obj.GetComponent<BlockMovement>().isSpawned = true;
                    myCoroutineActive = false;
                    time = Random.Range(randomTime.x, randomTime.y);
                    timer = 0;
                }
            }
           
            /*if (velocity == Velocity.x05) {a = "x0.5";}
            if (velocity == Velocity.x1) {a = "x1";}
            if (velocity == Velocity.x2) {a = "x2";}
            if (velocity == Velocity.x3) {a = "x3";}
            if (velocity == Velocity.x4) {a = "x4";}*/

            if (gravity == Gravity.Normal) {b = "Normal";}
            if (gravity == Gravity.Invert) {b = "Invert";}

            if (mode == Mode.Cube) {c = "Cube";}
            if (mode == Mode.Ship) {c = "Ship";}
            if (mode == Mode.UFO) {c = "UFO";}
            //searchObject = "SpawningCube/" + a + "/" + b + "/" + c;
            searchObject = "SpawningCube/" + b + "/" + c;
            //spawnableObjects = GameObject.Find(searchObject).GetComponentsInChildren<SpawnableObject>();
        }

        void RSpawn()
        {
            if (!InMenu.i)
            {
                myCoroutineActive = true;

                if (gravity == Gravity.Normal) {b = "Normal";}
                if (gravity == Gravity.Invert) {b = "Invert";}

                if (mode == Mode.Cube) {c = "Cube";}
                if (mode == Mode.Ship) {c = "Ship";}
                if (mode == Mode.UFO) {c = "UFO";}
                //searchObject = "SpawningCube/" + a + "/" + b + "/" + c;
                searchObject = "SpawningCube/" + b + "/" + c;
                //spawnableObjects = FindObjectsOfType<SpawnableObject>();
                spawnableObjects = GameObject.Find(searchObject).GetComponentsInChildren<SpawnableObject>();
                lastSpawned = Random.Range(0, spawnableObjects.Length);
                GameObject obj = Instantiate(spawnableObjects[lastSpawned]).gameObject;
                obj.GetComponent<BlockMovement>().isSpawned = true;
                //yield return new WaitForSeconds(time);
                //timer = 0;
                //StartCoroutine(Spawn());
                myCoroutineActive = false;
                time = Random.Range(randomTime.x, randomTime.y);
            }
        }

        IEnumerator Spawn()
        {
            yield return new WaitForSeconds(1);
            /*
            if (!InMenu.i)
            {
                myCoroutineActive = true;

                if (gravity == Gravity.Normal) {b = "Normal";}
                if (gravity == Gravity.Invert) {b = "Invert";}

                if (mode == Mode.Cube) {c = "Cube";}
                if (mode == Mode.Ship) {c = "Ship";}
                if (mode == Mode.UFO) {c = "UFO";}
                //searchObject = "SpawningCube/" + a + "/" + b + "/" + c;
                searchObject = "SpawningCube/" + b + "/" + c;
                //spawnableObjects = FindObjectsOfType<SpawnableObject>();
                spawnableObjects = GameObject.Find(searchObject).GetComponentsInChildren<SpawnableObject>();
                lastSpawned = Random.Range(0, spawnableObjects.Length);
                GameObject obj = Instantiate(spawnableObjects[lastSpawned]).gameObject;
                obj.GetComponent<BlockMovement>().isSpawned = true;
                yield return new WaitForSeconds(time);
                //timer = 0;
                //StartCoroutine(Spawn());
                myCoroutineActive = false;
            }*/
        }
    }
}
