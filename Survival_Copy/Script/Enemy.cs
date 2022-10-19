using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public UnitCode unitcode;
    public Status Status;
    public GameObject[] ItemList = new GameObject[5];
    GameObject player;
    float speed = 0.2f;

    public bool Aimed = false;
    Vector3 target;
    Vector3 Pos;
    Vector3 dir;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && player != null)
        {
            col.gameObject.GetComponent<Player>().Status.NowHP -= 5;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Status = new Status();
        Status = Status.SetUnitStatus(unitcode);
    }

    // Update is called once per frame
    void Update()
    {
        Pos = transform.position;
        if (Status.NowHP <= 0)
        {
            int i = Random.Range(1, 10000);
            EnemySpawnManager.Instance.CurEnemy -= 1;
            if (i > 0 && i <= 9900)// Gold
            {
                Instantiate(ItemList[2], gameObject.transform.position, Quaternion.identity).transform.parent = null;       // 임시적으로 Gold 없앰
            }
            else if (i > 9900 && i <= 9950)// RedPotion
            {
                Instantiate(ItemList[1], gameObject.transform.position, Quaternion.identity).transform.parent = null;
            }
            else if (i > 9950 && i <= 9970)// BlueGem
            {
                Instantiate(ItemList[2], gameObject.transform.position, Quaternion.identity).transform.parent = null;
            }
            else if (i > 9970 && i <= 9990)// BlackGem
            {
                Instantiate(ItemList[3], gameObject.transform.position, Quaternion.identity).transform.parent = null;
            }
            else if (i > 9990 && i <= 10000)// Chest
            {
                Instantiate(ItemList[4], gameObject.transform.position, Quaternion.identity).transform.parent = null;
            }
            Destroy(gameObject);
        }

        if (player != null)
        {
            target = player.transform.position;
        }
        dir = target - Pos;
        transform.position += dir * speed * Time.deltaTime;

        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
    }
}
