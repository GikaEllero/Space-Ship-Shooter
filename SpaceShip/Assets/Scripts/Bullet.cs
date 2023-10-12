using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    public System.Action destroyed;
    public Vector3 direcao;

    public void OnTriggerEnter2D(Collider2D col){
        if(destroyed != null)
            this.destroyed.Invoke();
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direcao * speed * Time.deltaTime;
    }
}
