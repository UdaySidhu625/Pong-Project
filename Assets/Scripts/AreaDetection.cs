using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDetection : MonoBehaviour
{
    // Start is called before the first frame update
  public bool P1Area;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) 
    {if(other.CompareTag("Ball"))
    {
P1Area = true;
    }else{
        P1Area = false;
    }
        
    }
}
