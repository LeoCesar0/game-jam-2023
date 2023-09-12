using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
   bool TakeDamage(int damage, GameObject attacker = null);
}
