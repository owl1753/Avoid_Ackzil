using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindShooter : MonoBehaviour
{
    public GameObject windPrefab;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        int r = Random.Range(-8, 8);
        Instantiate(windPrefab, new Vector2(transform.position.x + r, transform.position.y), transform.rotation).GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(Vector2.zero, Vector2.up * speed, 0.05f);
    }
}
