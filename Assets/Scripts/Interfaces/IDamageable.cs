using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    internal interface IDamageable
    {
        //float health { get; }
        void damage(float damage);
        void checkDeath();
    }
}
