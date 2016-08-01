using System.Collections.Generic;
using System.IO;

namespace GameEngine.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Models.LevelObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class FruitFactory
    {
        private static Type[] types = Assembly.GetExecutingAssembly().GetTypes()
       .Where(t => typeof(Fruit).IsAssignableFrom(t) && t != typeof(Fruit))
       .ToArray();

        public Fruit CreateFruit(Texture2D texture)
        {
            Type currentType = types.FirstOrDefault(t => texture.Name.EndsWith(t.Name));
            Fruit fruit = (Fruit) Activator.CreateInstance(currentType, texture, 0, 0, new Rectangle(0, 0, 32, 32));
            return fruit;
        }
    }
}