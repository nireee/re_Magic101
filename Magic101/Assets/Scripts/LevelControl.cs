using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public Spell sp;
    public string cur_spell;
    public Scene scene;

    public TMPro.TMP_Text tmp;
    public string text_to_display;
    public bool goNextLevel;

    GameObject burn_out_rock;
    GameObject water_to_rise;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        cur_spell = sp.spell;
        CheckLevel();
        scene = SceneManager.GetActiveScene();

    }

    void CheckLevel()
    {
        if (scene.buildIndex == 0)
        {

            GetEarthLevel();
        }
        else if (scene.buildIndex == 1)
        {

            GetWaterLevel();
        }
        else if (scene.buildIndex == 2)
        {
            GetWindLevel();
        }
        else if (scene.buildIndex == 3)
        {
            GymLevel();
        }
    }

    void GetEarthLevel()
    {
        burn_out_rock = GameObject.Find("BurnOutRock");
        if (burn_out_rock == null && goNextLevel == false)
        {
            Debug.Log("Get Earth!");
            DisplayText("You received element: Earth!");
            goNextLevel = true;
            Invoke("JumpNextScene", 3);
        }

    }

    void DisplayText(string txt)
    {
        if (goNextLevel == false)
        {
            tmp.text = txt;
        }
    }

    void GetWaterLevel()
    {
        water_to_rise = GameObject.Find("WaterVFX");
        if (count > 3 && goNextLevel == false)
        {
            Debug.Log("Get Water!");
            DisplayText("You received element: Water!");
            goNextLevel = true;
            Invoke("JumpNextScene", 3);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            count += 1;
            water_to_rise.transform.position = new Vector3(water_to_rise.transform.position.x, water_to_rise.transform.position.y + 0.2f, water_to_rise.transform.position.z);
        }
    }

    void GetWindLevel()
    {
        if (Input.GetKeyDown(KeyCode.W) && goNextLevel == false)
        {
            Debug.Log("Get Wind!");
            DisplayText("You received element: Wind!");
            goNextLevel = true;
            Invoke("JumpNextScene", 3);
        }
    }

    void GymLevel()
    {
        //check if interactable obj still exist, if not, reset the scene/ instatiate a new interactable obj
    }

    void JumpNextScene()
    {
        if (goNextLevel == true)
        {
            goNextLevel = false;
            Debug.Log("LoadNextScene!");
            SceneManager.LoadScene(scene.buildIndex + 1);
            DisplayText("");
        }
    }
}
