using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public GameObject obstaclePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drop()
    {
        int r = Random.Range(-8, 8);
        Instantiate(obstaclePrefab, new Vector2(transform.position.x + r, transform.position.y), transform.rotation).GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
