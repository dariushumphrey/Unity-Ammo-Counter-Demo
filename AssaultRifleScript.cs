using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssaultRifleScript : MonoBehaviour
{
    public int currentAmmo = 32;
    public float fireRate;
    public int ammoSize;
    public float reloadSpeed;
    public ParticleSystem muzzleFlash;
    public Transform weaponAnchor;
    public Image reticle;
    public Material[] ammoCounterNumbers;
   
    private int leftIndex, rightIndex;
    private string ammoReadConvert = "";
    private char leftIndexChar, rightIndexChar;
    private Renderer assaultRifle;
    private Material[] arMaterials;

    internal float fireAgain; //Seconds to wait until weapon can fire
    internal int ammoSpent = 0; //Tracks how many times weapon has fired -- used to subtract from reserve ammo
    internal bool isReloading = false; //Confirms an active reload if true
    internal bool firing = false;

    // Start is called before the first frame update
    void Start()
    {
        ammoSize = currentAmmo;
        ammoReadConvert = currentAmmo.ToString("D2");

        assaultRifle = GetComponent<Renderer>();
        arMaterials = assaultRifle.materials;
    }

    // Update is called once per frame
    void Update()
    {
        fireAgain += Time.deltaTime;
        AmmoReloadCheck();
        AmmoCounterRead();
        Attack(); 
    }

    public void Attack()
    {
        if (Input.GetButton("Fire1") && currentAmmo >= 1 && fireAgain >= fireRate && !isReloading)
        {
            firing = true;
            fireAgain = 0.0f;
            currentAmmo--;

            reticle.GetComponent<ARFireExpandScript>().SimulateShotSpread();

            muzzleFlash.Play();
            weaponAnchor.GetComponent<WeaponAnchorScript>().SimulateRecoil();
        }

        if(Input.GetButtonUp("Fire1"))
        {
            firing = false;
        }
    }

    public void AmmoReloadCheck()
    {
        if (!isReloading)
        {
            if (Input.GetKeyDown(KeyCode.R) && currentAmmo != 0 && !firing)
            {
                if (firing)
                {
                    Debug.Log("Cannot reload; Weapon is being actively fired!");
                }

                else if (currentAmmo >= ammoSize)
                {
                    Debug.Log("Cannot reload; magazine is full!");
                }

                else
                {
                    StartCoroutine(ReloadWep());
                }
            }

            else if (currentAmmo <= 0)
            {
                StartCoroutine(ReloadWep());
            }
        }
    }

    public IEnumerator ReloadWep()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadSpeed);

        currentAmmo = ammoSize;
        isReloading = false;
    }

    public void AmmoCounterRead()
    {
        ammoReadConvert = currentAmmo.ToString("D2");
        leftIndexChar = ammoReadConvert[0];
        rightIndexChar = ammoReadConvert[1];

        leftIndex = leftIndexChar - '0';
        rightIndex = rightIndexChar - '0';

        arMaterials[4] = ammoCounterNumbers[leftIndex];
        arMaterials[6] = ammoCounterNumbers[rightIndex];
        assaultRifle.materials = arMaterials;
    }
}
