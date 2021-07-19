using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
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

    void OnTriggerEnter2D(Collider2D cd)
    {
        if (cd.CompareTag("Player"))
        {
            if (player.transform.position.x < -8.61f)
            {
                player.transform.position = new Vector2(-8.61f, player.transform.position.y);
            }
            if (player.transform.position.x > 8.61f)
            {
                player.transform.position = new Vector2(8.61f, player.transform.position.y);
            }
        }
    }
    void OnTriggerStay2D(Collider2D cd)
    {
        if (cd.CompareTag("Player"))
        {
            if (player.transform.position.x < -8.61f)
            {
                player.transform.position = new Vector2(-8.61f, player.transform.position.y);
            }
            if (player.transform.position.x > 8.61f)
            {
                player.transform.position = new Vector2(8.61f, player.transform.position.y);
            }
        }
    }
}
