using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Missile1;
    public GameObject Missile2;

    private static ObjectManager instance = null;
    void Awake()
    {
        if (null == instance)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
    public static ObjectManager Instance
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

    public GameObject InstObj(GameObject Obj)
    {
        return Instantiate(Obj);
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
