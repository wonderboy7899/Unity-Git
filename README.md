# SPACE SURVIVAL
## 유니티 게임 프로젝트
***
<P>
<img src = "https://user-images.githubusercontent.com/67588694/207830424-1b12ae52-c116-4ed3-8f08-e1c6768fc226.gif">
</P>

<P>
<img src = "https://user-images.githubusercontent.com/67588694/207830503-711c2d3d-e889-4c6c-bbad-1b9ee4a85c1a.gif">
</P>

***

- 사용 프로그램 : 유니티, Xampp(phpMyAdmin)<br/>
- 제작기간 : 3개월<br/>
- 모티브 : 갤러그 + 뱀파이어 서바이벌<br/>
- 동영상 링크 : [https://playground942.tistory.com/2]

## 조작법
-W, A, S, D 를 이용해 상하좌우로 이동할 수 있고<br/>
-플레이어가 레벨업했을 때 표시되는 스킬선택 UI 에서 스킬을 고르면 됩니다.<br/>
<br/>
기본적인 공격은 자동조준으로 이루어집니다.

## 진행방식
화면 가운데에 위치한 플레이어 우주선을 움직이며 적의 공격을 피해 최대한 많은 적을 격파하고<br/>
얻은 스킬을 조합해 보스를 격파하며 스테이지를 클리어하는 방식입니다.<br/>
<br/>

## 싱글톤
게임을 만들며 객체와 객체 간에 상호작용을 구현하기 위해<br/>
다른 객체의 변수, 함수 등 접근할 일이 매우 많았고<br/>
이 모든 과정을 GetComponent<>() 를 이용해 스크립트를 불러오는 방법을 사용했었습니다.<br/>
<br/>
싱글톤을 새롭게 배우면서 다른 객체의 변수, 함수에 접근하는 것은 매우 쉬워졌지만<br/>
이 싱글톤 스크립트를 역할에 따라 기능에 따라 분류하고 정리하는 방법에 대해 고민을 많이 해보게 되었습니다.<br/>
아직도 많이 부족하고 더 연습해야 할 많은 부분중에 하나라고 생각합니다.<br/>

## 플레이어와 오브젝트의 이동
게임 제작 후반부에 transform.translate 를 이용하는게 아닌 RigidBody, Velocity 를 사용하는 이동 방법에 대해 배우고<br/>
두 방식의 차이점과 Velocity 를 사용한 이동의 장점에 대해 공부하는 계기가 되었습니다.<br/>
다음 프로젝트에서는 Velocity 를 이용해서 만들어볼 계획입니다. (게임과 부합하다면)<br/>

## 스킬
싱글톤을 배우게 된 계기가 되었던 파트입니다.<br/>
스킬 클래스를 생성, 이를 상속받는 스킬들을 여러개 만들고<br/>
이를 스킬 클래스 자료형의 리스트에 담아 관리하는 방식을 사용했습니다.<br/>
스킬의 이름, 레벨, 효과, 쿨타임 등의 정보를 이 리스트에서 받아와 사용합니다.<br/>
<br/>
***

## Skill.cs
``` C#
public class Skill : MonoBehaviour
{
    public string           SkillName;
    public string           SkillInfo;
    public bool             Active;
    public int              atk;
    public int              level;
    public float            coolTime;

    public virtual void SetStatus()
    {

    }

    public virtual void ActiveSkill()
    {

    }
}
```
*** 

## SkillManager.cs
``` C#
public class SkillManager : MonoBehaviour
{
    private static SkillManager instance = null;

    public List<Skill> SkillList = new List<Skill>();
    Skill001 S1 = new Skill001();
    Skill002 S2 = new Skill002();
    Skill003 S3 = new Skill003();
    Skill004 S4 = new Skill004();

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
}
```

***
## 느낀점
스킬의 각종 정보(쿨타임, 아이콘, 보유여부) 등의 정보를 플레이어에게 전달하는 기능을 구현하는 부분이 깔끔하지 못해 아쉽습니다.<br/>
스크립트를 보기 쉽게 정리하는 것과 게임을 플레이하는 유저에게 정보를 쉽게 전달하도록 만드는게 힘들었습니다.<br/>
<br/>
유니티 스크립트와 php 를 이용해 SQL 서버 데이터베이스를 수정해보며 로그인 기능을 만들어본 경험도 새롭고 신기했고<br/>
Json 형태의 파일을 사용하는것을 좀 더 연습할 계획입니다.<br/>
<br/>
생각보다 여러가지 이펙트나 사운드를 틀어주는 등 신경쓸것이 많았는데 하나하나 만들다보니<br/>
애착도 생기고 재밌게 할 수 있었던 것 같습니다.<br/>
<br/>
