using System.Collections.Generic;

using SFML.Graphics;

namespace FractalTree
{
    interface ICreator
    {
        public List<Vertex[]> CreateFractal();
    }
}
