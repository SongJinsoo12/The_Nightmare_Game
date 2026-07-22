using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    public abstract class AIComponent
    {
        protected GameObject _target;
        public MonsterState CurState { get; protected set; }
        public abstract void Update(GameObject owner);
    }
}
