using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2DAction
{
    class Enemy
    {
        private Vector2 position;
        private Vector2 size;
        private Vector2 halfsize;
        private Vector2 speed;
        private bool dir;
        private bool deadFlag;
        private Stage stage;
        //private Direction dir;
        public Enemy(Stage stage)
        {
            this.stage = stage;
            speed = new Vector2(0,0);
            position = new Vector2(0,0);
            size = new Vector2(64, 64);
            halfsize = new Vector2(32, 32);
            position.X = halfsize.X;
            position.Y = Screen.BaseY - halfsize.Y;
            Random rand = new Random();
            speed.X = rand.Next(2, 7);
            speed.Y = 0;
            deadFlag = false;
            if (rand.Next(3) == 0)
            {
                position.X = -halfsize.X;
                dir = true;
                //dir = Direction.Right;
            }
            else
            {
                position.X = StageMap.width + halfsize.X;
                dir = false;
                //dir = Direction.Left;
            }
        }
        public void Draw(Renderer renderer)
        {
            Rectangle rect = new Rectangle(0, 0, (int)size.X, (int)size.Y);
            if (dir == true)
            {
                //renderer.DrawTexture("enemy", stage.GetScreenPosition(position)-halfsize,rect);
            }
            else
            {
                renderer.DrawTexture("enemy", stage.GetScreenPosition(position)-halfsize,rect);
            }
        }
        public void Update()
        {
            Move();
        }
        private void Move()
        {
            if (dir == true)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
            InScreen();
        }
        private void InScreen()
        {
            if (position.X < -halfsize.X)
            {
                deadFlag = true;
            }
            if (position.X > StageMap.width + halfsize.X)
            {
                deadFlag = true;
            }
        }
        public bool IsDead()
        {
            return deadFlag;
        }
        private void MoveRight()
        {
            position.X += speed.X;
        }
        private void MoveLeft()
        {
            position.X -= speed.X;
        }
        public Vector2 GetPosition()
        {
            return position;
        }
    }
}
