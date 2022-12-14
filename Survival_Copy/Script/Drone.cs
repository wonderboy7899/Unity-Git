using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public float cooltime = 2f;

    int         level = 0;
    float       angle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        if (angle >= 360)
        {
            angle = 0;
        }
    }

    IEnumerator Fire()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(ObjectManager.Instance.Missile1, gameObject.transform.position, Quaternion.Euler(0, 0, angle)).transform.SetParent(ObjectManager.Instance.Clone.transform);
            angle += 36;  // 36 * 10 = 360
        }
        yield return new WaitForSeconds(cooltime);
        StartCoroutine(Fire());
    }
}
