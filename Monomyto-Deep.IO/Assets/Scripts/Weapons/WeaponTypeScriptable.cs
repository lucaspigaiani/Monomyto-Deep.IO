using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Weapon", order = 0)]
public class WeaponTypeScriptable : ScriptableObject
{
    public enum WeaponType { Start, Simple, Composed }
    public WeaponType weaponType;
    public int ammo;
    [Range(1,3)] public int projectiles;
    public Color bulletCollor;

}
