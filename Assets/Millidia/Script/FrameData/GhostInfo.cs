using UnityEngine;
using System.Collections;
using System;

public class GhostInfo:IBattleInfo
{
	public MonsterConfig monsterTemplate;

	public int id;
	public int curBlood;
	int maxArmor;
	int curMaxArmor;
	int curArmor;
	int armorSpeedPer;
	int armorSpeedVal;

	public event Action OnProChange;

	public GhostInfo (MonsterConfig config, int level, int HP, int curArmor, int curMaxArmor)
	{
		monsterTemplate = config;
		id = config.id;
		curBlood = HP;   
		this.curArmor = curArmor;
		this.curMaxArmor = curMaxArmor;
	}

    #region IBattleInfo implementation
	public CharacterType CharacterType {
		get {
			return CharacterType.Ghost;
		}
		set {

		}
	}

	#region IBattleInfo implementation

	public bool IsDead {
		get {
			return CurHP <= 0;
		}
	}

	#endregion

	public int CurHP {
		get {
			return curBlood;
		}
		set {
			curBlood = value;
			if (OnProChange != null) {
				OnProChange ();
			}
		}
	}

	int maxHP;

	public int MaxHP {
		get {
			return maxHP;
		}
		set {
			maxHP = value;
			if (OnProChange != null) {
				OnProChange ();
			}
		}
	}

	public bool Armored {
		get {
			//throw new System.NotImplementedException ();
			return !IsArmorRecorying && CurArmor != 0;
		}
	}

	public int CurArmor {
		get {
			return curArmor;
		}
		set {
			curArmor = value;
			if (OnProChange != null) {
				OnProChange ();
			}
		}
	}


	public int CurMaxArmor {
		get {
			return curMaxArmor;
		}
		set {
			curMaxArmor = Mathf.Min (value, MaxArmor);
			if (OnProChange != null) {
				OnProChange ();
			}
		}
	}

	public int MaxArmor {
		get {
			return maxArmor;
		}
		set {
			maxArmor = value;
			if (OnProChange != null) {
				OnProChange ();
			}
		}
	}

	public float ArmorSpeed { 
		get{
			return MaxArmor * (ArmorSpeedPer / 10000f) + ArmorSpeedVal;
		} 
	}

	public int ArmorSpeedPer {
		get {
			return armorSpeedPer;
		}
		set {
			armorSpeedPer = value;
		}
	}

	public int ArmorSpeedVal {
		get {
			return armorSpeedVal;
		}
		set {
			armorSpeedVal = value;
		}
	}

	bool isArmorRecorying = false;

	public bool IsArmorRecorying {
		get {
			return isArmorRecorying;
		}
		set {
			isArmorRecorying = value;
		}
	}


    #endregion

}
