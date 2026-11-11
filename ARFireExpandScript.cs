using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARFireExpandScript : MonoBehaviour
{
    public Vector3 restScale = Vector3.one;
    public float shrinkSpeed = 2f;
    public float expandRate = 1.001f;
    private bool shrinkToRest = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shrinkToRest)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, restScale, (shrinkSpeed * Time.deltaTime));
            if(transform.localScale == restScale)
            {
                shrinkToRest = false;
            }
        }
    }

    public void SimulateShotSpread()
    {
        transform.localScale += new Vector3(transform.localScale.x * expandRate, transform.localScale.y * expandRate, transform.localScale.z);
        if(!shrinkToRest)
        {
            shrinkToRest = true;
        }
    }
}
