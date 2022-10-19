using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    private static EnemySpawnManager instance = null;

    public int MaxEnemy;
    public int CurEnemy = 0;

    public bool PlayerDied = false;
    void Awake()
    {
        if (null == instance)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
