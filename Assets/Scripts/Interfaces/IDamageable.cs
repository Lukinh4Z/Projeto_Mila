using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    internal interface IDamageable
    {
        void Damage(float damage);
        void CheckDeath();
    }
}
