using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace FractalTree
{
    class Game : Transformable, Drawable
    {
        private readonly ICreator creator;
        private readonly List<Vertex[]> vertexs;

        public Game(ICreator creator)
        {
            this.creator = creator;
            vertexs = this.creator.CreateFractal();
        }

        public void Draw(RenderTarget target, RenderStates states) => vertexs.ForEach(vertex => DrawLine(target, states, vertex, Color.Cyan));

        private static void DrawLine(RenderTarget target, RenderStates states, Vertex[] vertex, Color color)
        {
            vertex = new Vertex[]
            {
                new Vertex()
                {
                    Position = new Vector2f(vertex[0].Position.X, target.GetView().Size.Y - vertex[0].Position.Y),
                    Color = color,
                },
                new Vertex()
                {
                    Position = new Vector2f(vertex[1].Position.X, target.GetView().Size.Y - vertex[1].Position.Y),
                    Color = color
                }
            };

            target.Draw(vertex, PrimitiveType.Lines, states);
        }
    }
}
