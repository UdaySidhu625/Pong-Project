using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager_1 : MonoBehaviour
{
    public Ball ball;

    public Paddle Player1_Paddle;
    public int player1_Score { get; private set; }
    public Text player1_ScoreText;

    public Paddlep Player2_Paddle;
    public int Player2_Score { get; private set; }
    public Text Player2_ScoreText;

     public GameObject D_p_p1;
     public GameObject D_p_p2;
      public bool d_p_Spawn;
      public GameObject Powerups_Script;
      


    
private Powerups pu;
private AreaDetection AD;
private Player1_Paddle player1;
private Player2_paddle player2;
    [SerializeField] GameObject winscreen_pl;
    [SerializeField] GameObject winscreen_p2;


    private void Start()
    {
        NewGame();
    }
    void Awake(){
        pu= Powerups_Script.GetComponent<Powerups>();
        AD= GameObject.Find("Player_1_Area").GetComponent<AreaDetection>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.R)){
            NewGame();
        }
      
              
         
      
        
      
if (player1_Score == 3){
  winscreen_pl.SetActive(true);
  Time.timeScale = 0f;
}
if (Player2_Score == 3){
    
     winscreen_p2.SetActive(true);
  Time.timeScale = 0f;
}
    }

    public void NewGame()
    {
        Set_Player1_Score(0);
        Set_Player2_Score(0);
        winscreen_pl.SetActive(false);
        winscreen_p2.SetActive(false);
        Time.timeScale = 1f;
        StartRound();
        
    }

    public void DoublePaddle(Collider2D other)
    {
       
             if(AD.P1Area == true)
             {
                
                StartCoroutine(DoublePaddlesP1());
                
           
            }
            if(AD.P1Area == false){
             
                StartCoroutine(DoublePaddlesP2());
                  
            }
        
    }
    public void FreezePlayer(Collider2D other)
    {  
          StartCoroutine( FreezeplayerFun());
        
       

    }
    public void PlayerSpeedPowerup(Collider2D other)
    {
StartCoroutine( ChangePlayerSpeed());
          
       
    }
 
 
 IEnumerator DoublePaddlesP1()
{ D_p_p1.SetActive(true);

yield return new WaitForSeconds(10.0f);
 D_p_p1.SetActive(false);

}
IEnumerator DoublePaddlesP2()
{ D_p_p2.SetActive(true);

yield return new WaitForSeconds(10.0f);
D_p_p2.SetActive(false);

}
IEnumerator FreezeplayerFun(){
    if(AD.P1Area == true)
    { Player2_Paddle.speed = 0;};
    if(AD.P1Area == false)
    {Player1_Paddle.speed = 0;};
    
   
     Debug.Log("freeze ");
    yield return new WaitForSeconds(2.0f);
     Player2_Paddle.speed = 8;
     Player1_Paddle.speed = 8;
     Debug.Log("freeze done");
    
    
}
IEnumerator ChangePlayerSpeed()
{
if(AD.P1Area == true)
{Player1_Paddle.speed = 16 ;};
if(AD.P1Area == false)
{Player2_Paddle.speed = 16 ;};



yield return new WaitForSeconds(5.0f);

Player1_Paddle.speed = 8 ;
Player2_Paddle.speed = 8 ;
Debug.Log("ok");

}

    public void StartRound()
    {
        Player1_Paddle.ResetPosition();
        Player2_Paddle.ResetPosition();
        ball.ResetPosition();
        ball.AddStartingForce();
    }

    public void Player1_Scores()
    {
        Set_Player1_Score(player1_Score + 1);
        StartRound();
    }

    public void Player2_Scores()
    {
        Set_Player2_Score(Player2_Score + 1);
        StartRound();
    }

    private void Set_Player1_Score(int score)
    {
        player1_Score = score;
        player1_ScoreText.text = score.ToString();
    }

    private void Set_Player2_Score(int score)
    {
        Player2_Score = score;
        Player2_ScoreText.text = score.ToString();
    }
    

    public void Mainmenu(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

}
