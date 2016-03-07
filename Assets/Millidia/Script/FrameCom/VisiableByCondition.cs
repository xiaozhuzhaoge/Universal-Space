using UnityEngine;
using System.Collections;

public class VisiableByCondition : MonoBehaviour {

    public BoolAction Condition;

    void Update (){
        if(Condition != null){
            foreach (var ren in GetComponentsInChildren<Renderer>(true))
            {
                ren.enabled = Condition ();
            }  
        }
    }
}
