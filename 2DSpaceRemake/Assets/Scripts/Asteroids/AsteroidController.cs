﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float moveSpeed = 20f;
    private Rigidbody rb;
    private Vector3 randomRotation;
    private float removePositionZ;

    public Material targetMaterial;
    private Material baseMat;

    private Renderer[] Renderers;

    public int dmg;


    public bool isGoldenAsteroid = false;

    public M1L1Controller m1L1;




   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomRotation = new Vector3(Random.Range(0f, 100f), Random.Range(0f, 100f), Random.Range(0f, 100f));
        removePositionZ = Camera.main.transform.position.z;
        Renderers = GetComponentsInChildren<Renderer>();
        baseMat = Renderers[0].material;
        m1L1 = FindFirstObjectByType<M1L1Controller>();
    }

    public void ResetMaterial()
    {
        if (Renderers == null)
            return;
        foreach(Renderer rend in Renderers)
        {
            rend.material = baseMat;
        }
    }

    public void SetTargetMaterial()
    {
        if (Renderers == null)
            return;
        foreach (Renderer rend in Renderers)
        {
            rend.material = targetMaterial;
        }
    }

  
    void Update()
    {
        if(transform.position.z < removePositionZ)
        {
            entitiesController.Instance.currentAsteroid.Remove(gameObject);
            
            Destroy(gameObject);

        }

        Vector3 movementVector = new Vector3(0f, 0f, -moveSpeed * Time.deltaTime);
        rb.velocity = movementVector;

        transform.Rotate(randomRotation * Time.deltaTime);
    }

    public void DestroyAsteroid()
    {

        if(isGoldenAsteroid)
        {
            // add gold

            StatsController.inst_controller.money += 20;

        }

        entitiesController.Instance.currentAsteroid.Remove(gameObject);
        //play particall effect

        //disable movement

        //disable colliders

        //destroy game object with a delay
        Destroy(gameObject);
        m1L1.astroidsDestroyed -=1;
        StatsController.inst_controller.score ++;
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().OnAsteroidImpact();
            DestroyAsteroid();
        }
    }
}
