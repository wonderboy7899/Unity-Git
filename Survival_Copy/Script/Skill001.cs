using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill001 : Skill
{
    GameObject ColObj;
    Vector2 Pos;
    Vector2 dir;
    Vector2 target;
    //Camera cam;
    //Vector2 MousePos;

    public override void SetStatus()
    {
        SkillName = "Skill001";
        Active = false;
        atk = 10;
        level = 1;
        coolTime = 1f;
    }

    public override void ActiveSkill()
    {
        int max = level;
        for (int i = 0; i < max; i++)
        {
            /*
            GameObject pref = ObjectManager.Instance.Missile1;
            pref.GetComponent<Skill001>().Init(3,10,10) 3;
            */
            Instantiate(ObjectManager.Instance.Missile1, ObjectManager.Instance.Player.transform).transform.parent = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SkillName = "Skill001";
        atk = 10;
        level = 1;
        coolTime = 1f;

        Destroy(gameObject, 5);
        dir = new Vector2(0, 1);

        /*
        마우스 포인터 방향으로 쏘는 방식
        Pos = transform.position;
        cam = Camera.main;
        target = GameObject.FindWithTag("Enemy").transform.position;
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Destroy(gameObject, 5);
        dir = MousePos - Pos;
         */
    }

    // Update is called once per frame
    void Update()
    {

    }
}
