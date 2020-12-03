using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DAction
{
    class SceneManager
    {
        private IScene currentScene = null;//現在のシーン

        private Dictionary<Scene, IScene> scenes = new Dictionary<Scene, IScene>();

        public SceneManager()
        {

        }

        public void Update()
        {
            currentScene.Update();//現在
            //シーン終了ならば
            if (currentScene.IsEnd() == true)
            {
                Scene next = currentScene.Next();
                //次のシーンへ切り替える
                Change(next);
            }
        }
        public void Draw(Renderer renderer)
        {
            if (currentScene == scenes[Scene.GameOver] || currentScene == scenes[Scene.Clear])
            {
                scenes[Scene.GamePlay].Draw(renderer);
            }
            currentScene.Draw(renderer);
        }
        public void Add(Scene name,IScene scene)
        {
            scenes[name] = scene;
        }
        public void Change(Scene name)
        {
            currentScene = scenes[name];
            currentScene.Initialize();
        }
    }
}
