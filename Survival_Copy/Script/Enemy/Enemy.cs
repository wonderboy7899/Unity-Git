using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public UnitCode unitcode;
    public Status Status;
    public GameObject[] ItemList = new GameObject[5];
    GameObject Player;
    GameObject Missile;
    float speed = 0.2f;
    float dist = 0f;

    public bool Aimed = false;
    Vector3 target;
    Vector3 Pos;
    Vector3 dir;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && Player != null)
        {
            col.gameObject.GetComponent<Player>().Status.NowHP -= 5;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Status = new Status();
        Status = Status.SetUnitStatus(unitcode);
        StartCoroutine(Shot());
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(Player.transform.position, transform.position);

        ItemDrop();

        MoveTo();
    }

    public void MoveTo()
    {
        Pos = transform.position;

        if (Player != null)
        {
            target = Player.transform.position;
        }

        dir = target - Pos;
        transform.position += dir * speed * Time.deltaTime;

        if (dist < 10f && speed >= 0)
        {
            speed -= (0.05f * Time.deltaTime);

            if (speed < 0f)
            {
                speed = 0f;
            }
        }

        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
    }

    public void ItemDrop()
    {
        if (Status.NowHP <= 0)
        {
            GameManager.Instance.Killcnt += 1;
            UIManager.Instance.EnemyKillCnt.text = "Enemy Kill Count : " + GameManager.Instance.Killcnt.ToString();
            Vector3 temp = new Vector3(transform.position.x + 1.2f, transform.position.y + 0.8f, 0);
            Instantiate(EffectManager.Instance.Small_EX, temp, Quaternion.identity);
            int i = Random.Range(1, 10000);
            EnemySpawnManager.Instance.CurEnemy -= 1;
            if (i > 0 && i <= 9900)// Gold
            {
                Instantiate(ItemList[2], gameObject.transform.position, Quaternion.identity).transform.SetParent(ObjectManager.Instance.Clone.transform);       // 임시적으로 Gold 없앰
            }
            else if (i > 9900 && i <= 9950)// RedPotion
            {
                Instantiate(ItemList[1], gameObject.transform.position, Quaternion.identity).transform.SetParent(ObjectManager.Instance.Clone.transform);
            }
            else if (i > 9950 && i <= 9970)// BlueGem
            {
                Instantiate(ItemList[2], gameObject.transform.position, Quaternion.identity).transform.SetParent(ObjectManager.Instance.Clone.transform);
            }
            else if (i > 9970 && i <= 9990)// BlackGem
            {
                Instantiate(ItemList[3], gameObject.transform.position, Quaternion.identity).transform.SetParent(ObjectManager.Instance.Clone.transform);
            }
            else if (i > 9990 && i <= 10000)// Chest
            {
                Instantiate(ItemList[4], gameObject.transform.position, Quaternion.identity).transform.SetParent(ObjectManager.Instance.Clone.transform);
            }
            Destroy(gameObject);
        }
    }

    IEnumerator Shot()
    {
        yield return new WaitForSeconds(3f);

        Missile = Instantiate(ObjectManager.Instance.EnemyMissile, gameObject.transform);
        Missile.transform.SetParent(ObjectManager.Instance.Clone.transform);

        if (GameManager.Instance.PlayerDied == true)                // 플레이어 사망시
        {
            StopCoroutine(Shot());
        }
        else
        {
            StartCoroutine(Shot());
        }
    }
}
