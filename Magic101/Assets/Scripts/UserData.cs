using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserData : MonoBehaviour
{
    public string[] cur_spells;
    public bool can_cast;
    public Scene scene;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        cur_spells = new string[10];
        cur_spells[0] = "Fire";
    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();
    }

    public void CheckSpellAva(string spell)
    {
        for(int i =0; i < 9; i++)
        {
            if (cur_spells[i] == spell)
            {
                can_cast = true;
            }
        }
    }

    public void GetEarth()
    {
        cur_spells[1] = "Earth";
    }

    public void GetWater()
    {
        cur_spells[2] = "Water";
    }

    public void GetWind()
    {
        cur_spells[3] = "Wind";
    }
    public void GetFog()
    {
        cur_spells[4] = "Fog";
    }

    public void GetLava()
    {
        cur_spells[5] = "Lava";
    }

    public void GetStorm()
    {
        cur_spells[6] = "Storm";
    }

    void JumpNextScene()
    {
        SceneManager.LoadScene(scene.buildIndex + 1);
    }


}
