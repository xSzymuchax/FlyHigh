using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 startCamPosition;
    public Camera cam;
    private float basezoom = 60f;
    private bool isCrazy = false;

    public Vector3 targetPoint;
    public Vector3 targetCamPoint;
    public float newZoom;
    public float lastZoom;

    public float progress = 0f;
    public float progressCam = 0f;

    private float jumpCam = 0.2f;

    public static CameraController instance;

    private void Start()
    {
        startPosition = transform.position;
        cam = GetComponentInChildren<Camera>();
        startCamPosition = cam.transform.localPosition;
        instance = this;
        FindNewTargetPoint();
        FindNewZoom();
    }
    
    public void GoCrazy()
    {
        isCrazy = true;
    }

    public void GoNormal()
    {
        isCrazy = false;
    }

    public void Repair()
    {
        transform.position = startPosition;
        cam.fieldOfView = 60f;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    

    void Update()
    {
        if (!isCrazy)
            return;

        CrazyCamera();
        ShakyCamera();
    }

    private void CrazyCamera()
    {
        progress += Time.deltaTime;

        transform.LookAt(GameController.instance.FlyPosition());

        Vector3 newPosition = Vector3.Lerp(transform.position, targetPoint, progress);
        transform.position = newPosition;

        float newzoom = Mathf.Lerp(lastZoom, newZoom, progress);

        cam.fieldOfView = newzoom;

        if (progress >= 1f)
        {
            FindNewTargetPoint();
            FindNewZoom();

            progress = 0f;
            Debug.Log("Obiekt osi¹gn¹³ punkt docelowy!");
        }
    }

    private void ShakyCamera()
    {
        Vector3 newPositionCam = Vector3.Lerp(cam.transform.localPosition, targetCamPoint, progress);
        cam.gameObject.transform.localPosition = newPositionCam;

        //if (progress >= 1f)
        //{
            FindNewShakePoint();
            Debug.Log("Obiekt osi¹gn¹³ punkt docelowy!");
        //}
    }

    private void FindNewShakePoint()
    {
        targetCamPoint = new Vector3(startCamPosition.x + jumpCam * Random.Range(-1f, 1f), startCamPosition.y + jumpCam * Random.Range(-1f, 1f), startCamPosition.z + jumpCam * Random.Range(-1f, 1f));
    }

    private void FindNewTargetPoint()
    {
        targetPoint = new Vector3(startPosition.x + 10 * Random.Range(-1f, 1f), startPosition.y + 5 * Random.Range(-1f, 1f), startPosition.z + 2 * Random.Range(-1f, 1f));
    }

    private void FindNewZoom()
    {
        lastZoom = newZoom;
        newZoom = basezoom + 30 * Random.Range(-1f, 1f);
    }
}
