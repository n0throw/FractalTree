using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using SFML.System;

namespace FractalTree
{
    public class Settings
    {
        public Direction Dir { get; set; }

        public List<float> AngelCoef { get; set; }
        public float StartAngel { get; set; }

        public Vector2f StartPos { get; set; }

        public float Length { get; set; }

        public float LengthCoef { get; set; }

        public float MinLength { get; set; }

        public static Settings GetDefaulthSettings() => new()
        {
            AngelCoef = new()
            {
                55f
            },
            LengthCoef = 0.7f,
            StartAngel = 0f,
            StartPos = new(600, 0),
            Length = 300,
            MinLength = 2f,
            Dir = Direction.Both,
        };

        public static Settings LoadJson(string path)
        {
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                return JsonConvert.DeserializeObject<Settings>(Encoding.Default.GetString(array));
            }
        }
    }
}
