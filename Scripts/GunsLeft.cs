using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class GunsLeft : MonoBehaviour
{
    [SerializeField] 
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawnPosition;
    [SerializeField] 
    private float fireRate;
    private float nextFire = 0;
    [SerializeField] 
    private Transform shipTransform;

    public float ammo = 30f;

    [SerializeField] public float ReloadTime = 5;

    // Start is called before the first frame update
    void Start()
    {

    }


    public float rotationSpeed = 100f; // Adjust the rotation speed as needed
    public Transform parentTransform; // Assign the parent's transform in the Unity editor
    public float maxRotationAngle = 130f; // Maximum rotation angle relative to parent's forward direction
    public float minRotationAngle = 0f;
    // Update is called once per frame
    void Update()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Convert mouse position to world space
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, parentTransform.position.z - Camera.main.transform.position.z));

        // Calculate direction vector from parent to mouse position
        Vector3 direction = mousePosition - this.transform.position;

        // Calculate the angle between direction vector and parent's forward direction
        float angle = Vector3.SignedAngle(parentTransform.up, direction, Vector3.forward);

        // Clamp the angle within -maxRotationAngle to maxRotationAngle
        angle = Mathf.Clamp(angle, 0, 130);

        // Calculate the target rotation based on the clamped angle relative to parent's forward direction
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, parentTransform.eulerAngles.z + angle);

        // Rotate the turret towards the target rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (Input.GetMouseButton(0) && Time.time >= nextFire && angle <= 130 && angle >= 0 && ammo > 0)
        {
            ShootBullet();
            ammo = ammo - 1;
            if (ammo == 0)
            {
                StartCoroutine(Reload());
            }
        }
    }


    private void ShootBullet()
    {
        Instantiate(bulletPrefab, bulletSpawnPosition.position, transform.rotation);
        nextFire = Time.time + fireRate;
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(ReloadTime);
        ammo = 30;
    }
}