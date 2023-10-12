using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    public float timer = 1f;
    public float currentAttackTime;
    public Bullet bulletPrefab;

    public void Atirar(){
        timer += Time.deltaTime;

        if(timer > currentAttackTime)
        {
            timer = 0f;
            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.transform.Rotate(0f, 0f, 180f);
        } 
    }

    public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name != "RightWall"){
            GameManager.SetScore();
            Destroy(this.gameObject);
        }  
    }

    // Start is called before the first frame update
    void Start()
    {
        currentAttackTime = timer;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;

        Atirar();
    }
}
