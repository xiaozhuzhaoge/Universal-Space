using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class UITextureAtlas : MonoBehaviour {

    public string folderName;
    public string TextureName;
   
    public UITexture Texture;
    public List<Texture2D> texture = new List<Texture2D>();
 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Awake()
    {
       
    }

    [ContextMenu("Test")]
    void ReadAllTexture()
    {
        texture.Clear();
        Resources.LoadAll<Texture2D>("GUI/" + folderName).ToList<Texture2D>().ForEach(picture =>
        {
            texture.Add((Texture2D)picture);
        });
    }


    public void SetTexture(string name)
    {
       if (Texture == null)
          Texture = this.GetComponent<UITexture>();
       TextureName = name;
       if(texture.Count <= 0)
           return;

       texture.ForEach(tex =>
       {
          if(tex.name == TextureName)
          {
              Texture.mainTexture = tex;
              return;
          }
       });
    }

}
