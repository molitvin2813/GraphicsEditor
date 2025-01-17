﻿using System;

namespace GraphicKurs
{
    [Serializable]
    public class PrimitiveWithName
    {
        public Primitive Primitive { get; set; }
        public string Name { get; set; }

        public PrimitiveWithName() { }

        public PrimitiveWithName(Primitive primitive, string name)
        {
            Primitive = primitive;
            Name = name;
        }

        public double ScaleX { get; private set; } = 1.0;
        public double ScaleY { get; private set; } = 1.0;
        public double ScaleZ { get; private set; } = 1.0;
        public int AngleX { get; set; } = 0;
        public int AngleY { get; set; } = 0;
        public int AngleZ { get; set; } = 0;
        private double maxLength = 0;
        public double MaxLength
        {
            get
            {
                if (maxLength == 0)
                {
                    double result = 0;
                    foreach (Face face in Primitive.Faces)
                    {
                        foreach (Point3D point in face.Points)
                        {
                            double length = point.Length;
                            result = Math.Max(length, result);
                        }
                    }
                    maxLength = result * Math.Max(Math.Max(ScaleX, ScaleY), ScaleZ);
                }
                return maxLength;
            }
        }
        public void SetScale(double scaleX, double scaleY, double scaleZ)
        {
            ScaleX = scaleX;
            ScaleY = scaleY;
            ScaleZ = scaleZ;
            maxLength = 0;
        }

        public Matrix GetModificationMatrix()
        {
            Matrix matrix = ModificationMatrix.NewIdentityMatrix(4);
            matrix = matrix.Multiply(ModificationMatrix.NewScaleMatrix(ScaleX, ScaleY, ScaleZ));
            matrix = matrix.Multiply(ModificationMatrix.NewRotateXMatrix(MathHelpers.FromDegreesToRadians(AngleX)));
            matrix = matrix.Multiply(ModificationMatrix.NewRotateYMatrix(MathHelpers.FromDegreesToRadians(AngleY)));
            matrix = matrix.Multiply(ModificationMatrix.NewRotateZMatrix(MathHelpers.FromDegreesToRadians(AngleZ)));
            return matrix;
        }

    }
}
