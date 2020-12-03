using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DAction
{
    class Clear:IScene
    {
        private bool endFlag;
        private bool isPressKey;
        private int timer;

        public Clear()
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
            renderer.DrawTexture("Clear", new Vector2(340, 160), 0.8f);
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
