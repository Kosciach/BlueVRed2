using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ParticleController : MonoBehaviour
{
    [Header("====Reference====")]
    [SerializeField] VisualEffect _visualEffect;




    private void Start()
    {
        Destroy(gameObject, 2);
    }
}
