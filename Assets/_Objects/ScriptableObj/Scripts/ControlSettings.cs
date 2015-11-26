using UnityEngine;
using System.Collections.Generic;
[SerializeField]
public class ControlSettings : ScriptableObject {
    [SerializeField]
    public List<Controls> Keys = new List<Controls>();
}
[System.Serializable]
public class Controls
{
    public string Name;
    public KeyCode Key;
    public KeyCode Default;
}
