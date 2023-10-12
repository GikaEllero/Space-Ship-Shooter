using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class GameManager : MonoBehaviour
{
    public static int playerScore = 0;
    public static int vidas = 10;
    public static GameObject player;
    private KeyCode start = KeyCode.I;

    public static void SetScore()
    {
        playerScore += 50;
    }

    public static void SetVidas()
    {
        vidas -= 1;
        if(vidas > 0)
            player.gameObject.SendMessage("ResetPlayer", 1.0f, SendMessageOptions.RequireReceiver);
        else
            SceneManager.LoadScene("Lose");
    }

    public void Start(){
        player = GameObject.FindWithTag("Player");
    }

    public void Update(){
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Start")
        {
            if(Input.GetKey(start))
                SceneManager.LoadScene("Game");
        } 
    }

}
