using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjToInteract : MonoBehaviour
{
    public float _interval = 2f;
    float _time;
    private Vector3 pos;
    public GameObject FireVFX;
    public GameObject WaterVFX;
    public GameObject EarthVFX;
    public GameObject WindVFX;
    public Spell sp;
    private string cur_spell;
    private bool isCast;
    // Start is called before the first frame update
    void Start()
    {
        pos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cur_spell = sp.spell;
        SpawnVFX(cur_spell);
    }

    void SpawnVFX(string spell)
    {
        if (spell == "Fire")
        {
            Instantiate(FireVFX, pos, Quaternion.identity);
            Destroy(gameObject, 3);
        }

        else if(spell == "Earth")
        {
            GameObject vfx;
            vfx = Instantiate(EarthVFX, pos, Quaternion.identity);
            _time += Time.deltaTime;
            while (_time >= _interval)
            {
                Destroy(vfx);
                _time -= _interval;
            }
        }

        else if (spell == "Water")
        {
            GameObject vfx;
            vfx = Instantiate(WaterVFX, pos, Quaternion.identity);
            _time += Time.deltaTime;
            while (_time >= _interval)
            {
                Destroy(vfx);
                _time -= _interval;
            }
        }

        else if (spell == "Wind")
        {
            GameObject vfx;
            vfx = Instantiate(WindVFX, pos, Quaternion.identity);
            _time += Time.deltaTime;
            while (_time >= _interval)
            {
                Destroy(vfx);
                _time -= _interval;
            }
        }
        else
        {
            //Debug.Log("Not Valid Spell!");
        }
    }


}
