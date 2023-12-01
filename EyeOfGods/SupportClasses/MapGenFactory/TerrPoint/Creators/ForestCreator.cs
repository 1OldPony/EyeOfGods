using EyeOfGods.Models.MapModels;
using EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace EyeOfGods.SupportClasses.MapGenFactory.TerrPoint.Creators
{
    public class ForestCreator : TerrCreator
    {
        List<Rectangle> _forbidPos;
        List<Rectangle> possibPos = new();
        MapScheme _scheme;
        Rectangle finalPos;
        public ForestCreator(MapSchemePoint point, List<Rectangle> forbidPos, MapScheme scheme) : base(point/*, density*/)
        {
            _forbidPos = forbidPos;
            _scheme = scheme;
        }

        public override Terrain Create()
        {
            Random rnd = new Random();

            Forest forest = new(_point.PointNumber);
            int minX = _point.XCoordinate - forest.PointWidth;
            int maxX = _point.XCoordinate + _point.PointWidth;
            int minY = _point.YCoordinate - forest.PointHeight;
            int maxY = _point.YCoordinate + _point.PointHeight;

            //забиваем все возможные позиции СВЕРХУ точки
            for (int i = 0; i <= _point.PointWidth + forest.PointWidth; i++)
            {
                if (minX < 0 || minY < 0)
                {
                    continue;
                }
                Rectangle rect = new(minX + i, minY, forest.PointWidth, forest.PointHeight);
                if (!possibPos.Contains(rect))
                {
                    possibPos.Add(rect);
                }
            }

            //забиваем все возможные позиции СНИЗУ точки
            for (int i = 0; i <= _point.PointWidth + forest.PointWidth; i++)
            {
                if (minX < 0 || maxY > _scheme.MapHeight - forest.PointHeight)
                {
                    continue;
                }
                Rectangle rect = new(minX + i, maxY, forest.PointWidth, forest.PointHeight);
                if (!possibPos.Contains(rect))
                {
                    possibPos.Add(rect);
                }
            }

            //забиваем все возможные позиции СЛЕВА точки
            for (int i = 0; i <= _point.PointHeight + forest.PointHeight; i++)
            {
                if (minX < 0 || minY < 0)
                {
                    continue;
                }
                Rectangle rect = new(minX, minY + i, forest.PointWidth, forest.PointHeight);
                if (!possibPos.Contains(rect))
                {
                    possibPos.Add(rect);
                }
            }

            //забиваем все возможные позиции СПРАВА точки
            for (int i = 0; i <= _point.PointHeight + forest.PointHeight; i++)
            {
                if (maxX > _scheme.MapWidth - forest.PointWidth || minY < 0)
                {
                    continue;
                }
                Rectangle rect = new(maxX, minY + i, forest.PointWidth, forest.PointHeight);
                if (!possibPos.Contains(rect))
                {
                    possibPos.Add(rect);
                }
            }

            //чистим возможные позиции от пересекающихся с уже существующими на карте объектами


            ///// КОСЯК!!! НЕЛЬЗЯ УДАЛЯТЬ ЭЛЕМЕНТЫ ИЗ КОЛЛЕКЦИИ, КОТОРУЮ ТЫ ОБХОДИШЬ, НУЖНА ПРОМЕЖУТОЧНАЯ!
            foreach (var forbPos in _forbidPos)
            {
                foreach (var possPos in possibPos)
                {
                    if (forbPos.IntersectsWith(possPos))
                    {
                        possibPos.Remove(possPos);
                    }
                }
            }
            if (possibPos.Count != 0)
            {
                finalPos = possibPos.ElementAt(rnd.Next(0, possibPos.Count));
                forest.XCoordinate = finalPos.X;
                forest.YCoordinate = finalPos.Y;
                return forest;
            }
            else
            {
                return null;
            }
        }
    }
}
