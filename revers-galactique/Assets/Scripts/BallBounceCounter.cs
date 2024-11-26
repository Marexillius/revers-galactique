using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounceCounter : MonoBehaviour
{
    private int BounceCounter = 0;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            BounceCounter++;
            Debug.Log(BounceCounter);
        }

        if (BounceCounter == 10)
        {   
            /*gameObject.transform.localScale = Vector3.one;
            Destroy(gameObject);*/
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
