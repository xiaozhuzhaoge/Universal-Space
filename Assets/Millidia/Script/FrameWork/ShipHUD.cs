using UnityEngine;
using System.Collections;

public class ShipHUD : MonoBehaviour {

    public static ShipHUD instance;
    public UISprite HPs;
    public UISprite SPs;
    public UILabel HpLabel;
    public UILabel SpLabel;

    public int startHP = 500;
    public int startSP = 3000;
    int hp;
    int sp;
    public delegate void OnHpChanged();
    public delegate void OnSpChanged();
    public OnHpChanged HpChange;
    public OnSpChanged SpChange;

    public delegate void OnDie();
    public OnDie Die;
    public delegate void OnPowerLow();
    public OnPowerLow Powerlow;

    public int HP
    {
        set {
            if (value != hp)
                HpChange();
            hp = value;
            if (HP <= 0)
            {
                hp = 0;
                Die();
            }
          
        }
        get { return hp; }
    }

    public int SP
    {
        set
        {
            if (value != sp)
                SpChange();
            if (sp <= 0)
            {
                Powerlow();
            }
            sp = value;
            
        }
        get
        {
            return sp;
        }
    }


    public int IncreaseSpeed = 40;


    void Awake()
    {
        instance = this;
        HpChange += SetHp;
        SpChange += SetSp;
        Powerlow += LowerPower;
    }
	// Use this for initialization
	void Start () {
    
        HP = startHP;
        SP = startSP;
        Die += TryNavMeshAgent.instance.Dead;
        SetHp();
        SetSp();
	}
	
	// Update is called once per frame
	void Update () {
        IncreaseSP();
        DrawBound();
	}

    public void OnHit(int hitPoint)
    {
        if (TryNavMeshAgent.instance.ShellFlag)
        {
            SP -= hitPoint * 25;
            return;
        }
        HP -= hitPoint;
    }

    public void ActiveShell()
    {
        TryNavMeshAgent.instance.ActiveShell();
    }

    void IncreaseSP()
    {
        if (SP >= startSP)
            return;
        if (!TryNavMeshAgent.instance.ShellFlag)
            SP += 1;
    }

  

    void SetHp()
    {
        HPs.fillAmount = (float)HP / (float)startHP;
        HpLabel.text = HP.ToString();
    }

    void SetSp()
    {
        SPs.fillAmount = (float)SP / (float)startSP;
        SpLabel.text = SP.ToString();
    }

    void LowerPower()
    {
        SpLabel.text = "0";
        TryNavMeshAgent.instance.ShellFlag = true;
        TryNavMeshAgent.instance.ActiveShell();
    }

    void DrawBound()
    {
       
    }
}
