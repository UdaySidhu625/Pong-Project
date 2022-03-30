using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Powerups : MonoBehaviour
{
    public bool SpeedP;
    public bool Freezep;
    public bool Double_Paddle ;
    public bool MagnetP;
   
 
    
 
    private Player1_Paddle player1;
    private Player2_paddle player2;
    
    private GameManager_1 GM;
    private AreaDetection AD;
    private Ball ball;
  
    
   
    // Start is called before the first frame update
    void Awake()
    {
        GM= GameObject.Find("GameManager").GetComponent<GameManager_1>();
        AD= GameObject.Find("Player_1_Area").GetComponent<AreaDetection>();
        player1=GameObject.Find("Player1_Paddle").GetComponent<Player1_Paddle>();
        player2=GameObject.Find("Player2_Paddle").GetComponent<Player2_paddle>();
        ball= GameObject.Find("Ball").GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
//speed Poweup//
public void OnTriggerEnter2D(Collider2D other)
{
     Debug.Log("powerup");
    if(other.gameObject.CompareTag("Ball")){
        if(Double_Paddle== true){GM.DoublePaddle(other);};
           
          if(SpeedP==true){ GM.PlayerSpeedPowerup( other);};
           if(Freezep==true){GM.FreezePlayer(other);};
           if(MagnetP==true){ball.MagnetPowerup();};
          
           Destroy(gameObject);
    }
         
        
}





//freeze Powerup


    
}
