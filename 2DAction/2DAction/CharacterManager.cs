using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DAction
{
    class CharacterManager
    {
        private Player player;
        private List<Enemy> enemyList;
        private Random rand;
        private Stage stage;

        public CharacterManager(Player player,Stage stage)
        {
            this.player = player;
            this.stage = stage;
            enemyList = new List<Enemy>();
            rand = new Random();
        }
        public void Initialize()
        {
            enemyList.Clear();
        }
        public void Update()
        {
            foreach(var e in enemyList)
            {
                e.Update();
            }
            enemyList.RemoveAll(e => e.IsDead() == true);
            EnemyBorn();
        }
        public void Draw(Renderer renderer)
        {
            foreach(var e in enemyList)
            {
                e.Draw(renderer);
            }
        }
        void EnemyBorn()
        {
            if (rand.Next(50) == 0)
            {
                enemyList.Add(new Enemy(stage));
            }
        }
        public List<Enemy> GetEnemyes()
        {
            return enemyList;
        }
    }
}
