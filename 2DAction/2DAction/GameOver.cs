using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;          // 基本機能
using Microsoft.Xna.Framework.Input;    // 入力

namespace _2DAction
{
    class GameOver:IScene
    {
        private bool endFlag;
        private bool isPressKey;
        private int timer;

        public GameOver()
        {

        }
        public void Initialize()
        {
            endFlag = false;
            isPressKey = true;
            timer = 0;
        }
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                if (isPressKey == false)
                {
                    endFlag = true;
                    isPressKey = true;
                }
            }
            else
            {
                isPressKey = false;
            }
            timer++;
        }
        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture("gameover", new Vector2(340, 160), 0.8f);
            if (timer % 60 < 30)
            {
                renderer.DrawTexture("start text", new Vector2(280, 660));
            }
            else
            {
                renderer.DrawTexture("start text", new Vector2(280, 660), 0.3f);
            }
        }
        public bool IsEnd()
        {
            return endFlag;
        }
        public Scene Next()
        {
            return Scene.Title;
        }
    }
}
