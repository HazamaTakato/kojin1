
using Microsoft.Xna.Framework;

namespace _2DAction
{
    class Load:IScene
    {
        private bool endFlag;
        int timer;

        public Load()
        {

        }
        public void Initialize()
        {
            endFlag = false;
            timer = 0;
        }
        public void Update()
        {

        }
        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture("load", new Vector2(20, 20));

            timer++;
            if (timer > 2)
            {
                endFlag = true;
                renderer.LoadTexture("Bst");
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
