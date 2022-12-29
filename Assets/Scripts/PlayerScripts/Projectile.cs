using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float life = 3f;
    public GameObject onHitVFX;

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Debug.Log(collision.gameObject);
            Instantiate(onHitVFX, this.transform.position, this.transform.rotation);
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }
}
