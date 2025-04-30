using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public interface IDamageable
    {/// <summary>
     /// 
     /// </summary>
     /// <param name="entityDamage">Damage inflicted from the entity passed through</param>
     /// <param name="entityName">Name of the particular entity passed through</param>
     /// <param name="entityWeapon">Name of the weapon the entity has passed through</param>
        void TakeDamage(int entityDamage, string entityName, string entityWeapon);

    }
}
