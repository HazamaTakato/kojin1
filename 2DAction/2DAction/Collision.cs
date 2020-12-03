using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
namespace _2DAction
{
    class Collision
    {
        private Player player;
        private CharacterManager characterManager;
        private bool endFlag;

        public Collision(Player player,CharacterManager characterManager)
        {
            this.player = player;
            this.characterManager = characterManager;
        }
        public void Update()
        {
            CollisionPlayerEnemy();
        }
        private void CollisionPlayerEnemy()
        {
            Vector2 playerPosition = new Vector2(0, 0);
            Vector2 enemyPosition = new Vector2(0, 0);

            playerPosition = player.GetPosition();

            endFlag = false;

            List<Enemy> enemyList = characterManager.GetEnemyes();

            foreach(var e in enemyList)
            {
                enemyPosition = e.GetPosition();

                float distance = Vector2.Distance(playerPosition, enemyPosition);

                if (distance < 50)
                {
                    endFlag = true;
                }
            }
            if (playerPosition.Y > Screen.height+32)
            {
                endFlag = true;
            }
        }
        public bool IsEnd()
        {
            return endFlag;
        }
    }
}
