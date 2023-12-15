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
        private protected MapSchemePoint _point;
        List<Rectangle> _forbidPos;
        List<Rectangle> allPossibPos = new();
        MapScheme _scheme;
        public TerrCreator(MapSchemePoint point, List<Rectangle> forbidPos, MapScheme scheme)
        {
            _point = point;
            _forbidPos = forbidPos;
            _scheme = scheme;
        }
        abstract public Terrain Create();

        public List<Rectangle> GenPossiblePositions(Terrain basePoint) 
        {
            int minX = _point.XCoordinate - basePoint.PointWidth;
            int maxX = _point.XCoordinate + _point.PointWidth;
            int minY = _point.YCoordinate - basePoint.PointHeight;
            int maxY = _point.YCoordinate + _point.PointHeight;
            Rectangle rect;

            //забиваем все возможные позиции СВЕРХУ точки
            for (int i = 0; i <= _point.PointWidth + basePoint.PointWidth; i++)
            {
                if (minX < 0 || minY < 0)
                {
                    continue;
                }
                rect = new(minX + i, minY, basePoint.PointWidth, basePoint.PointHeight);
                if (!allPossibPos.Contains(rect))
                {
                    allPossibPos.Add(rect);
                }
            }

            //забиваем все возможные позиции СНИЗУ точки
            for (int i = 0; i <= _point.PointWidth + basePoint.PointWidth; i++)
            {
                if (minX < 0 || maxY > _scheme.MapHeight - basePoint.PointHeight)
                {
                    continue;
                }
                rect = new(minX + i, maxY, basePoint.PointWidth, basePoint.PointHeight);
                if (!allPossibPos.Contains(rect))
                {
                    allPossibPos.Add(rect);
                }
            }

            //забиваем все возможные позиции СЛЕВА точки
            for (int i = 0; i <= _point.PointHeight + basePoint.PointHeight; i++)
            {
                if (minX < 0 || minY < 0)
                {
                    continue;
                }
                rect = new(minX, minY + i, basePoint.PointWidth, basePoint.PointHeight);
                if (!allPossibPos.Contains(rect))
                {
                    allPossibPos.Add(rect);
                }
            }

            //забиваем все возможные позиции СПРАВА точки
            for (int i = 0; i <= _point.PointHeight + basePoint.PointHeight; i++)
            {
                if (maxX > _scheme.MapWidth - basePoint.PointWidth || minY < 0)
                {
                    continue;
                }
                rect = new(maxX, minY + i, basePoint.PointWidth, basePoint.PointHeight);
                if (!allPossibPos.Contains(rect))
                {
                    allPossibPos.Add(rect);
                }
            }

            //чистим возможные позиции от пересекающихся с уже существующими на карте объектами
            List<Rectangle> finPossPos = new();
            foreach (var forbPos in _forbidPos)
            {
                foreach (var possPos in allPossibPos)
                {
                    if (!forbPos.IntersectsWith(possPos))
                    {
                        finPossPos.Add(possPos);
                    }
                }
            }

            return finPossPos;
        }
    }
}