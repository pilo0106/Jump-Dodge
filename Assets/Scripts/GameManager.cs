using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //public int world;
    public int stage;
    //internal object time;
    public float time;
    public GameObject StartBtn;
    public GameObject EndBtn;

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel();
    }
    //Ū�����d
    public void LoadLevel()
    {
        SceneManager.LoadScene($"Scene{stage}");
    }
    public void NextLevel()
    {
        stage++;
        SceneManager.LoadScene($"Scene{stage}");
    }
    // Update is called once per frame

    //����Ū��
    public void DelayReset(float delay)
    {
        Invoke(nameof(LoadLevel), delay);
    }
    void Update()
    {
        time+=Time.deltaTime;
    }

    private void Awake()
    {
        if (Instance !=null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void StartGame()
    {
        NextLevel();
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
