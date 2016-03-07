using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public float damage = 10.0f;
    public float speed = 0.5f;
    public float DestroyTime = 5.0f;
    private Vector3 velocity;
    public Transform bullet;
    public Transform ExposionEffect;


    void Start()
    {
        velocity = transform.forward * speed;
        bullet.gameObject.SetActive(true);
        Destroy(gameObject, DestroyTime);
    }


    void FixedUpdate()
    {
        transform.position += velocity * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.name);
        if (collision.collider.gameObject != this && collision.collider.gameObject.name != "Cube")
        {
            bullet.gameObject.SetActive(false);
            CreateEffect();
            Destroy(this.gameObject, 1f);
        }
       
       
    }

    void CreateEffect()
    {
        GameObject effect = (GameObject)GameObject.Instantiate(ExposionEffect.gameObject,this.transform.position,Quaternion.identity);
        effect.gameObject.SetActive(true);
    }
}
