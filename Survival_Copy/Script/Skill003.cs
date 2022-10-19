using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill003 : Skill
{
    public GameObject SkillIcon;

    public override void SetStatus()
    {
        SkillName = "Skill003";
        Active = false;
        atk = 10;
        level = 0;
        coolTime = 5f;
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
