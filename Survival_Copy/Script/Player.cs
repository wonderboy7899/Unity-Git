using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public UnitCode unitcode;

    public DynamicJoystick DynamicJoystick;
    public GameObject Joystick;
    public GameObject Missile1;                                             // 변수 설정
    public GameObject Missile2;
    public Status Status;
    public Rigidbody rb;

    float Speed = 5f;

    int level = 1;
    int Gold = 0;
    float MaxExp = 50;
    float Exp = 0;
    Transform RanPos;
    Vector3 Player_Pos;

    // Start is called before the first frame update
    void Start()
    {
        Status = new Status();                                              // 스테이터스 설정 및 스킬 리스트 추가
        Status = Status.SetUnitStatus(unitcode);
        SkillManager.Instance.InitSkill();
        SkillManager.Instance.SkillSet();
    }

    // Update is called once per frame
    void Update()
    {
        UIManager.Instance.HealthBar.fillAmount = (float)(Status.NowHP / Status.MaxHP);        // 체력바
        UIManager.Instance.ExpBar.value = (float)(Exp / MaxExp);
        UIManager.Instance.HealthBarText.text = Status.NowHP + "/" + Status.MaxHP;

        if (Status.NowHP <= 0)                                              // 플레이어 사망시
        {
            gameObject.SetActive(false);
            GameManager.Instance.PlayerDied = true;
            UIManager.Instance.HealthSystem.SetActive(false);
        }

        if (Exp >= MaxExp)                                                  // 플레이어 레벨업 시
        {
            GameManager.Instance.GamePause();
            UIManager.Instance.DisLevelUI();
            PlayerLevelUP();
        }

        Player_Pos = transform.position;                                    // 플레이어 이동
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
        if (dirX != 0 || dirY != 0)
        {
            Vector3 dirXY = (Vector3.right * dirX) + (Vector3.up * dirY);
            dirXY.Normalize();
            float Keyboard_angle = Mathf.Atan2(dirXY.x, dirXY.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(Keyboard_angle, Vector3.back);
            transform.position += dirXY * Speed * Time.deltaTime;
        }
    }

    void PlayerLevelUP()
    {
        Vector2 Pos = new Vector2(0, 0);
        level += 1;
        MaxExp *= 1.5f;
        Exp = 0;
        Status.NowHP = Status.MaxHP;
    }

    public Vector3 GetRanPos()
    {
        float a = gameObject.transform.position.x;
        float b = gameObject.transform.position.y;

        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);

        Vector3 Init_Pos = new Vector3(a += x, b += y, 0);
        return Init_Pos;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject Item;
        if (col.gameObject.tag == "Item")
        {
            Item = col.gameObject;
            if (Item.name == "Gold(Clone)")
            {
                Destroy(Item);
                Gold += 1;
            }
            else if (Item.name == "RedPotion(Clone)")
            {
                Destroy(Item);
                if ((Status.NowHP += (Status.MaxHP * 0.2)) > Status.MaxHP)
                {
                    Status.NowHP = Status.MaxHP;
                }
            }
            else if (Item.name == "BlueGem(Clone)")
            {
                Exp += 10;
                Destroy(Item);
            }
            else if (Item.name == "BlackGem(Clone)")
            {
                Destroy(Item);
            }
            else if (Item.name == "Chest(Clone)")
            {
                Destroy(Item);
            }
        }
    }
}