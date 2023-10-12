using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Enemy enemyPrefab;
    public float timer = 3.0f;
    public float currentSpawnTime;

    public void Spawn(){
        timer += Time.deltaTime;

        if(timer > currentSpawnTime)
        {
            timer = 0f;
            float num = Random.value;
            Vector3 posicao;
            if(Random.value < 0.5){
                posicao = new Vector3(6.6f, num * 3.3f , 0f);
            }
            else{
                posicao = new Vector3(6.6f, num * 3.3f * -1 , 0f);
            }
            Enemy enemy = Instantiate(enemyPrefab, this.transform);
            enemy.transform.position = posicao;
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        currentSpawnTime = timer;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }
}
