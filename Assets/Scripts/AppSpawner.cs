using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AppSpawner : MonoBehaviour
{
    //timer
    public TMP_Text timerText;
    public float timeLeft = 10;
    private bool timeIsRunning = false;
    
    //variable for desktop apps array
    public GameObject[] appsArray = new GameObject[44];

    //variable for pinned apps array
    public GameObject[] pinnedAppsArray = new GameObject[7];

    //win screen
    public GameObject winScreen;

    public GameObject loseScreen;

    //lose screen

    [SerializeField]
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {   
        RandomizeApps();
        LoadApps();
        LoadPinnedApps();

        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeIsRunning)
        {
            if(timeLeft > 0)
        {
                timeLeft -= Time.deltaTime;
                UpdateTimer();
            }
            else if (timeLeft < 0)
            {
                loseScreen.SetActive(true);
                timeIsRunning = false;
            }
        }

        if ((counter > 6) && timeIsRunning)
        {
            winScreen.SetActive(true);
            loseScreen.SetActive(false);
        }
        
    }

    //method responsible for randomizing the order in which the apps spawn
    private void RandomizeApps()
    {
        for (int t = 0; t < appsArray.Length; t++ )
        {
            GameObject tmp = appsArray[t];
            int r = Random.Range(t, appsArray.Length);
            appsArray[t] = appsArray[r];
            appsArray[r] = tmp;
        }
    }

    //method responsible for desktop instantiation
    private void LoadApps()
    {
        
        //this is responsible for instantiating the apps
        for ( int i = 0; i < appsArray.Length; i++)
        {
            appsArray[i] = Instantiate(appsArray[i], new Vector3 (0,0,0), Quaternion.identity) as GameObject; 
            appsArray[i].transform.SetParent(GameObject.Find("Content").transform, false);
        }
    }

    //method responsible for pinned apps instantiation
    private void LoadPinnedApps()
    {
        for (int i = 0; i < 7; i++)
        {
            pinnedAppsArray[i] = Instantiate(pinnedAppsArray[i], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            pinnedAppsArray[i].transform.SetParent(GameObject.Find("Pinned").transform, false);
        }
    }

    public void CountIncrease()
    {
        counter++;
    }

    private void UpdateTimer()
    {
        timerText.text = timeLeft.ToString("00:00");
    }
}
