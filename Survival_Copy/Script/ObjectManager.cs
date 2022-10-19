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

    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.
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
