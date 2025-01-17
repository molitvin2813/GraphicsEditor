﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicKurs
{
    [Serializable]
    public class Cylinder : Primitive
    {
        public double Radius { get; private set; }
        public double Height { get; private set; }
        public int SegmentsCount { get; private set; }

        public Cylinder(Point3D basePoint, double radius, double height, int segmentsCount, Color color) : base(basePoint, color)
        {
            Radius = radius;
            Height = height;
            SegmentsCount = Math.Max(segmentsCount, 3);
            UpdatePoints();
        }

        private void UpdatePoints()
        {
            double angle = 360.0 / SegmentsCount;
            double sin = Math.Sin(MathHelpers.FromDegreesToRadians(angle));
            double cos = Math.Cos(MathHelpers.FromDegreesToRadians(angle));

            Point3D[] points = new Point3D[SegmentsCount + 1];
            points[0] = new Point3D(-Radius, 0, 0);
            Faces.Clear();

            for (int i = 1; i <= SegmentsCount; ++i)
            {
                double x = points[i - 1].X * cos - points[i - 1].Z * sin;
                double z = points[i - 1].X * sin + points[i - 1].Z * cos;
                points[i] = new Point3D(x, 0, z);
                if (i > 0)
                {
                    Faces.Add(new Face(new Point3D[] {
                        new Point3D(points[i - 1].X, 0, points[i - 1].Z),
                        new Point3D(points[i].X, 0, points[i].Z),
                        new Point3D(0, 0, 0)
                    }));
                    Faces.Add(new Face(new Point3D[] {
                        new Point3D(points[i - 1].X, Height, points[i - 1].Z),
                        new Point3D(points[i].X, Height, points[i].Z),
                        new Point3D(0, Height, 0)
                    }));
                    Faces.Add(new Face(new Point3D[] {
                        new Point3D(points[i - 1].X, Height, points[i - 1].Z),
                        new Point3D(points[i].X, Height, points[i].Z),
                        new Point3D(points[i - 1].X, 0, points[i - 1].Z)
                    }));
                    Faces.Add(new Face(new Point3D[] {
                        new Point3D(points[i - 1].X, 0, points[i - 1].Z),
                        new Point3D(points[i].X, 0, points[i].Z),
                        new Point3D(points[i].X, Height, points[i].Z)
                    }));
                }
            }
        }

        public void ModifyRadius(double radius)
        {
            Radius = radius;
            UpdatePoints();
        }

        public void ModifyHeight(double height)
        {
            Height = height;
            UpdatePoints();
        }

        public void ModifyBasePoint(Point3D basePoint)
        {
            BasePoint = basePoint;
            UpdatePoints();
        }
    }
}
