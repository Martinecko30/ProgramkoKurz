using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] private float jumpForce = 10, speed = 5;
    [SerializeField] private Transform floor, camera;
    private Vector3 floorOffset, cameraOffset;
    
    [SerializeField] private PillairSpawner pillairSpawner;
    
    private bool collided = false;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
        floorOffset = floor.position;
        cameraOffset = camera.position;
    }
    
    void Update()
    {
        if (collided)
            return;
        
        rigidbody.linearVelocity = new Vector3(speed, rigidbody.linearVelocity.y, 0);
        
        floor.position = new Vector3(transform.position.x + floorOffset.x, floorOffset.y, transform.position.z + floorOffset.z);
        camera.position = new Vector3(transform.position.x + cameraOffset.x, cameraOffset.y, transform.position.z + cameraOffset.z);

        var keyboard = Keyboard.current;

        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            rigidbody.linearVelocity = new Vector3(rigidbody.linearVelocity.x, jumpForce, 0);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        collided = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        pillairSpawner.SpawnPillair(transform.position);
    }
}
