using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KillMenuSystem
{
    public class ObjectAction : MonoBehaviour
    {
        public enum ActionType
        {
            Scale, 
            Rotate
        }

        bool revert;
        public bool onStart;
        public ActionType actionType;
        public Vector2 limit = new Vector2(0, 360);
        public float speed = 360f;
        public float interval = 5f;

        float i;
        [Range(0, 10f)] public float add;

        void Start()
        {
            i = limit.x;
            if (onStart)
            {
                if (actionType == ActionType.Scale) {Q2();}
            }
        }
        
        void Update()
        {
            
        }

        public void Action() 
        {
            if (actionType == ActionType.Rotate) {Q1();}
            if (actionType == ActionType.Scale) {Q2();}
        }

        public void Q1()
        {
            if (i <= limit.y)
            {
                i += add;
                Quaternion q = transform.rotation;
                q = Quaternion.Euler(0, 0, i);
                transform.rotation = q;
                Invoke("Q1", interval);
            }

            else
            {
                i = limit.x;
            }
        }

        public void Q2()
        {
            if (!revert)
            {
                if (i <= limit.y)
                {
                    i += add;

                    transform.localScale = new Vector2(i, i);
                }

                else
                {
                    revert = true;
                }
            }

            else
            {
                if (i >= limit.x)
                {
                    i -= add;

                    transform.localScale = new Vector2(i, i);
                }

                else
                {
                    revert = false;
                }
            }

            Invoke("Q2", interval);
        }
    }
}