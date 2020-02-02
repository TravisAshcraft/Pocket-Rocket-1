using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField] float mainThrust = 750f;
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] ParticleSystem exhaustParticle;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] ParticleSystem successParticle;

    public Joystick joystick;
    public ThrustButton joyButton;

    Rigidbody myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        ThurstUp();
        Rotate();
        ThurstUpTwo();
        RespondToRotateInput();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Launch Pad":
                break;
            case "Landing Pad":
                StartSuccessSequence();
                break;
            case "Default":
                StartDeathSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        SceneManager.LoadScene(1);
        successParticle.Play();
    }

    private void StartDeathSequence()
    {
        deathParticle.Play();
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

    private void ThurstUpTwo()
    {
        if (Input.GetKey(KeyCode.W))
        {
            float shipThrust = mainThrust * Time.deltaTime;
            myRigidbody.AddRelativeForce(Vector3.up * shipThrust);
            exhaustParticle.Play();
        }
        else
        {
            exhaustParticle.Stop();
        }
        
          
    }

    private void RespondToRotateInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateManually(rcsThrust * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateManually(-rcsThrust * Time.deltaTime);
        }
    }

    private void RotateManually(float rotationThisFrame)
    {
        myRigidbody.freezeRotation = true; // take manual control of rotation
        transform.Rotate(Vector3.forward * rotationThisFrame);
        myRigidbody.freezeRotation = false; // resume physics control of rotation
    }

    private void Rotate()
    {
        transform.Rotate(0, 0,-joystick.Horizontal * rcsThrust);
    }

    private void ThurstUp()
    {
        if (joyButton.Pressed)
        {
           float shipThrust = mainThrust * Time.deltaTime;
            myRigidbody.AddRelativeForce(Vector3.up * shipThrust);
        }
    }
}
