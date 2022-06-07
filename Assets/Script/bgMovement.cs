using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMovement : MonoBehaviour
{
    private GameObject background;
    private Vector3 firstPosition;
    private double moveRange = 20.5;
    public static float speed;
    // Start is called before the first frame update
    void Start()
    {
        background = gameObject;
        firstPosition = background.transform.position;
        speed = -3;
    }

    // Update is called once per frame
    void Update()
    {
        BgTransform();
    }

    void BgTransform()
    {
        transform.Translate(new Vector3(speed *Time.deltaTime, transform.position.y, 0));
        if (Vector3.Distance(firstPosition, background.transform.position) > moveRange)
        {
            background.transform.position = firstPosition;
        }
    }
}
