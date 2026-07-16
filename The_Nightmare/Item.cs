using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    public class Sword : IItem
    {
        public string Name => "낡은 단검";
        public string Description => "누군가의 추억이 담긴 물건이다.";
        public void Use(Player player)
        {
            // Increase player's attack power when the sword is used
            player.EquipWeapon(10);
            Console.WriteLine($"{player}가 아이템 {Name}을 장착했습니다.");
        }
    }

    public class Potion : IItem
    {
        public string Name => "낡은 단검";
        public string Description => "누군가의 추억이 담긴 물건이다.";
        public void Use(Player player)
        {
            // Increase player's attack power when the sword is used
            player.EquipWeapon(10);
            Console.WriteLine($"{player}가 아이템 {Name}을 장착했습니다.");
        }
    }
}
