using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundExercise
{
    public class Background
    {
        private Vector2 position;
        private Texture2D texture;
        private float speed;
        public Vector2 Position
        {
            get
            { 
                return  position;
            }
        }
        public Texture2D Texture
        {
            get
            {
                return texture;
            }
        }
        public Background(Texture2D pTexture, float pSpeed)
        {
            texture = pTexture;
            speed = pSpeed;
            position = new Vector2(0,0);

        }
        public void Update()
        {
            position.X += speed;
            if (position.X <= -texture.Width)
                position.X = 0;
        }
    }
}
