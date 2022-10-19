using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile2 : MonoBehaviour
{
    public GameObject SkillIcon;
    public GameObject[] EnemyList;
    public GameObject Enemy;

    GameObject ColObj;
    GameObject Target;

    int atk;

    Rigidbody2D RB;

    Vector2 Pos;
    Vector3 dir;
    Vector2 target;

    private void OnTriggerEnter2D(Collider2D col)
    {
        ColObj = col.gameObject;
        var ObjScript = ColObj.GetComponent<Enemy>();

        //Script = ColObj.GetComponent<Enemy>();
        if (ColObj.tag == "Enemy")
        {
            Destroy(gameObject);
            ObjScript.Status.NowHP -= atk;
            //sound.PlayOneShot(sound.clip); 사운드 재생
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        atk = SkillManager.Instance.SkillList[1].atk;
        EnemyList = GameObject.FindGameObjectsWithTag("Enemy");
        int i = Random.Range(0, EnemyList.Length - 1);
        if (EnemyList.Length != 0)
        {
            Target = EnemyList[i];
            target = Target.transform.position;
        }
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            target = Target.transform.position;
        }
        Pos = transform.position;
        dir = (target - Pos);
        //transform.position += dir * 2 * Time.deltaTime;
        transform.Translate(dir.normalized * 10 * Time.deltaTime);
    }
}
