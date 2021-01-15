using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    Animator anim;
    public GameObject player;
    public GameObject bullet;
    public GameObject turret;
    public Rigidbody shellRb;
    public Transform m_FireTransform;
    public float m_MinLaunchForce = 15f;

    private float m_CurrentLaunchForce;

    private void OnEnable()
    {
        m_CurrentLaunchForce = m_MinLaunchForce;
 //     m_AimSlider.value = m_MinLaunchForce;
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    void Fire()
    {
     // GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);

        Rigidbody shellInstance = Instantiate(shellRb, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;

        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

     // b.GetComponent<Rigidbody>().AddForce(turret.transform.position);
    }

    public void StopFiring()
    {
        CancelInvoke("Fire"); //alternates
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
    }

}
