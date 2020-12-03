using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _2DAction
{
    class Title:IScene
    {
        private bool endFlag;//終了フラグ
        private bool isPressKey;//キーを押したか?
        private int timer;//タイマー
        public Title()
        {

        }
        public void Initialize()
        {
            //変数の初期化
            endFlag = false;
            isPressKey = true;
            timer = 0;//タイマー
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
                else
                {
                    isPressKey = false;
                }
            }
            timer++;
        }
        public void Draw(Renderer renderer)
        {
            //背景の表示
            //文字の表示

            //スタートテキストの表示
            if (timer % 60 < 30)
            {
            }
            else
            {//半透明
            }
        }
        public bool IsEnd()
        {
            return endFlag;
        }
        public Scene Next()
        {
            return Scene.GamePlay;
        }
    }
}
