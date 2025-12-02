using System;
using UnityEngine;

public class ItemWeapon : MonoBehaviour
{
    public float AttackSpeed = 3;
    //brute is false
    public bool DamageType = false;
    //This is used for slimes and stuff
    bool DefaultDamageType = false;
    //if null then use pocket, otherwise we are going to try to tag stuff
    public String AmmoRequirement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DefaultDamageType = DamageType;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Attack()
    {
    }
}
