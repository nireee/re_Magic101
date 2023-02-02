using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public Spell sp;
    public string cur_spell;
    public Scene scene;

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
        if(scene.buildIndex == 0)
        {
            
            GetEarthLevel();
        }
        else if(scene.buildIndex == 1)
        {
            water_to_rise = GameObject.Find("WaterVFX");
            GetWaterLevel();
        }
        else if(scene.buildIndex == 2)
        {
            GetWindLevel();
        }
        else if(scene.buildIndex == 3)
        {
            GymLevel();
        }
    }

    void GetEarthLevel()
    {
        burn_out_rock = GameObject.Find("BurnOutRock");
        if(burn_out_rock == null)
        {
            Debug.Log("Get Earth!");
            JumpNextScene();
        }
        
    }

    void GetWaterLevel()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(count < 3)
            {
                water_to_rise.transform.position= new Vector3(water_to_rise.transform.position.x, water_to_rise.transform.position.y + 0.2f, water_to_rise.transform.position.z);
                count += 1;
            }
            else
            {
                JumpNextScene();
            }
        }
    }

    void GetWindLevel()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //get wind
            JumpNextScene();
        }
    }

    void GymLevel()
    {

    }

    void JumpNextScene()
    {
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}
