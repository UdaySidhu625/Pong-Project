using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawn : MonoBehaviour
{
  /*public GameObject Powerup1,Powerup2,Powerup3,Powerup4;


    public float spawnrate = 10f;
    public float Radius = 1;
    Vector3 Position;

    float nextSpawn = 0f;

    int WhatToSpawn;

    public void Awake() {
         Position = Random.insideUnitCircle * Radius;
     }
    

    
  
    // Update is called once per frame
    void Update()
    { 
        if(Time.time > nextSpawn){
            WhatToSpawn = Random.Range(1,5);
            Debug.Log(WhatToSpawn);

        switch (WhatToSpawn)
        {
          
            case 1:
            Instantiate(Powerup1, Position * Random.Range(1,3) , Quaternion.identity);
                break;
                 case 2:
            Instantiate(Powerup2,  Position * Random.Range(1,3), Quaternion.identity);
                break;
                 case 3:
            Instantiate(Powerup3,  Position * Random.Range(1,3), Quaternion.identity);
                break;
                 case 4:
            Instantiate(Powerup4,  Position * Random.Range(1,3), Quaternion.identity);
                break;
            
        

        }

        nextSpawn = Time.time + spawnrate; 
    }
    }*/

public int numberToSpawn;
public List<GameObject> spawnPool;
public GameObject quad;
int timeS = 0;



private void Start() {
   
}
private void Update() {
    if(Time.time> timeS){
             timeS+=10;
 SpawnObjects();
    }
}
public void SpawnObjects()
{desttroyObjects();
    int randomItem= 0;
    GameObject toSpawn;
    MeshCollider c =quad.GetComponent<MeshCollider>();

    float screenX,screenY;
    Vector2 pos;
{
   
    for(int i= 0 ; i< numberToSpawn; i++ )
    {
        
        randomItem =Random.Range(0 ,spawnPool.Count);
        toSpawn =spawnPool[randomItem];

        screenX=Random.Range(c.bounds.min.x, c.bounds.max.x);
        screenY=Random.Range(c.bounds.min.y, c.bounds.max.y);
        pos= new Vector2(screenX,screenY);

        Instantiate(toSpawn,pos,toSpawn.transform.rotation);
        
    }
}
}
private void desttroyObjects()
{
foreach (GameObject o  in GameObject.FindGameObjectsWithTag("Powerups") )
{
    Destroy(o);
}
}


/*IEnumerator SpawnPowerups()
{
   yield return new WaitForSeconds(10.0f);
   SpawnObjects();
}
*/
}
