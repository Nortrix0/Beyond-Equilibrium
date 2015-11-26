using UnityEngine;
using System.Collections;

public class FlashlightTextureChange : MonoBehaviour {
    public Texture[] States;
    int StateInt;
    float FlashlightAmount;
	
	void Update () {
        FlashlightAmount = Settings.Stats.FlashlightAmount;
        CheckState();
        transform.GetChild(1).GetChild(1).GetComponent<MeshRenderer>().materials[0].mainTexture = States[StateInt];
	}

    void CheckState()
    {
        if (FlashlightAmount > .8f) StateInt = 0;
        else if (FlashlightAmount > .6f) StateInt = 1;
        else if (FlashlightAmount > .4f) StateInt = 2;
        else if (FlashlightAmount > .2f) StateInt = 3;
        else if (FlashlightAmount < .2f) StateInt = 4;
    }
}
