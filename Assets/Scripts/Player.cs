using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float Speed = 3f;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private GameObject Flash;
    [SerializeField] private GameObject HitMarker;
    [SerializeField] private AudioSource WeaponAudio;
    [SerializeField] private int CurrentAmmo;
    [SerializeField] private int MaxAmmo = 100;
    private bool isReloading = false;
    private UIManager UIManager;
    public bool HasCoin = false;
    [SerializeField] private GameObject Weapon;
    private bool WeaponBool = false;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CurrentAmmo = MaxAmmo;
        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && CurrentAmmo > 0)
        {
            Shoot();
        }
        else
        {
            Flash.SetActive(false);
            WeaponAudio.Stop();
        }
        if (Input.GetKeyDown(KeyCode.R) && isReloading == false && WeaponBool == true)
        {
            isReloading = true;
            StartCoroutine(Reload());
        }

        Movement();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    private void Shoot()
    {
        Flash.SetActive(true);
        CurrentAmmo--;
        UIManager.UpdateAmmo(CurrentAmmo);
        if (WeaponAudio.isPlaying == false)
        {
            WeaponAudio.Play();
        }
        Ray rayOrgin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrgin, out hitInfo))
        {
            GameObject hitMarker = Instantiate(HitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(hitMarker, 1f);
            Destructable destructable = hitInfo.transform.GetComponent<Destructable>();
            if(destructable != null)
            {
                destructable.DestroyCrate();
            }
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * Speed;
        velocity.y -= gravity;
        velocity = transform.transform.TransformDirection(velocity);
        controller.Move(velocity * Time.deltaTime);
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1f);
        CurrentAmmo = MaxAmmo;
        UIManager.UpdateAmmo(CurrentAmmo);
        isReloading = false;
    }
    public void EnableWeapon()
    {
        Weapon.SetActive(true);
        WeaponBool = true;
    }
}
