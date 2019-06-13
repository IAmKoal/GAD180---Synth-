using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
    {
        public LineRenderer laserLineRenderer;
        public float laserWidth;
        public float laserMaxLength;
        public Transform firePoint;

        void Start()
        {   
            laserLineRenderer.SetPosition(0, firePoint.transform.position);
            laserLineRenderer.startWidth = laserWidth;
            laserLineRenderer.endWidth = laserWidth;
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                ShootLaserFromTargetPosition(transform.position, firePoint.transform.position , laserMaxLength);
                laserLineRenderer.enabled = true;
            }
            else
            {
                laserLineRenderer.enabled = false;
            }
        }

        void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
        {
            Ray ray = new Ray(targetPosition, direction);
            RaycastHit raycastHit;
            Vector3 endPosition = targetPosition + (length * direction);

            if (Physics.Raycast(ray, out raycastHit, length))
            {
                endPosition = raycastHit.point;
            }

            laserLineRenderer.SetPosition(0, targetPosition);
            laserLineRenderer.SetPosition(1, endPosition);
        }
    }
