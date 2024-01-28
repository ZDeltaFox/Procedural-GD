using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MusicSystem
{
    public class BeatManager : MonoBehaviour
    {
        public float bpm;
        public AudioSource Audio;
        public Intervals[] intervals;

        public static float BPM;

        void Start()
        {
            
        }
        
        void Update()
        {
            bpm = BPM;

            foreach(Intervals interval in intervals)
            {
                float sampledTime = (Audio.timeSamples / (Audio.clip.frequency * interval.GetIntervalLength(bpm)));
                interval.ChechForNewInterval(sampledTime);
            }
        }
    }

    [System.Serializable]
    public class Intervals
    {
        public float steps;
        public UnityEvent trigger;
        private int lastInterval;

        public float GetIntervalLength(float bpm)
        {
            return 60f / (bpm * steps);
        }

        public void ChechForNewInterval (float interval)
        {
            if(Mathf.FloorToInt(interval) != lastInterval)
            {
                lastInterval = Mathf.FloorToInt(interval);
                trigger.Invoke();
            }
        }
    }
}