# SPACE SURVIVAL
## 유니티 프로젝트
갤러그와 뱀파이어 서바이벌을 합쳐서 만든 유니티 게임 프로젝트 입니다.
유니티 외에는 Xampp 를 이용한 phpMyAdmin 을 사용해 간단한 로그인을 구현하고
플레이어의 스탯을 JSON 형태로 SQL 서버에 저장하고 불러오는데 사용했습니다.

## 싱글톤 구조
다른 클래스나 오브젝트 스크립트에 있는 변수와 함수를 사용하기 위해서 싱글톤 방식의 Manager 를 많이 사용했습니다.

### GameManager
게임의 시간을 조정하는 역할과 게임 진행과 관련된 변수를 저장하는 용도로 사용했습니다. 
(플레이어의 죽음 여부, 적 격파 횟수, 소지 게임재화 등)

### UIManager
여러 UI 패널 및 이미지를 GameObject 로 접근할 수 있게 해주며 UI 팝업과 세팅에 필요한 함수를 포함하고 있습니다.

#### UI 에 지정된 스킬의 정보를 채워넣는 함수

레벨업하면서 팝업되는 스킬선택 UI 에 스킬 3개가 랜덤으로 들어오기 때문에
랜덤으로 숫자를 뽑아주는 GetRandomNum 함수를 따로 만들어 사용했습니다.

UI 에 표시되는 정보를 채워주는 SetIcon() 함수입니다.
#### SetIcon()
```C#
    public void SetIcon()
    {   
        RanNum = GetRandomNum();
        for (int i = 0; i < 3; i++)
        {
            // Firtst, Second, Third 의 내용 채우기
            temp[i].GetChild(0).GetComponent<Image>().sprite = LevelUPUI.GetComponent<LevelUPUI>().Icons[RanNum[i]].GetComponent<Image>().sprite;
            temp[i].GetChild(1).GetComponent<Text>().text = SkillManager.Instance.SkillList[RanNum[i]].SkillName;
            temp[i].GetChild(2).GetComponent<Text>().text = SkillManager.Instance.SkillList[RanNum[i]].level.ToString();
            temp[i].GetChild(3).GetComponent<Text>().text = SkillManager.Instance.SkillList[RanNum[i]].SkillInfo;
        }
    }
```

#### GetRandomNum()
```C#
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
```

#### 각종 UI 팝업과 관련된 함수
```C#
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
```

### SkillManager
스킬 클래스로 추가한 스킬들을 리스트로 관리하고 스킬의 보유여부, 스킬 아이콘 배치, 쿨타임, 스킬 사용에 필요한 각종 함수를 포함하고 있습니다.

#### skill 클래스를 상속받은 스킬들을 생성해줍니다.
```C#
    public List<Skill> SkillList = new List<Skill>();                              // 스킬 관리 (UIManager.cs, LevelUPUI.cs, SkillManager.cs, Skill000.cs 등의 스크립트와 연관)
    Skill001 S1 = new Skill001();
    Skill002 S2 = new Skill002();
    Skill003 S3 = new Skill003();
    Skill004 S4 = new Skill004();
```

#### skill 클래스 리스트에 스킬을 추가하며 스킬 정보를 초기화 시켜주는 함수입니다.
```C#
    public void InitSkill()
    {
        SkillList.Add(S1);
        S1.SetStatus();
        SkillList.Add(S2);
        S2.SetStatus();
        SkillList.Add(S3);
        S3.SetStatus();
        SkillList.Add(S4);
        S4.SetStatus();
    }
```
#### 현재 보유하고 있는 스킬의 아이콘을 유니티 Canvas 에 좌표지정으로 배치해주는 함수입니다.
```C#
public void SkillSet()                                                          // InitSkill 과 함께 Player 의 Start 문에서 초기화, UIManager DisLevelUI 에서 레벨업 할때마다 실행됨
    {
        for (int i = 0; i < SkillList.Count; i++)
        {
            if (SkillList[i].level > 0)
            {
                if (SkillList[i].Active == false)
                {
                    StartCoroutine(Fire(SkillList[i]));
                    SkillList[i].Active = true;
                }

                if (Pos_X == 200f)
                {
                    Pos_X = 0f;
                    Pos_Y -= 100f;
                }

                Vector2 temp = new Vector2(Pos_X, Pos_Y);
                if (SkillIcons[i].activeSelf == false)
                {
                    SkillIcons[i].GetComponent<RectTransform>().anchoredPosition = temp;
                    SkillIcons[i].SetActive(true);
                    Pos_X += 100f;
                }
            }
        }
    }
```

#### 스킬 쿨타임과 관련된 함수들입니다. 

쿨타임은 코루틴과 Time.deltaTime 을 이용한 방식으로 작성했습니다.
```C#
public void DisSkillCool(Skill skill)                           // 쿨타임
    {
        foreach (GameObject Obj in SkillIcons)
        {
            if (Obj.name == skill.SkillName)
            {
                StartCoroutine(coolTime(Obj.transform.GetChild(0).gameObject, Obj.transform.GetChild(1).gameObject, skill.coolTime, skill.coolTime));
            }
        }
    }

    IEnumerator coolTime(GameObject filter, GameObject Text, float cool, float maxcool)
    {
        if (cool == 0f)
        {
            Text.GetComponent<TextMeshProUGUI>().text = "";
            filter.GetComponent<Image>().fillAmount = 0;
        }
        while (cool > 0)
        {
            cool -= Time.deltaTime;
            Text.GetComponent<TextMeshProUGUI>().text = cool.ToString("F1") + "s";
            filter.GetComponent<Image>().fillAmount = (cool / maxcool);
            yield return new WaitForFixedUpdate();
        }
    }
```
### ObjectManager
각종 프리팹에 쉽게 접근하기 위한 오브젝트 매니저입니다.

### EnemySpawnManager
적의 최대수와 현재 수, 생성 위치지정 등 적 생성에 필요한 기능을 모아둔 매니저 입니다.

#### 보스는 SetActive 를 일반적은 Instantiate 를 사용해 게임에 등장합니다.
```C#
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
```

#### 원의 방정식을 이용해 적의 생성위치를 정하는 함수입니다.
```C#
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
```
