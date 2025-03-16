using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[RequireComponent(typeof(SliderJoint2D))]
public class SliderPlatformBehaviour : MonoBehaviour
{
    private SliderJoint2D slider;
    private bool isLowerLimitReached = true;
    private void Start()
    {
        slider = GetComponent<SliderJoint2D>();
        isLowerLimitReached = true;
    }

    private void Update()
    {
        if ((slider.limitState == JointLimitState2D.UpperLimit && isLowerLimitReached) ||
            (slider.limitState == JointLimitState2D.LowerLimit && !isLowerLimitReached))
        {
            JointMotor2D inverseMotor = slider.motor;
            inverseMotor.motorSpeed *= -1;
            slider.motor = inverseMotor;
            isLowerLimitReached = !isLowerLimitReached;
        }
    }
}
