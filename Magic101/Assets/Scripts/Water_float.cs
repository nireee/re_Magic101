using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Water_float : MonoBehaviour
{



    Rigidbody m_Rigidbody;

    public float underWaterDrag = 3f;
    public float underWaterAngularDrag = 1f;
    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;
    public float waterHeight = 0f;
    public float floatingPower = 15f;

    public bool underwater;

    // Start is called before the first frame update
    void Start()
    {

    }

// Update is called once per frame
    void Update()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        float difference = transform.position.y - waterHeight;

        if (difference < 0)
        {
            m_Rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), transform.position, ForceMode.Force);
            if (!underwater)
            {
                underwater = true;

            }
        }
        else if (underwater)
        {
            underwater = false;
            SwitchState(false);
        }
    }

    void SwitchState(bool isUnderwater)
    {
        if (isUnderwater)
        {
            m_Rigidbody.drag = underWaterDrag;
            m_Rigidbody.angularDrag = underWaterAngularDrag;
        }
        else
        {
            m_Rigidbody.drag = airDrag;
            m_Rigidbody.angularDrag = airAngularDrag;
        }
    }

}
