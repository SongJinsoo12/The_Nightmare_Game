using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare.Component
{
    public enum MonsterState
    {
        // 대기, 순찰, 추적, 공격
        IDLE,
        PATROL,
        CHASE,
        ATTACK,
    }

    public abstract class AIComponent
    {
        public abstract void Update(GameObject owner);
    }
}
