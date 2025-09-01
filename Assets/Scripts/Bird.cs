using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    // [SerializeField] allows private properties to be modified in editor
    
    private Rigidbody rigidbody;
    [SerializeField] private float jumpForce = 10, speed = 5;
    [SerializeField] private Transform floor, camera;
    private Vector3 floorOffset, cameraOffset;
    
    [SerializeField] private PillairSpawner pillairSpawner;

    [SerializeField] private TMP_Text scoreText;
    private int score = 0;
    
    private bool collided = false;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
        floorOffset = floor.position;
        cameraOffset = camera.position;
        
        scoreText.text = score.ToString();
    }
    
    void Update()
    {
        // Drops our bird down, we are dead
        if (collided)
            return;
        
        // Adds forwards motion
        rigidbody.linearVelocity = new Vector3(speed, rigidbody.linearVelocity.y, 0);
        
        floor.position = new Vector3(transform.position.x + floorOffset.x, floorOffset.y, transform.position.z + floorOffset.z);
        camera.position = new Vector3(transform.position.x + cameraOffset.x, cameraOffset.y, transform.position.z + cameraOffset.z);

        // Jumping
        var keyboard = Keyboard.current;
        if (keyboard.spaceKey.wasPressedThisFrame)
            rigidbody.linearVelocity = new Vector3(rigidbody.linearVelocity.x, jumpForce, 0);
    }

    // We collided, therefore we are dead
    private void OnCollisionEnter(Collision other)
    {
        collided = true;
    }

    // Spawn new Pillair and modify score
    private void OnTriggerEnter(Collider other)
    {
        pillairSpawner.SpawnPillair(transform.position);
        
        score++;
        scoreText.text = score.ToString();
    }
}
