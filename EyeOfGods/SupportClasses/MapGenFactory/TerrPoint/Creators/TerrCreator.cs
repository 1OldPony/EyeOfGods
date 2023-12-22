using EyeOfGods.Migrations;
using EyeOfGods.Models.MapModels;
using EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Products;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Creators
{
    public abstract class TerrCreator
    {
        private protected InterestPoint _point;
        public List<Rectangle> _forbidPos;
        List<Rectangle> allPossibPos = new();
        private protected MapScheme _scheme;
        public TerrCreator(InterestPoint point, List<Rectangle> forbidPos, MapScheme scheme)
        {
            _point = point;
            _forbidPos = forbidPos;
            _scheme = scheme;
        }
        abstract public Terrain Create();

        public List<Rectangle> CalcPossiblePositions(Terrain forThisPoint) 
        {
            int minX = _point.XCoordinate - forThisPoint.PointWidth;
            int maxX = _point.XCoordinate + _point.PointWidth;
            int minY = _point.YCoordinate - forThisPoint.PointHeight;
            int maxY = _point.YCoordinate + _point.PointHeight;
            Rectangle rect;

            //забиваем все возможные позиции СВЕРХУ точки
            for (int i = 0; i <= _point.PointWidth + forThisPoint.PointWidth; i++)
            {
                if (minY < 1 || minX + i < 1 || minX + i > _scheme.MapWidth + 1 - forThisPoint.PointWidth)
                {
                    continue;
                }
                rect = new(minX + i, minY, forThisPoint.PointWidth, forThisPoint.PointHeight);
                if (!allPossibPos.Contains(rect))
                {
                    allPossibPos.Add(rect);
                }
            }

            //забиваем все возможные позиции СНИЗУ точки
            for (int i = 0; i <= _point.PointWidth + forThisPoint.PointWidth; i++)
            {
                if (maxY > _scheme.MapHeight + 1 - forThisPoint.PointHeight || minX + i < 1 || minX + i > _scheme.MapWidth + 1 - forThisPoint.PointWidth)
                {
                    continue;
                }
                rect = new(minX + i, maxY, forThisPoint.PointWidth, forThisPoint.PointHeight);
                if (!allPossibPos.Contains(rect))
                {
                    allPossibPos.Add(rect);
                }
            }

            //забиваем все возможные позиции СЛЕВА точки
            for (int i = 0; i <= _point.PointHeight + forThisPoint.PointHeight; i++)
            {
                if (minX < 1 || minY + i < 1 || minY + i > _scheme.MapHeight + 1 - forThisPoint.PointHeight)
                {
                    continue;
                }
                rect = new(minX, minY + i, forThisPoint.PointWidth, forThisPoint.PointHeight);
                if (!allPossibPos.Contains(rect))
                {
                    allPossibPos.Add(rect);
                }
            }

            //забиваем все возможные позиции СПРАВА точки
            for (int i = 0; i <= _point.PointHeight + forThisPoint.PointHeight; i++)
            {
                if (maxX > _scheme.MapWidth+ 1 - forThisPoint.PointWidth || minY + i < 1 || minY + i > _scheme.MapHeight + 1 - forThisPoint.PointHeight)
                {
                    continue;
                }
                rect = new(maxX, minY + i, forThisPoint.PointWidth, forThisPoint.PointHeight);
                if (!allPossibPos.Contains(rect))
                {
                    allPossibPos.Add(rect);
                }
            }

            //чистим возможные позиции от пересекающихся с уже существующими на карте объектами
            List<Rectangle> finPossPos = new();

            foreach (var possPos in allPossibPos)
            {
                bool intersects = false;
                foreach (var forbPos in _forbidPos)
                {
                    if (possPos.IntersectsWith(forbPos))
                    {
                        intersects = true;
                        break;
                    }
                }

                if (!intersects)
                {
                    finPossPos.Add(possPos);
                }
            }

            return finPossPos;
        }
    }
}