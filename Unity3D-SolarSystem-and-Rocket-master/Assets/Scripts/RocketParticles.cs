using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RocketParticles : MonoBehaviour
{
    public ParticleSystem particles;
    public Rocket rocket;

    private float particlesSpeed;

    [System.Obsolete]
    private void Start()
    {
        particlesSpeed = particles.startSpeed;
    }

    [System.Obsolete]
    private void FixedUpdate()
    {
        particles.startSpeed = rocket.throttle;
    }
}
