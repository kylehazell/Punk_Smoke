using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateKiller : MonoBehaviour
{
    private void onTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Obsticle"))
        {
            Destroy(collider.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
