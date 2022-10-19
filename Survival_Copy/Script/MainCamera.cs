using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    public float cameraSpeed = 5.0f;
    Vector3 target;
    Vector3 tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform.position;
        this.transform.position = target + tr;
        /* 서서히 움직이는 카메라
        Vector3 dir = player.transform.position - this.transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, dir.y * cameraSpeed * Time.deltaTime, 0);
        this.transform.Translate(moveVector);
         */
    }
}
