using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterWeaponChanger : MonoBehaviour
{
    public CharacterWeaponChangerParameters parameters;
    public CharacterWeaponChangerComponents components;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SwitchWeapon();

        ApplyIKToRelativePosition();
    }
    public void SwitchWeapon()
    {
        if (parameters.CurrentWeapon >= parameters.weapons.Length - 1)
            parameters.CurrentWeapon = 0;
        else
            parameters.CurrentWeapon++;

        for (int i = 0; i < parameters.weapons.Length; i++)
        {
            if (i != parameters.CurrentWeapon)
            {
                parameters.weapons[i].weaponObject.SetActive(false);
            }
            else
            {
                parameters.weapons[i].weaponObject.SetActive(true);
            }
        }

        CharacterGlobal.instance.characterShooting.FindMuzzle();
    }

    void ApplyIKToRelativePosition()
    {
        components.leftHand.transform.position = parameters.weapons[parameters.CurrentWeapon].leftHandTarget.transform.position;
        components.leftHand.transform.rotation = parameters.weapons[parameters.CurrentWeapon].leftHandTarget.transform.rotation;
        components.rightHand.transform.position = parameters.weapons[parameters.CurrentWeapon].rightHandTarget.transform.position;
        components.rightHand.transform.rotation = parameters.weapons[parameters.CurrentWeapon].rightHandTarget.transform.rotation;
    }
}

[System.Serializable]
public class CharacterWeaponChangerComponents
{
     public Transform rightHand;
     public Transform leftHand;
}

[System.Serializable]
public class CharacterWeaponChangerParameters
{
    [SerializeField]
    int currentWeapon;
    public int CurrentWeapon { get => currentWeapon; set => currentWeapon = value; }

    public Weapon[] weapons;
}

[System.Serializable]
public class Weapon
{
    public GameObject weaponObject;
    public Transform rightHandTarget;
    public Transform leftHandTarget;
}
