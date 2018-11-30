using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : IDamageableObject
{

    public override int MaxHealth
    {
        get
        {
            throw new System.NotImplementedException();
        }
    }

    public override int Health
    {
        get
        {
            return 0;
        }
    }

    public override int ChangeHealth(int health)
    {
        return 0;
    }

    public override int Damage(int health)
    {
        throw new System.NotImplementedException();
    }

    public override IDamageableObject GetMainDamageableObject()
    {
        return this;
    }

    public override Vector3 GetPosition()
    {
        return this.transform.position;
    }

    public override int Heal(int health)
    {
        throw new System.NotImplementedException();
    }

    public override bool IsDead()
    {
        throw new System.NotImplementedException();
    }
}
