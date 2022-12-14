using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile1 : MonoBehaviour
{
    int level;
    int atk;
    GameObject ColObj;
    Vector2 dir;
    Vector2 target;

    private void OnTriggerEnter2D(Collider2D col)
    {
        ColObj = col.gameObject;

        if (ColObj.tag == "Enemy")
        {
            var ObjScript = ColObj.GetComponent<Enemy>();
            Destroy(gameObject);
            ObjScript.Status.NowHP -= atk;
        }
        else if (ColObj.tag == "Boss")
        {
            var ObjScript = ColObj.GetComponent<Boss1>();
            Destroy(gameObject);
            ObjScript.Status.NowHP -= atk;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        level = SkillManager.Instance.SkillList[0].atk; 
        atk = SkillManager.Instance.SkillList[0].atk;

        Destroy(gameObject, 10);
        dir = new Vector2(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir.normalized * 7 * Time.deltaTime);
    }

    IEnumerator Explosive()
    {
        yield return new WaitForSeconds(2f);

    }
}
