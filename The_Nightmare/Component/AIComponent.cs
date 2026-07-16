using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare.Component
{
    public enum MonsterState
    {
        // 대기, 순찰, 추적, 공격, 죽음
        IDLE,
        PATROL,
        CHASE,
        ATTACK,
        DIE,
    }

    public abstract class AIComponent
    {
        protected GameObject _target;
        public MonsterState CurState { get; protected set; }
        public abstract void Update(GameObject owner);
    }
}
