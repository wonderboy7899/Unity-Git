using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;

    public GameObject SkillIcons;
    public GameObject LevelUPUI;
    public GameObject HealthSystem;
    public Image HealthBar;
    public Text HealthBarText;
    public Slider ExpBar;
    public Text PlayTime;

    void Awake()
    {
        if (null == instance)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ. static�̹Ƿ� �ٸ� Ŭ�������� ���� ȣ���� �� �ִ�.
    public static UIManager Instance
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

    public void DisLevelUI()
    {
        LevelUPUI.SetActive(true);
        GameManager.Instance.GamePause();
    }

    public void DesLevelUI()
    {
        LevelUPUI.SetActive(false);
        GameManager.Instance.GameResume();
        SkillManager.Instance.SkillSet();
    }

    public List<int> GetRandomNum()
    {
        int Length = SkillManager.Instance.SkillList.Count;

        List<int> numArray = new List<int>();
        List<int> result = new List<int>();

        for (int i = 0; i < Length; i++)
        {
            numArray.Add(i);                            // 0, 1, 2 ...
        }

        for (int i = 0; i < 3; i++)
        {
            int RanNum = Random.RandomRange(0, numArray.Count);
            result.Add(numArray[RanNum]);
            numArray.RemoveAt(RanNum);
        }
        return result;
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
