using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnchorScript : MonoBehaviour
{
    public float actionSpeed = 3f;
    public Vector3 restPosition = Vector3.zero;
    public Vector3 restRotation = Vector3.zero;
    public Vector3 recoilPosition;

    private float repeatTimer = 0f;
    private bool recoilToRest = false;
    private bool repeatTimeout = false;

    internal float fireRateInsert;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (repeatTimeout)
        {
            repeatTimer += Time.deltaTime;
            if (repeatTimer >= fireRateInsert)
            {
                repeatTimer = 0f;
                repeatTimeout = false;
            }
        }

        if (recoilToRest)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, restPosition, (actionSpeed * Time.deltaTime));
            if (transform.localPosition == restPosition)
            {
                recoilToRest = false;
            }
        }
    }

    public void SimulateRecoil()
    {
        if (!repeatTimeout)
        {
            transform.localPosition = recoilPosition;
            recoilToRest = true;
            repeatTimeout = true;
        }
    }
}
