using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMovement : MonoBehaviour
{
    private GameObject obj;
    public float wallFirstPosition;
    public float moveSpeed;

    void Start()
    {
        obj = gameObject;
        wallFirstPosition = 10;
        moveSpeed = 5;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(bgMovement.speed *Time.deltaTime, 0, 0));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Respawn"))
        {
            obj.transform.position = new Vector3(wallFirstPosition, Random.Range(-3,3), 0);
        };
    }
}
