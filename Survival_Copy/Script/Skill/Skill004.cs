using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill004 : Skill
{
    public GameObject SkillIcon;
    GameObject Drone;

    public override void SetStatus()
    {
        SkillName = "오토 드론";
        SkillInfo = "전방위 공격을 하는 드론을 생성합니다.";
        Active = false;
        atk = 10;
        level = 0;
        coolTime = 0f;
    }

    public override void ActiveSkill()
    {
        Drone = ObjectManager.Instance.Drone;
        var DroneScript = Drone.GetComponent<Drone>();
        level = SkillManager.Instance.SkillList[3].level;

        if (level == 1)
            DroneScript.cooltime = 2f;
        else if (level == 2)
            DroneScript.cooltime = 1f;
        else if (level == 3)
            DroneScript.cooltime = 0.5f;

        Drone.SetActive(true);
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
