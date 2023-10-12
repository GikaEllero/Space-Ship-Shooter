using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseText : MonoBehaviour
{

    public TextMesh texto;

    // Start is called before the first frame update
    void Start()
    {
        texto.text = "Score: " + GameManager.playerScore;
    }
}
