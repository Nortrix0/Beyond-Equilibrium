using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {
    public GameSettings _GameSettings;
    public ControlSettings _ControlSettings;
    public Stats _Stats;
    public Stats _Checkpoint;
    [SerializeField]
    public static GameSettings GS;
    [SerializeField]
    public static ControlSettings CS;
    [SerializeField]
    public static Stats Stats;
    [SerializeField]
    public static Stats Checkpoint;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Settings.GS == null)
        {
            Settings.GS = _GameSettings;
        }
        if (Settings.CS == null)
        {
            Settings.CS = _ControlSettings;
        }
        if (Settings.Stats == null)
        {
            Settings.Stats = _Stats;
        }
        if (Settings.Checkpoint == null)
        {
            Settings.Checkpoint = _Checkpoint;
        }
    }
    void Update()
    {
        if (Checkpoint.Checkpoint && Input.GetKeyDown(KeyCode.Backspace))
        {
            Time.timeScale = 1;
            StopAllCoroutines();
            Application.LoadLevel(Application.loadedLevel);
            Checkpoints.Load();
        }
    }
    void OnApplicationQuit()
    {
        Checkpoint.Reset();
        Stats.Reset();
    }
    public static void UnlockMouse(bool unlock)
    {
        if (unlock)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
