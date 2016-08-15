using UnityEngine;
using System.Collections;

[System.Serializable]
public class WeaponObject : ScriptableObject {

    //Field of the weapons
    public string weaponName = "Weapon Name Here";
    public int cost = 50;
    public string description = "Description Here";
    public float fireRate = 0.5f;
    public int damage = 10;
    public float range = 50;

}
