using UnityEngine;
using System.Collections;
[SerializeField]
public class GameSettings : ScriptableObject {
    public int Difficulty;
    public bool InvertX;
    public bool InvertY;
    public bool Subtitles;
    public bool Gore;
    public bool KeepBodies;
    public bool HoldADS;
    public float MusicVol;
    public float DialougeVol;
    public float SFXVol;
}
