using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    private static EnemySpawnManager instance = null;

    public GameObject BossSpawnPoint;

    public int MaxEnemy;
    public int CurEnemy = 0;

    Vector3 target;
    Vector3 randomPosition;

    float radius = 20f;

    public bool PlayerDied = false;
    void Awake()
    {
        if (null == instance)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
    public static EnemySpawnManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public int SetMaxEnemySpawn(float TimeCur)
    {
        if (TimeCur < 10)
        {
            return 10;
        }
        else if (10 <= TimeCur && TimeCur < 60)
        {
            return 20;
        }
        else if (60 <= TimeCur && TimeCur < 180)
        {
            return 50;
        }
        else if (180 <= TimeCur && TimeCur < 300)
        {
            return 100;
        }
        else
            return 200;
    }

    public void SpawnBoss(GameObject Boss)
    {
        Transform Player = ObjectManager.Instance.Player.transform;
        Boss.SetActive(true);
        //Boss.transform.Translate(new Vector3(0, 0, 0));
        Boss.transform.position = (GetRandomPosition(radius + 10f));
    }

    public void EnemySpawn(GameObject Enemy)
    {
        if (EnemySpawnManager.Instance.CurEnemy < EnemySpawnManager.Instance.MaxEnemy)
        {
            Instantiate(Enemy, GetRandomPosition(radius), Quaternion.identity).transform.SetParent(ObjectManager.Instance.Clone.transform);
            EnemySpawnManager.Instance.CurEnemy += 1;
        }
    }

    public Vector3 GetRandomPosition(float radius)
    {
        float a = ObjectManager.Instance.Player.transform.position.x;
        float b = ObjectManager.Instance.Player.transform.position.y;

        float x = Random.Range(-radius + a, radius + a);
        float y_b = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(x - a, 2));
        y_b *= Random.Range(0, 2) == 0 ? -1 : 1;
        float y = y_b + b;
        Vector3 randomPosition = new Vector3(x, y, 0);

        return randomPosition;
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
