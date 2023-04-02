using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScript : MonoBehaviour
{
    public static ShakeScript Instance;

    [Header("====References====")]
    [SerializeField] CinemachineVirtualCamera _cineCamera;

    private CinemachineBasicMultiChannelPerlin _noise;
    private float _resetSpeed;



    private void Awake()
    {
        _noise = _cineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        Instance = this;
    }

    private void Update()
    {
        _noise.m_AmplitudeGain = Mathf.Lerp(_noise.m_AmplitudeGain, 0, _resetSpeed * Time.deltaTime);
    }

    public void Shake(float amplitude, float duration)
    {
        _noise.m_AmplitudeGain = amplitude;
        _resetSpeed = duration;
    }
}
