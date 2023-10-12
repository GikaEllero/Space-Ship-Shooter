using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private KeyCode up = KeyCode.UpArrow;
    private KeyCode down = KeyCode.DownArrow;
    public float speed = 3.0f;
    public float boundY = 3.3f;
    public Bullet bulletPrefab;
    private bool canAttack;
    public float attackTimer = 0.8f;
    public float currentAttackTime;

    public void Atirar()
    {
        attackTimer += Time.deltaTime;

        if(attackTimer > currentAttackTime)
            canAttack = true;

        if (Input.GetKeyDown(KeyCode.Space)){
            if(canAttack)
            {
            canAttack = false;
            attackTimer = 0f;

            Instantiate(bulletPrefab, transform.position, Quaternion.identity);  
            }
        }
    }

    public void ResetPlayer(){
    	transform.position = new Vector2(-5f, 0f);
    }

    public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.layer == LayerMask.NameToLayer("Enemy") ||
            col.gameObject.layer == LayerMask.NameToLayer("EnemyBullet")){
            GameManager.SetVidas();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentAttackTime = attackTimer;
    }

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetKey(up))
            transform.position += Vector3.up * speed * Time.deltaTime;
        else if (Input.GetKey(down))
            transform.position += Vector3.down * speed * Time.deltaTime;

        var pos = transform.position;

    	if (pos.y > boundY) 
        	pos.y = boundY;
   	    else if (pos.y < -boundY)
        	pos.y = -boundY;
    	
    	transform.position = pos;

        Atirar();
        
    }
}
