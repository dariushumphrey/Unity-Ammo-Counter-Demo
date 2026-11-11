using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotionTrackerScript : MonoBehaviour
{
    public float pulseDelay = 0.2f;
    public float pulseRestartDelay = 4f;
    public Image motionTracker;
    public Sprite[] trackerPulses;

    private bool pulseTimeout = true;
    private float animationTimer = 0f;
    private int pulseIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartTrackerPulse());
    }

    // Update is called once per frame
    void Update()
    {
        if(!pulseTimeout)
        {
            animationTimer += Time.deltaTime;
            if(animationTimer >= pulseDelay)
            {              
                if(pulseIndex >= trackerPulses.Length - 1)
                {
                    animationTimer = 0f;
                    pulseIndex = 0;
                    motionTracker.sprite = trackerPulses[pulseIndex];
                    pulseTimeout = true;
                    StartCoroutine(StartTrackerPulse());
                }

                else
                {
                    animationTimer = 0f;
                    pulseIndex++;
                    motionTracker.sprite = trackerPulses[pulseIndex];
                }
            }
        }
    }

    private IEnumerator StartTrackerPulse()
    {
        yield return new WaitForSeconds(pulseRestartDelay);
        pulseTimeout = false;
    }
}
