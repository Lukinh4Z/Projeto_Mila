using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Combat;

namespace Assets.Scripts.Interfaces
{
    public enum DamageType
    {
        Energy,
        Physical
    }
    internal interface IDamageable
    {
        void Damage(float damage, DamageType damageType);
        float ApplyDefences(float damage, DamageType damageType);
        void CheckDeath();
    }
}
