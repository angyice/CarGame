using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    const float PLAN_SIZE = 20f; 

    private PlatformManager m_PlatformManager;
    private GameObject m_Player;

    private void OnEnable()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_PlatformManager = GameObject.FindObjectOfType<PlatformManager>();
    }

    private void Update()
    {
        if (m_Player.transform.position.z > transform.position.z + PLAN_SIZE)
        {
            m_PlatformManager.RecyclePlatform(this.gameObject);
        }
    }
}

