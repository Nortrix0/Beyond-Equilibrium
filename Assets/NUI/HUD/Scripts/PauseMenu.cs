using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    [SerializeField] GameObject PausePanel;
    [SerializeField] Button ResumeGameButton;
    [SerializeField] Button RestartButton;
	void Start () {
        PausePanel.SetActive(false);
        ResumeGameButton.onClick.AddListener(Pause);
        RestartButton.onClick.AddListener(Restart);
	}

    void Update()
    {
        if (Input.GetKeyDown(Settings.CS.Keys[6].Key))
        {
            Pause();
        }
	}
    void Pause()
    {
        PausePanel.SetActive(!PausePanel.activeSelf);
        bool isPaused = PausePanel.activeSelf;
        int time = isPaused ? 0 : 1;
        Time.timeScale = time;
        Time.fixedDeltaTime = time * 0.02f;
        Settings.UnlockMouse(isPaused);
    }
    void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        Pause();
    }
}
