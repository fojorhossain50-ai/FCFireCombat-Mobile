using UnityEngine;
using System.Collections;

public class MVPSpotlight : MonoBehaviour
{
    public Transform mvpStandPoint; // Where the winner stands
    public Camera mainCamera;
    public float cameraZoomSpeed = 5f;

    // Call this function when the match ends
    public void SpotlightWinner(GameObject winnerPlayer)
    {
        // 1. Move the winner to the front of everyone
        winnerPlayer.transform.position = mvpStandPoint.position;
        winnerPlayer.transform.rotation = mvpStandPoint.rotation;

        // 2. Focus the camera on the MVP
        StartCoroutine(FocusCameraOnMVP(winnerPlayer.transform));
        
        Debug.Log("🏆 MVP SPOTLIGHT: " + winnerPlayer.name + " takes the center stage!");
    }

    IEnumerator FocusCameraOnMVP(Transform target)
    {
        Vector3 targetPos = target.position + target.forward * 3f + Vector3.up * 1.5f;
        
        while (Vector3.Distance(mainCamera.transform.position, targetPos) > 0.1f)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPos, cameraZoomSpeed * Time.deltaTime);
            mainCamera.transform.LookAt(target.position + Vector3.up * 1.5f);
            yield return null;
        }
    }
}
