﻿using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace Voyage_Engine.Game_Engine.TileMap
{
    public class TileMap : IEnumerable<Tile>
    {
        private Tile[,] _gride;
        private int width;
        private int height;

        public TileMap(int width, int height)
        {
            this.width = width;
            this.height = height;
            _gride = new Tile[width, height];
        }

        public Tile this[int x, int y]
        {
            get { return _gride[x, y]; }
            set { _gride[x, y] = value; }
        }

        public IEnumerator<Tile> GetEnumerator()
        {
            for (int width = 0; this.width < width; width++)
            {
                for (int height = 0;this.height < height; height++)
                {
                    yield return _gride[width, height];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Tile> GetEnumerator(int row, int col)
        {
            int minWidth = row - 1;
            int minHeight = col - 1;
            int maxWidth = row + 1;
            int maxHeight = col + 1;

            int currentRow = maxWidth;
            int currentCol = maxHeight;

            bool isGoingRight = true;
            bool isGoingDown = false;

            while (currentRow >= minWidth && currentRow <= maxWidth &&
                currentCol >= minHeight && currentCol <= maxHeight)
            {
                yield return _gride[currentRow, currentCol];

                if (isGoingRight)
                {
                    currentCol++;
                    if (currentCol > maxHeight)
                    {
                        isGoingRight = false;
                        isGoingDown = true;
                        currentCol--;
                        currentRow++;
                    }
                }
                else if (isGoingDown)
                {
                    currentRow++;
                    if (currentRow > maxWidth)
                    {
                        isGoingRight = true;
                        isGoingDown = false;
                        currentRow--;
                        currentCol--;
                    }
                }
            }
        }
    }
    //public class Tilemap : IEnumerable<Tile> 
    //    {
    //        private Tile[,] _gride;
    //        private int width;
    //        private int height;

    //        public Tilemap(int width, int height)
    //        {
    //            this.width = width;
    //            this.height = height;
    //             _gride = new Tile[width, height];
    //        }

    //        public Tile this[int x, int y]
    //        {
    //            get { return _gride[x, y]; }
    //            set { _gride[x, y] = value; }
    //        }

    //        public IEnumerator<Tile> GetEnumerator()
    //        {
    //            for (int x = 0; x < width; x++)
    //            {
    //                for (int y = 0; y < height; y++)
    //                {
    //                    yield return _gride[x, y];
    //                }
    //            }
    //        }

    //        IEnumerator IEnumerable.GetEnumerator()
    //        {
    //            return GetEnumerator();
    //        }
    //    }

}
