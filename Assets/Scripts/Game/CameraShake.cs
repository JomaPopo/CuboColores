using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin noise;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        StopShaking(); // Al inicio, la cámara no hace Shake
    }

    public void ShakeCamera(float amplitude)
    {
        if (amplitude > 0)
        {
            noise.m_AmplitudeGain = amplitude;
            Invoke(nameof(StopShaking), 0.3f); // Duración fija de 0.3 segundos
        }
    }

    private void StopShaking()
    {
        noise.m_AmplitudeGain = 0f;
    }
}