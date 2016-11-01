namespace GameEngine.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Models.LevelObjects;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Globals;

    public class FruitFactory
    {
        private static Type[] types = Assembly.GetExecutingAssembly().GetTypes()
       .Where(t => typeof(Fruit).IsAssignableFrom(t) && t != typeof(Fruit))
       .ToArray();

        public Fruit CreateFruit(Texture2D texture)
        {
            try
            {
                Type currentType = types.FirstOrDefault(t => texture.Name.EndsWith(t.Name));
                Fruit fruit = (Fruit)Activator.CreateInstance(currentType, texture, new Rectangle(0, 0, Global.quad_Width, Global.quad_Height));
                return fruit;
            }
            catch (Exception)
            {
                throw new ArgumentNullException("Fruit picture or class not found. Check /Content/FruitImages folder, and make sure the new fruit inherits the base class!");
            }
        }
    }
}