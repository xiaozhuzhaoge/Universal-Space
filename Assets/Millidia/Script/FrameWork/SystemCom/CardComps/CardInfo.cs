using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CardInfo : UIEventListener {

    public UITexture texture;
    public UITextureAtlas atlas;
    public UISprite Quality;
    public UITexture Back;
    public List<UISprite> stars;
    public UITable table;
    public UISprite item;
    public UILabel name;
    public UISprite qualityback;
    public CardConfig config;
    public UILabel level;

	// Use this for initialization
	void Start () {
        ResetDepth();
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void ResetDepth()
    {
        Quality.depth = texture.depth + 3;
        Back.depth = texture.depth + 2;
        qualityback.depth = texture.depth + 2;
        stars.ForEach(star => star.depth = texture.depth + 3);
        table.repositionNow = true;
        item.depth = texture.depth + 2;
        name.depth = texture.depth + 3;
    }

    public void SetStars(int num)
    {
        stars.ForEach(star => star.gameObject.SetActive(false));
        for(int i = 0 ; i < num ; i++)
        {
            stars[i].gameObject.SetActive(true);
        }
    }

    public void SetName(string t)
    {
        name.text = t;
    }
    public void SetQuality(int qu)
    {
        Quality.spriteName = GetQuality(qu);
    }

    public void SetLv(int lv)
    {
        level.text = "Lv:"+lv.ToString();
    }

    string GetQuality(int q)
    {
        if(q == 1)
        {
            return "N";
        }
        else if(q == 2)
        {
            return "R";
        }
        else if(q == 3)
        {
            return "SR";
        }
        else if(q == 4)
        {
            return "UR";
        }
        return "UR";
    }

    public void SetCategory(int ca)
    {
        Back.GetComponent<UITextureAtlas>().SetTexture(GetCateGory(ca));
    }
    public string GetCateGory(int ca)
    {
        if(ca == 1)
        {
            return "iron";
        }
        else if (ca == 2)
        {
            return "copper";
        }
        else if (ca == 3)
        {
            return "sliver";
        }
        else if (ca == 4)
        {
            return "gold";
        }
        else if (ca == 5)
        {
            return "fire";
        }
        else if (ca == 6)
        {
            return "ice";
        }
        else if (ca == 7)
        {
            return "nature";
        }
        else if (ca == 8)
        {
            return "holy";
        }
        else if (ca == 9)
        {
            return "dark";
        }
        return "";
    }


    public void ResetA()
    {
        this.GetComponent<TweenAlpha>().enabled = false;
        this.GetComponent<TweenAlpha>().ResetToBeginning();
        this.GetComponent<UIWidget>().alpha = 1f;
    }

    public void SetCardConfigID(int id)
    {
        CardConfig config = ConfigInfo.instance.CARDS[id];
        SetStars(config.Rank);
        SetName(config.CardName);
        SetQuality(config.Quality);
        SetCategory(config.Category);
        SetLv(config.LEVEL);
        transform.GetComponent<UITextureAtlas>().SetTexture(config.ICON);
        this.config = config;
    }
}
