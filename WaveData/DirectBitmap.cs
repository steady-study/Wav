using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveData
{
    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap;
        public int[] Bits;
        public bool Disposed;
        public int Height;
        public int Width;
        protected GCHandle BitsHandle;

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new int[width * height];
            BitsHandle = GCHandle.Alloc()
        }
    }
}
