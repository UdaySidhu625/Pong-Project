using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerVplayer(int sceneID)
    {
SceneManager.LoadScene(sceneID);
    }
    public void comp(int sceneID)
    {
SceneManager.LoadScene(sceneID);
    }
}
