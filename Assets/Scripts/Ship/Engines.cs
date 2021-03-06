﻿using System;
using UnityEngine;

public class Engines : MonoBehaviour
{

  private Rigidbody2D rb;
  public float EnginePower = 10f;
  public float SteeringPower = 1.4f;
  public float StrafingFactor = 0.5f;

  public bool EnginesEnabled { get; set; }
  public float ThrustInput { get; set; }
  public float StrafingInput { get; set; }
  public float SteeringInput { get; set; }

  void Start()
  {
    rb = GetComponentInParent<Rigidbody2D>();
    EnginesEnabled = true;
  }

  void FixedUpdate()
  {
    if (EnginesEnabled)
    {
      Thrust();
      Steer();
      Strafe();
    }
  }
  void Thrust()
  {
    Vector2 thrustVector = transform.up * ThrustInput * EnginePower;
    rb.AddForce(thrustVector);
  }

  void Steer()
  {
    float steeringForce = -SteeringInput * SteeringPower;
    rb.AddTorque(steeringForce);
  }

  void Strafe()
  {
    Vector2 strafeVector = transform.right * StrafingInput * StrafingFactor * EnginePower;
    rb.AddForce(strafeVector);
  }
}

