using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    public static class ObjectFactory
    {
        // 도감
        private static readonly Dictionary<string, ICreator> _creators = 
            new Dictionary<string, ICreator>();

        static ObjectFactory() { }
        
        public static void Initialize(GameObject player, string typeName, ICreator creator)
        {
            // 도감에 몬스터 생성자 등록
            RegisterCreator("Skeleton", new SkeletonCreator(player));
        }

        public static void RegisterCreator(string typeName, ICreator creator)
        {
            if (!_creators.ContainsKey(typeName))
            {
                _creators.Add(typeName, creator);
            }
        }
        public static GameObject Spawn(string typeName, int x, int y)
        {
            if (_creators.TryGetValue(typeName, out ICreator creator))
            {
                return creator.Create(x, y);
            }
            throw new ArgumentException("Invalid object type");
        }
    }
}
