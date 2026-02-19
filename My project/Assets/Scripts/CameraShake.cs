using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    private CinemachineCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin perlinNoise;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineCamera>();
        perlinNoise = GetComponent<CinemachineBasicMultiChannelPerlin>();
        ResetIntensity();

    }

    public void ShakeCamera(float intensity, float shakeTime)
    {
        perlinNoise.AmplitudeGain = intensity;
        StartCoroutine(WaitTime(shakeTime));
    }

    IEnumerator WaitTime(float shakeTime)
    {
        yield return new WaitForSeconds(shakeTime);
        ResetIntensity();
    }

    void ResetIntensity()
    {
        perlinNoise.AmplitudeGain = 0f;
    }

}
