using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Vector2 MousePos;
    Vector2 Pos;
    Vector2 dir;
    Vector2 target;
    Camera  cam;

    // Start is called before the first frame update
    void Start()
    {
        Pos = transform.position;
        target = GameObject.FindWithTag("Enemy").transform.position;
        cam = Camera.main;
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Destroy(gameObject, 5);
        if (gameObject.name == "Missile1(Clone)")
        {
            dir = MousePos - Pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Enemy").transform.position;
        }

        if (gameObject.name == "Missile2(Clone)")
        {
            Pos = transform.position;
            target = GameObject.FindWithTag("Enemy").transform.position;
            dir = (target - Pos);
        }
        transform.Translate(dir.normalized * 15 * Time.deltaTime);
    }
}
