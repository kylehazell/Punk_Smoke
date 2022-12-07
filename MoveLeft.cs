using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    public bool isGameOver;
    // Start is called before the first frame update
   
    
    // Update is called once per frame
    void Update()
    {
        isGameOver = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().gameHasEnded;
        if(isGameOver != true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
       }
    }
}
