using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spell : MonoBehaviour
{
    public float _interval = 3f;
    float _time;
    public TMPro.TMP_Text tmp;
    private string spell;
    private string spell_default;
    private string spell_hold;

    public UserData ud;
    // Start is called before the first frame update
    void Start()
    {
        spell_default = "";
        _time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        _time += Time.deltaTime;
        while (_time >= _interval)
        {
            ud.CheckSpellAva(spell);
            if(ud.can_cast == true)
            {
                CastSpell();
                ud.can_cast = false;
            }
            _time -= _interval;
            spell = spell_default; 
        }
          
    }

    void CastSpell()
    {
        spell_hold = spell;
        tmp.text = spell_hold;
        CheckUnlock(spell);
    }

    void CheckUnlock(string sp)
    {
        if(sp == "Fire")
        {
            ud.GetEarth();
        }
        if(sp == "Water")
        {
            ud.GetWind();
            ud.GetFog();
        }
        if(sp == "Earth")
        {
            ud.GetWater();
            ud.GetLava();
        }
        if(sp == "Wind")
        {
            ud.GetStorm();
        }
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Fire();
            spell += "Fire";
            Debug.Log("Fire");
            
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Water();
            spell += "Water";
            Debug.Log("Water");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Earth();
            spell += "Earth";
            Debug.Log("Earth");

            
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Wind();
            spell += "Wind";
            Debug.Log("Wind");

        }

        if (spell == "FireWater" || spell == "WaterFire")
        {
            spell = "Fog";
        }
        else if (spell == "WaterWind" || spell == "WindWater")
        {
            spell = "Storm";
        }
        else if (spell == "FireEarth" || spell == "EarthFire")
        {
            spell = "Lava";
        }
    }

    void Fire()
    {
        //display fire
    }

    void Water()
    {
        //display water
    }

    void Earth()
    {
        //display earth
    }

    void Wind()
    {
        //display wind
    }
}
