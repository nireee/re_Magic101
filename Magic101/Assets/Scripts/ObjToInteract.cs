using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjToInteract : MonoBehaviour
{
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
            Destroy(gameObject, 1);
        }

        else if(spell == "Earth")
        {
             Instantiate(EarthVFX, pos, Quaternion.identity);
        }

        else if (spell == "Water")
        {
            Instantiate(WaterVFX, pos, Quaternion.identity);
        }

        else if (spell == "Wind")
        {
            Instantiate(WindVFX, pos, Quaternion.identity);
        }
        else
        {
            //Debug.Log("Not Valid Spell!");
        }
    }


}
