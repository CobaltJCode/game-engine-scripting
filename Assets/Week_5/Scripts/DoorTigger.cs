using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTigger : MonoBehaviour
{

    [SerializeField] Transform m_DoorTransform;
    [SerializeField] Vector3 m_PositionOpen;

    private Vector3 m_PositionClose;

    private void Awake()
    {
        m_PositionClose = m_DoorTransform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        m_DoorTransform.position = m_PositionClose + m_PositionOpen;
    }

    private void OnTriggerExit(Collider other)
    {
        m_DoorTransform.position = m_PositionClose;
    }


}
