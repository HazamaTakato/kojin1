using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _2DAction
{
    class Player
    {
        private Vector2 position;
        private int timer;
        private ActionMode mode;
        float velocityY = 0f;
        static readonly float JumpVelocity = 20f;
        static readonly float Gravity = 0.5f;
        private Stage stage;
        private Vector2 halfsize;
        private Vector2 halfsize2;
        private Vector2 halfsize3;
        private Vector2 halfsize4;
        private Vector2 size;
        private bool deadFlag;
        private Vector2 goal;
        public Player(Stage stage)
        {
            position = new Vector2(0,0);
            size = new Vector2(64, 64);
            halfsize= new Vector2(64/2, 64/2);
            goal = new Vector2(2944, 704);
            //halfsize2 = new Vector2(20, 32);
            //halfsize3 = new Vector2(64,64);
            //halfsize4 = new Vector2(128,0);
            
            this.stage = stage;
        }
        public void Draw(Renderer renderer)
        {
            Rectangle rect = new Rectangle(0, 0, (int)size.X, (int)size.Y);

            //renderer.DrawTexture("player", stage.GetScreenPosition(position) - halfsize,rect);
        }
        
        public void Initialize()    
        {
            position.X = 250;
            position.Y = 100;
            mode = ActionMode.Jump;
            timer = 0;
            velocityY = 0;
            deadFlag = false;
        }
        public void Update()
        {
            ChangeMode();
            Move();
            InScreen();
            JumpStart();
            MoveJump();
            FallStart();
        }
        void JumpStart()
        {
            if (mode == ActionMode.Jump)
            {
                return;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                mode = ActionMode.Jump;
                velocityY = -JumpVelocity;
            }
        }
        void MoveJump()
        {
            if (mode == ActionMode.Jump)
            {
                //velocityY += Gravity;
                //position.Y += velocityY;
                for (float i = 0; i < Math.Abs(velocityY); i += 0.5f)
                {
                    if (velocityY > 0)
                    {
                        MoveDownOne();
                    }
                    else
                    {
                        MoveUpOne();
                    }
                }
            }
            velocityY += 0.5f;
            //position.Y += velocityY;
        }
        private void MoveUpOne()
        {
            Vector2 starposition = position + new Vector2(halfsize.X / 2, -halfsize.Y);
            {
                if (stage.CollisionUpDown(starposition, halfsize.X) == true)
                {
                    position.Y -= 0.5f;
                }
                else
                {
                    velocityY = 0;
                }
            }
        }
        private void MoveDownOne()
        {
            Vector2 startPosition = position + new Vector2(-halfsize.X / 2, halfsize.Y);

            if (stage.CollisionUpDown(startPosition, halfsize.X) == true)
            {
                position.Y += 0.5f;
            }
            else
            {
                mode = ActionMode.Stand;
                //timer = 0;
            }
        }
        private void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                MoveRight();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                MoveLeft();
            }
        }
        private void MoveRight()
        {
            //4ドットごとに移動処理を行う
            for(int i = 0; i < 4; i++)
            {
                MoveRightOne();
            }
        }
        private void MoveLeft()
        {
            for(int i = 0; i < 4; i++)
            {
                MoveLeftOne();
            }
        }
        private void ChangeMode()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (mode == ActionMode.Stand)
                {
                    mode = ActionMode.Move;
                }
            }
            else
            {
                if (mode == ActionMode.Move)
                {
                    mode = ActionMode.Stand;
                }
            }
        }
        public Vector2 GetPosition()
        {
            return position;
        }
        private void MoveRightOne()
        {
            Vector2 startPosition = position + new Vector2(halfsize.X / 2+1 , -halfsize.Y);
            if (stage.CollisionSide(startPosition,size.Y) == true)
            {
                position.X++;
                if (stage.GetScreenX(position.X) > 600)
                {
                    stage.ScrollLeft();
                }
            }
        }
        private void MoveLeftOne()
        {
            Vector2 startPosition = position + new Vector2(-halfsize.X / 2 - 1, -halfsize.Y);
            if (stage.CollisionSide(startPosition,size.Y) == true)
            {
                position.X--;
                if (stage.GetScreenX(position.X) < 300)
                {
                    stage.ScrollRight();
                }
            }
        }
        private void FallStart()
        {
            if (mode == ActionMode.Jump)
            {
                return;
            }
            Vector2 startposition = position + new Vector2(-halfsize.X / 2, halfsize.Y);

            if (stage.CollisionUpDown(startposition, size.X) == true)
            {
                velocityY = 0;
                mode = ActionMode.Jump;
            }
        }
        private void InScreen()
        {
            if (position.Y>Screen.height)
            {
                deadFlag = true;
            }
            if (position.X == StageMap.XMax - size.X&&position.Y==Screen.height-64)
            {
                deadFlag = true;
            }
        }
        public bool IsGameClear()
        {
            // Ｙ座標を補正して足元の位置を出す
            Vector2 checkPosition = new Vector2(0, 0);
            checkPosition = position;
            checkPosition.Y += halfsize.Y;

            // 座標を渡してゲームクリアかを調べる
            bool ret = stage.IsGameClear(checkPosition);

            // 結果を返す
            return ret;
        }

    }
}
