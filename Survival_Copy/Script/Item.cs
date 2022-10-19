using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    GameObject Player;

    Vector3 dir;
    Transform Target;
    Transform CurPos;
    float magDist = 5f;
    float dist;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        CurPos = gameObject.transform;
        Target = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CurPos = gameObject.transform;
        Target = Player.transform;
        dist = Vector3.Distance(CurPos.position, Target.position);
        dir = Target.position - CurPos.position;
        if (dist < magDist)
        {
            transform.Translate(dir.normalized * 8 * Time.deltaTime);
        }
    }
}
