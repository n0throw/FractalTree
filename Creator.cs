using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;

namespace FractalTree
{
    public class Creator : ICreator
    {
        private List<Vertex[]> vertexs;
        private readonly Settings settings;

        public Creator(Settings settings) => this.settings = settings;

        public List<Vertex[]> CreateFractal()
        {
            vertexs = new();
            Create(settings.StartPos, settings.Length, settings.StartAngel);
            return vertexs;
        }

        private void Create(Vector2f start, float len, float angel)
        {
            Vector2f end = new(start.X + len * (float)Math.Sin(RadToDeg(angel)), start.Y + len * (float)Math.Cos(RadToDeg(angel)));

            vertexs.Add(new Vertex[]
                {
                    new Vertex(start),
                    new Vertex(end)
                });

            if (len >= settings.MinLength)
            {
                foreach (var k in settings.AngelCoef)
                {
                    if (settings.Dir == Direction.Both)
                    {
                        Create(end, len * settings.LengthCoef, angel - k);
                        Create(end, len * settings.LengthCoef, angel + k);
                    }
                    else
                        Create(end, len * settings.LengthCoef, angel + (settings.Dir == Direction.Left ? -k : k));
                }
            }
        }
        private static double RadToDeg(double angel) => angel * Math.PI * 2 / 360;
    }
}
