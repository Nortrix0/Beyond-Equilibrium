using UnityEngine;
using System.Collections;

public class OpenDrawer : MonoBehaviour
{
    public GameObject[] Drawers;
    bool TopIsOpen;
    bool MidIsOpen;
    bool BottomIsOpen;
    void Update()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(Settings.CS.Keys[0].Key) && Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5f))
        {
            foreach (GameObject go in Drawers)
            {
                if (hit.collider.gameObject == go)
                {
                    StopCoroutine("Lerp");
                    if (go.name == "Top_Model" || go.name == "Top")
                    {
                        if (go.transform.parent.GetChild(0).FindChild("AmmoBox"))
                        {
                            go.transform.parent.GetChild(0).GetChild(1).gameObject.SetActive(!TopIsOpen);
                        }
                        TopIsOpen = !TopIsOpen;
                        StartCoroutine(Lerp(go.transform.parent.GetChild(0), TopIsOpen));
                        Debug.Log("Top " + TopIsOpen);
                    }
                    if (go.name == "Mid_Model" || go.name == "Mid")
                    {
                        if (go.transform.parent.GetChild(1).FindChild("AmmoBox"))
                        {
                            go.transform.parent.GetChild(1).GetChild(1).gameObject.SetActive(!MidIsOpen);
                        }
                        MidIsOpen = !MidIsOpen;
                        StartCoroutine(Lerp(go.transform.parent.GetChild(1), MidIsOpen));
                        Debug.Log("Mid " + MidIsOpen);
                    }
                    if (go.name == "Bottom_Model" || go.name == "Bottom")
                    {
                        if (go.transform.parent.GetChild(2).FindChild("AmmoBox"))
                        {
                            go.transform.parent.GetChild(2).GetChild(1).gameObject.SetActive(!BottomIsOpen);
                        }
                        BottomIsOpen = !BottomIsOpen;
                        StartCoroutine(Lerp(go.transform.parent.GetChild(2), BottomIsOpen));
                        Debug.Log("Bottom " + BottomIsOpen);
                    }
                }
            }

        }
    }
    IEnumerator Lerp(Transform T, bool b)
    {
        float Distance = 0;
        float Timefloat = 5f;
        bool Running = true;
        Vector3 Temp = T.position;
        Vector3 Curr = T.position;
        if (b)
        {
            Temp.z = Curr.z - .4f;
        }
        else
        {
            Temp.z = Curr.z + .4f;
        }
        while (Running)
        {
            if(Distance < 1){
                Distance += Timefloat * Time.deltaTime;
                T.position = Vector3.Lerp(Curr, Temp, Distance);
            }
            else
            {
                Running = false;
            }
            yield return new WaitForSeconds(.001f);
        }
    }
}
