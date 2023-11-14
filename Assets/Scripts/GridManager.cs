using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    public List<Grid> allgrids;

    [SerializeField] GameObject bg;
    [SerializeField] GameObject instruction;
    [SerializeField] GameObject win;

    [SerializeField] Text timerText;  // 新增 Text 變數
    private bool isGameOver = false;
    private float startTime;

    void gamemeunopen()
    {
        Time.timeScale = 0f;
        bg.SetActive(true);
    }

    public void gamemeunclose()
    {
        Time.timeScale = 1f;
        bg.SetActive(false);
        instruction.SetActive(false);
    }

    public void instructionopen()
    {
        Time.timeScale = 0f;
        instruction.SetActive(true);
    }

    public void restart()
    {
        CancelInvoke("UpdateTimer");// 這裡加入取消計時器的程式碼
        SceneManager.LoadScene("SampleScene");
    }

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        gamemeunopen();
        startTime = Time.time;
        // 更新 UI 上的計時器
        UpdateTimer();
    }

    void Update()
    {
        if (!isGameOver)
        {
            CheckGameOver();
        }
    }

    void CheckGameOver()
    {
        bool allPicesPut = true;

        foreach (var grid in allgrids)
        {
            if (!grid.hasPut)
            {
                allPicesPut = false;
                break;
            }
        }

        if (allPicesPut)
        {
            isGameOver = true;
            float endTime = Time.time;
            float totalTime = endTime - startTime;
            Debug.Log("Total Time: " + totalTime + " seconds");

            // 在這裡處理通關成功的相關操作，例如顯示通關成功畫面、播放音效等
            win.SetActive(true);
        }
        // 更新 UI 上的計時器
        UpdateTimer();
    }


    void UpdateTimer()
    {
        float currentTime = Time.time - startTime;
        int minutes = (int)(currentTime / 60);
        int seconds = (int)(currentTime % 60);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // 將計時器的文字顯示在 UI 上
        timerText.text = "Time: " + timerString;
    }

    //位置正確
    public void OnPutRight(Grid g)
    {
        allgrids.Remove(g);
        if (allgrids.Count == 0)
        {
            Debug.Log("finsh!");
            // 隱藏所有 Grid

        }
    }
}
