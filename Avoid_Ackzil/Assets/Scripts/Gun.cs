using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    Player player;
    public float speed;
    float angle;
    Vector2 gunPos;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        gunPos = player.transform.position - transform.position;
        angle = Mathf.LerpAngle(transform.rotation.eulerAngles.z, Mathf.Atan2(gunPos.y, gunPos.x) * Mathf.Rad2Deg + 207, 0.01f);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos((angle - 207) * Mathf.Deg2Rad), Mathf.Sin((angle - 207) * Mathf.Deg2Rad)) * speed;
    }
}
