using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private LayerMask shootingLayer;
    [SerializeField] private int initialAmmoAmount;
    [SerializeField] private float shootingSpeed = 1f;

    private HealthSystem healthSystem;

    public float weaponRange = 20f;
    private int ammoAmount;
    private bool canShoot = true;
    private float shootingTimer = 0f;

    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        ammoAmount = initialAmmoAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition -= new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += new Vector3(0, 0, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition -= new Vector3(0, 0, speed * Time.deltaTime);
        }

        if (Input.GetButton("Fire1") && canShoot && ammoAmount > 0)
        {
            Shoot();
            canShoot = false;
        }

        if (!canShoot) {
            shootingTimer += Time.deltaTime;

            if (shootingTimer >= shootingSpeed)
            {
                shootingTimer = 0;
                canShoot = true;
            }
        }

        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = 20;

        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point;
            Vector3 direction = targetPosition - transform.position;
            direction.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if (healthSystem.GetHealth() <= 0) 
        {
            Die();
        }

    }

    private void Shoot()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit, weaponRange, shootingLayer))
        {
            targetPoint = hit.point;

            Debug.Log(hit.collider.name);
        }
    }

    private void Die()
    {
        Debug.Log("Player Died!");
    }
}
