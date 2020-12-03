using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace _2DAction
{
    class Stage
    {
        private float stageX;
        //ステージのマップ
        private int[,] mapDate=
        {
          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 7, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
          { 0, 0, 7, 7, 7, 0, 0, 0, 0, 0, 0, 7, 7, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
          { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 1, 2, 4,11, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0},
          { 2, 2, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  1, 2, 2, 4,10,10,11, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0},
          {10,10, 5, 2, 3, 0, 0, 1, 2, 2 ,2, 2, 2, 2, 2, 2,  4,10,10,10,10,10,11, 0, 0, 0, 0, 0, 0, 1, 3, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 24, 25},

        };
        private bool deadFlag;

        public Stage()
        {

        }
        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture("Bst", new Vector2(0, 0));

            int ct;
            int px, py;
            int tx, ty;

            for(int y = 0; y < StageMap.YMax; y++)
            {
                for(int x = 0; x < StageMap.XMax; x++)
                {
                    ct = mapDate[y, x];

                    if (ct != 0)
                    {
                        px = x * StageMap.BlockSize;
                        py = y * StageMap.BlockSize;

                        tx = ct % 8;
                        ty = ct / 8;

                        tx *= StageMap.BlockSize;
                        ty *= StageMap.BlockSize;

                        //renderer.DrawTexture("block", new Vector2(GetScreenX(px), py),
                            //new Rectangle(tx, ty, StageMap.BlockSize, StageMap.BlockSize)); 
                    }
                }
            }
        }
        public bool Goal(Vector2 position)
        {
            int by, bx;

            bx = (int)(position.X / StageMap.BlockSize);
            by = (int)(position.Y / StageMap.BlockSize);

            if (mapDate[by, bx] == 24 || mapDate[by, bx] == 25)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CollisionPoint(Vector2 position)
        {
            int by, bx;

            bx = (int)(position.X / StageMap.BlockSize);
            by = (int)(position.Y / StageMap.BlockSize);

            if (by < 0 || by >= StageMap.YMax)
            {
                return true;
            }

            if (position.X < 0 || bx >= StageMap.XMax)
            {
                return false;
            }

            if (mapDate[by, bx] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CollisionSide(Vector2 position,float size)
        {
            int i;

            for (i = 0; i < size; i++)
            {
                if (CollisionPoint(position) == false)
                {
                    return false;
                }
                position.Y++;
            }
            return true;
        }
        public bool CollisionUpDown(Vector2 position,float size)
        {
            for (int i = 0; i < size; i++)
            {
                if (CollisionPoint(position) == false)
                {
                    return false;
                }
                position.X++;
            }
            return true;
        }
        public void Initialize()
        {
            stageX = 0;
        }
        public void ScrollLeft()
        {
            if (stageX < StageMap.width - Screen.width)
            {
                stageX++;
            }
        }
        public void ScrollRight()
        {
            if (stageX > Screen.width - StageMap.width)
            {
                stageX--;
            }
        }
        public float GetScreenX(float x)
        {
            x -= stageX;
            return x;
        }
        public Vector2 GetScreenPosition(Vector2 position)
        {
            position.X -= stageX;
            return position;
        }
        public bool IsGameClear(Vector2 position)
        {
            int bx, by;

            // 座標をブロックのサイズで割って、どのブロックかを求める
            bx = (int)(position.X / StageMap.BlockSize);
            by = (int)(position.Y / StageMap.BlockSize);

            // マップの上下は対象外
            if (position.Y < 0 || by >= StageMap.YMax)
            {
                return false;   // ゲームクリアでは無い
            }

            // マップの右左は対象外
            if (position.X < 0 || by >= StageMap.XMax)
            {
                return false;   // ゲームクリアでは無い
            }

            // 24か25ならゲームクリア
            if (mapDate[by, bx] == 24 || mapDate[by, bx] == 25)
            {
                return true;// ゲームクリア
            }
            // それ以外ならゲームクリアでは無い
            else
            {
                return false;// ゲームクリアでは無い
            }
        }

    }
}   
