using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill002 : Skill
{
    public override void SetStatus()
    {
        SkillName = "Skill002";
        Active = false;
        atk = 10;
        level = 0;
        coolTime = 1.5f;
    }

    public override void ActiveSkill()
    {
        int Max = level * 3;
        for (int x = 0; x < Max; x++)
        {
            Instantiate(ObjectManager.Instance.Missile2, SkillManager.Instance.GetRanPos(ObjectManager.Instance.Player), Quaternion.identity).transform.parent = null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
