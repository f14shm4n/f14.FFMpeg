using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FFMpeg.Arguments.Atoms
{
    public class ScaleArgument : IArgument
    {
        private readonly int _width;
        private readonly int _height;  

        public ScaleArgument(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public string GetStringValue()
        {
            return $"-vf scale={_width}:{_height}";
        }
    }
}
