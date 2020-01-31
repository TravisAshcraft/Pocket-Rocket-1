using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float mainThrust = 750f;
    [SerializeField] float rcsThrust = 100f;

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
