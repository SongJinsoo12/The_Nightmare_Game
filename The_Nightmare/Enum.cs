using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
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

    public enum AnimState
    {
        Idle_Up, Idle_Down, Idle_Left, Idle_Right,
        Moving_Up, Moving_Down, Moving_Left, Moving_Right,
        Attacking_Up, Attacking_Down, Attacking_Left, Attacking_Right,
        Hit,
        Dead
    }

    public enum PlayerState
    {
        Idle,
        Moving,
        Attacking,
        Hit,
        Dead
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
