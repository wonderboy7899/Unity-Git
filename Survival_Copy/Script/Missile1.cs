using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile1 : MonoBehaviour
{
    int atk;
    GameObject ColObj;
    Vector2 dir;
    Vector2 target;

    private void OnTriggerEnter2D(Collider2D col)
    {
        ColObj = col.gameObject;
        var ObjScript = ColObj.GetComponent<Enemy>();

        if (ColObj.tag == "Enemy")
        {
            Destroy(gameObject);
            ObjScript.Status.NowHP -= atk;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        atk = SkillManager.Instance.SkillList[0].atk;

        Destroy(gameObject, 5);
        dir = new Vector2(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Enemy").transform.position;
        }

        transform.Translate(dir.normalized * 7 * Time.deltaTime);
    }
}
