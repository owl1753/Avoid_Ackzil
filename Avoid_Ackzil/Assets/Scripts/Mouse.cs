using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float speed;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spit()
    {
        Instantiate(obstaclePrefab, transform.position, transform.rotation).GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position).normalized * speed;
    }
}
