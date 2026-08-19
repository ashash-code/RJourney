using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sun;

    [Header("Skyboxes")]
    public Material daySky;
    public Material sunsetSky;
    public Material nightSky;

    [Header("Lights To Control")]
    public Light[] lightsToControl;

    [Header("Time")]
    public float cycleDuration = 120f;

    [Header("Environment")]
    public float dayEnvironment = 1f;
    public float sunsetEnvironment = 0.35f;
    public float nightEnvironment = 0f;

    private float elapsedTime = 0f;

    void Start()
    {
        elapsedTime = 0f;
        SetDay();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        float time = (elapsedTime % cycleDuration) / cycleDuration;

        if (time < 0.65f)
        {
            SetDay();
        }
        else if (time < 0.80f)
        {
            SetSunset();
        }
        else
        {
            SetNight();
        }
    }

    void SetDay()
    {
        RenderSettings.skybox = daySky;
        RenderSettings.ambientIntensity = dayEnvironment;
        RenderSettings.reflectionIntensity = 1f;

        SetLights(true);

        if (sun != null)
        {
            sun.enabled = true;
            sun.intensity = 1f;
        }
    }

    void SetSunset()
    {
        RenderSettings.skybox = sunsetSky;
        RenderSettings.ambientIntensity = sunsetEnvironment;
        RenderSettings.reflectionIntensity = 0.2f;

        SetLights(true);

        if (sun != null)
        {
            sun.enabled = true;
            sun.intensity = 0.3f;
        }
    }

    void SetNight()
    {
        RenderSettings.skybox = nightSky;
        RenderSettings.ambientIntensity = nightEnvironment;
        RenderSettings.reflectionIntensity = 0f;

        SetLights(false);

        if (sun != null)
        {
            sun.enabled = false;
            sun.intensity = 0f;
        }
    }

    void SetLights(bool state)
    {
        if (lightsToControl == null)
            return;

        foreach (Light light in lightsToControl)
        {
            if (light != null)
                light.enabled = state;
        }
    }
}