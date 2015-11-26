using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugFPS : MonoBehaviour {

    [SerializeField]
    GameObject DebugPanel;
    //[SerializeField]
    //[Range(.2f,1f)]
    //float RefreshRate;
    //float Acc = 0;
    //int Frames = 0;
    //float F = 0;
    [SerializeField]int Rate = 1;
    int R = 0;
    Text T;
	void Start () {
        T = DebugPanel.transform.GetChild(0).GetComponent<Text>();
        //InvokeRepeating("FPS",2,RefreshRate);
	}
    void Update()
    {
        if(R == Rate){
            T.text = (1f/Time.deltaTime).ToString();
            R = 0;
        }
        R++;
        //F += (Time.deltaTime - F) * 0.1f;
        //float FPS = 1f / F;
        //T.text = FPS.ToString();
        //Acc += Time.timeScale / Time.deltaTime;
        //++Frames;
    }
    void FPS()
    {
        //if (DebugPanel.activeSelf)
        //{
        //    float TempFPS = Acc / Frames;
        //    string StringFPS = TempFPS.ToString("F" + Mathf.Clamp(1,0,10));
        //    T.text = "FPS: " + StringFPS;
        //    Acc = 0;
        //    Frames = 0;
        //}
    }
}
