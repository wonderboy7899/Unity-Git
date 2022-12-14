using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    public UnitCode unitcode;
    public Status Status;
    public GameObject Intercepter;
    public GameObject SpawnPT;
    public GameObject TurretM1;
    public GameObject TurretM2;
    public GameObject TurretS1;
    public GameObject TurretS2;
    public GameObject SoundObject;
    public float angle;
    GameObject Player;
    Slider BossHP;
    float speed = 0.1f;
    float dist = 0f;
    float turnspeed = 0.1f;
    Vector3 target;
    Vector3 Pos;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        Status = new Status();
        Status = Status.SetUnitStatus(unitcode);
        Player = ObjectManager.Instance.Player;
        StartCoroutine(Scramble());
    }

    // Update is called once per frame
    void Update()
    {
        UIManager.Instance.BossHealth.GetComponent<Slider>().value = (float)(Status.NowHP / Status.MaxHP);
        dist = Vector3.Distance(Player.transform.position, transform.position);

        if (Status.NowHP <= 0)
        {
            GameObject sound = Instantiate(SoundObject);
            Destroy(sound, 10f);
            Vector3 temp = new Vector3(transform.position.x + 11.8f, transform.position.y + 8.6f, 0);
            Instantiate(EffectManager.Instance.Big_EX, temp, Quaternion.identity);
            Destroy(gameObject);
        }
        MoveTo();
    }

    // 보스패턴 만들기
    public void MoveTo()
    {   
        Pos = transform.position;

        if (Player != null)
        {
            target = Player.transform.position;
        }

        dir = target - Pos;
        transform.position += dir * speed * Time.deltaTime;

        if (dist < 20f && speed >= 0)
        {
            speed -= (0.05f * Time.deltaTime);

            if (speed < 0f)
            {
                speed = 0f;
            }
        }
        
        angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle + 90, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, angleAxis, turnspeed * Time.deltaTime);
    }

    IEnumerator Scramble()
    {
        Instantiate(Intercepter, SpawnPT.transform).transform.SetParent(ObjectManager.Instance.Clone.transform);
        yield return new WaitForSeconds(1f);
    }
}
