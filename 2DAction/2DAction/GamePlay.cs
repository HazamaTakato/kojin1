using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;          // 基本機能
using Microsoft.Xna.Framework.Input;    // 入力
using Microsoft.Xna.Framework.Graphics;

namespace _2DAction
{
    class GamePlay:IScene
    {
        private bool endFlag;
        private Stage stage;
        private Enemy enemy;
        private Player player;
        private CharacterManager characterManager;
        private Collision collision;
        public GamePlay()
        {
            stage = new Stage();
            player = new Player(stage);
            enemy = new Enemy(stage);
            characterManager = new CharacterManager(player,stage);
            collision = new Collision(player, characterManager);
        }
        public void Initialize()
        {
            endFlag = false;
            player.Initialize();
            stage.Initialize();
            characterManager.Initialize();
        }
        public void Update()
        {
            player.Update();
            characterManager.Update();
            collision.Update();
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                endFlag = false;
            }
            if (collision.IsEnd() == true)
            {
                endFlag = true;
            }
            if (player.IsGameClear() == true)
            {
                endFlag = true;
            }
        }
        public void Draw(Renderer renderer)
        {
            stage.Draw(renderer);
            player.Draw(renderer);
            //enemy.Draw(renderer);
            characterManager.Draw(renderer);
        }
        public bool IsEnd()
        {
            return endFlag;
        }
        public Scene Next()
        {
            if (player.IsGameClear() == true)
            {
                return Scene.Clear;
            }
            else
            {
                return Scene.GameOver;
            }
        }
    }
}
