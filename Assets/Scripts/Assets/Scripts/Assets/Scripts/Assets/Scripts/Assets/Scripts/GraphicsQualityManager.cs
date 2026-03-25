using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GraphicsQualityManager : MonoBehaviour
{
    // Global Settings for HD Graphics
    public bool enableAntiAliasing = true;
    public int antialiasingSampleCount = 4; // High Quality
    public bool enablePostProcessing = true;
    public bool enableShadows = true;

    void Start()
    {
        // 1. Quality Level Settings
        QualitySettings.SetQualityLevel(5); // Set to "Fantastic" (Highest)

        // 2. Anti-Aliasing (Smoothing Jagged Edges)
        if (enableAntiAliasing)
        {
            QualitySettings.antiAliasing = antialiasingSampleCount;
            Debug.Log("Anti-Aliasing Set to High: " + antialiasingSampleCount + "x");
        }

        // 3. Shadow Settings for clear vision
        if (enableShadows)
        {
            QualitySettings.shadowDistance = 150f;
            QualitySettings.shadows = ShadowQuality.All;
        }

        Debug.Log("High Quality Graphics Settings Applied (Titan Style)!");
    }
}
 
