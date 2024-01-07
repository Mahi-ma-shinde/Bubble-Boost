using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 300f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip engineThrusters;
    [SerializeField] ParticleSystem mainbooster;
    [SerializeField] ParticleSystem rightbooster;
    [SerializeField] ParticleSystem leftbooster;

    Rigidbody rb;
    AudioSource audioSource;
    GameObject spinner; 
    GameObject[] spinnerwheel1, spinnerwheel2;
    Collider capsuleSpinner;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        spinner = GameObject.FindGameObjectWithTag("spinner");
        capsuleSpinner = GetComponent<Collider>();
        capsuleSpinner.isTrigger = false;
        if (spinnerwheel1 == null)
        {
            spinnerwheel1 = GameObject.FindGameObjectsWithTag("spinnerwheel1");
        }
        if (spinnerwheel2 == null)
        {
            spinnerwheel2 = GameObject.FindGameObjectsWithTag("spinnerwheel2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        capsuleSpinner.isTrigger = false;
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }

    }

    private void StopThrusting()
    {
        audioSource.Stop();
        capsuleSpinner.isTrigger = false;
        mainbooster.Stop();
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        capsuleSpinner.isTrigger = true;
        if (capsuleSpinner == true)
        {
            spinner.transform.Rotate(50, 0, 0);
        }
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(engineThrusters);

        }
        if (!mainbooster.isPlaying)
        {
            mainbooster.Play();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ARotate();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            DRotate();
        }
        else
        {
            StopRotation();
        }
    }

    private void StopRotation()
    {
        capsuleSpinner.isTrigger = false;
        leftbooster.Stop();
        rightbooster.Stop();
    }

    private void DRotate()
    {
        capsuleSpinner.isTrigger = true;
        foreach (GameObject spinwheel in spinnerwheel2)
        {
            if (capsuleSpinner == true)
            {
                spinwheel.transform.Rotate(0, 0, 50);
            }
        }
        ApplyRotation(-rotationThrust);
        if (!leftbooster.isPlaying)
        {
            leftbooster.Play();
        }
    }

    private void ARotate()
    {
        capsuleSpinner.isTrigger = true;
        foreach (GameObject spinwheel in spinnerwheel1)
        {
            if (capsuleSpinner == true)
            {
                spinwheel.transform.Rotate(0, 0, 50);
            }
        }
        ApplyRotation(rotationThrust);
        if (!rightbooster.isPlaying)
        {
            rightbooster.Play();
        }
    }

    public void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // Freezing rotation so that we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing the rotation so the physics system can take over
    }
}
