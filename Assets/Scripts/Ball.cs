using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public float speed = 200f;
    public new Rigidbody2D rigidbody { get; private set; }
    private Player1_Paddle player1;
       private Player2_paddle player2;
       private Powerups pu;
    public GameObject Powerups_Script;
    
private AreaDetection AD;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        player2=GameObject.Find("Player2_Paddle").GetComponent<Player2_paddle>();
        player1=GameObject.Find("Player1_Paddle").GetComponent<Player1_Paddle>();
        pu= Powerups_Script.GetComponent<Powerups>();
        AD= GameObject.Find("Player_1_Area").GetComponent<AreaDetection>();
       
    }

    public void ResetPosition()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.position = Vector2.zero;
    }

    public void AddStartingForce()
    {
        // Flip a coin to determine if the ball starts left or right
        float x = Random.value < 0.5f ? -1f : 1f;

        // Flip a coin to determine if the ball goes up or down. Set the range
        // between 0.5 -> 1.0 to ensure it does not move completely horizontal.
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f)
                                      : Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        rigidbody.AddForce(direction * speed);
    }

    public void AddForce(Vector2 force)
    {
        rigidbody.AddForce(force);
    }
    void update()
    {

    }

    public void MagnetPowerup()
    {
        
    if(AD.P1Area==false){transform.position=player2.transform.position;}
    if(AD.P1Area==true){transform.position=player1.transform.position;}
    rigidbody.velocity= Vector2.zero;
        rigidbody.position = Vector2.zero;
StartCoroutine(MagnetHold());
    }
    IEnumerator MagnetHold()
    {
yield return new WaitForSeconds(3.0f);
        if(AD.P1Area==false)
        {
        float x =  -1.0f ;

        // Flip a coin to determine if the ball goes up or down. Set the range
        // between 0.5 -> 1.0 to ensure it does not move completely horizontal.
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f)
                                      : Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        rigidbody.AddForce(direction * speed);
        }
          if(AD.P1Area==true)
        {
        float x =  1.0f ;

        // Flip a coin to determine if the ball goes up or down. Set the range
        // between 0.5 -> 1.0 to ensure it does not move completely horizontal.
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f)
                                      : Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        rigidbody.AddForce(direction * speed);
        }
    }

}
