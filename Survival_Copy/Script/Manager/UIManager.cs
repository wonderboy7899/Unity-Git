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
    public GameObject BossHealth;
    public GameObject Clear_Panel;
    public Text EnemyKillCnt;
    public Text BossName;
    public Image HealthBar;
    public Text HealthBarText;
    public Slider ExpBar;
    public Text PlayTime;

    public List<Transform> Icons;
    public List<int> RanNum;
    public Transform[] temp;                                                // ��ų������, �̸�, ����, ����

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

    public void SetIcon()
    {   
        RanNum = UIManager.Instance.GetRandomNum();
        for (int i = 0; i < 3; i++)
        {
            // Firtst, Second, Third �� ���� ä���
            temp[i].GetChild(0).GetComponent<Image>().sprite = LevelUPUI.GetComponent<LevelUPUI>().Icons[RanNum[i]].GetComponent<Image>().sprite;
            temp[i].GetChild(1).GetComponent<Text>().text = SkillManager.Instance.SkillList[RanNum[i]].SkillName;
            temp[i].GetChild(2).GetComponent<Text>().text = SkillManager.Instance.SkillList[RanNum[i]].level.ToString();
            temp[i].GetChild(3).GetComponent<Text>().text = SkillManager.Instance.SkillList[RanNum[i]].SkillInfo;
        }
    }

    public void DisLevelUI()
    {
        LevelUPUI.SetActive(true);
        GameManager.Instance.GamePause();
        SetIcon();
    }

    public void DesLevelUI()
    {
        LevelUPUI.SetActive(false);
        GameManager.Instance.GameResume();
        SkillManager.Instance.SkillSet();
    }

    public void GameEnd()
    {
        ObjectManager.Instance.RedField.SetActive(false);
        BossHealth.SetActive(false);
        Clear_Panel.SetActive(true);
        GameManager.Instance.GamePause();
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
