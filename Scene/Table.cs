using System;
using System.Drawing;

namespace GraphicKurs
{
    [Serializable]
    public class Table : SceneObject
    {
        public double RightVolumeControllerStandRadius { get; set; } = 10;
        public double RightVolumeControllerWidestPartRadius { get; set; } = 15;
        public double RightVolumeControllerStripeRadius { get; set; } = 13;
        public double LeftVolumeControllerStandRadius { get; set; } = 10;
        public double LeftVolumeControllerWidestPartRadius { get; set; } = 15;
        public double LeftVolumeControllerStripeRadius { get; set; } = 13;
        public double ControlButtonsHeight { get; set; } = 5;
        public double ControlButtonsWidth { get; set; } = 7;
        public int SphereCount { get; set; } = 1;
        public int PlayBackButtonsCount { get; set; } = 2;

        public Table() { }

        public Table(string name) : base(name)
        {
            UpdateObject();
        }

        public void UpdateObject()
        {
            Primitives.Clear();

            var basis = new PrimitiveWithName(
                new BoxTriangle(new Point3D(-25, 0, -35), 30, 5, 7.5, Color.SaddleBrown),
                "Basis"
                ); // раз все равно примитив по умолчанию с именем, почему бы не задать ему имя.
            Primitives.Add(basis);
            basis = new PrimitiveWithName(
                new BoxTriangle(new Point3D(20, 0, -35), 30, 5, 7.5, Color.Blue),
                "Basis"
                );
            Primitives.Add(basis);
            basis = new PrimitiveWithName(
                new BoxTriangle(new Point3D(-25, 0, 35), 30, 5, 7.5, Color.Green),
                "Basis"
                );
            Primitives.Add(basis);
            basis = new PrimitiveWithName(
               new BoxTriangle(new Point3D(20, 0, 35), 30, 5, 7.5,Color.Red),
               "Basis"
               );
            Primitives.Add(basis);


            var height = 5 / 2;
            basis = new PrimitiveWithName(
              new Box(new Point3D(0, 12, 0), 50, 10 , 75, Color.Coral),
              "Basis"
              );
            Primitives.Add(basis);



            basis = new PrimitiveWithName(
              new Sphere(new Point3D(-25+ height, 9, -35), 5, 8, Color.Coral),
              "Basis"
              );
            Primitives.Add(basis);
            basis = new PrimitiveWithName(
             new Sphere(new Point3D(20+ height, 9, -35), 5, 8, Color.Coral),
             "Basis"
             );
            Primitives.Add(basis);
            basis = new PrimitiveWithName(
             new Sphere(new Point3D(-25+ height, 9, 35), 5, 8, Color.Coral),
             "Basis"
             );
            Primitives.Add(basis);
            basis = new PrimitiveWithName(
             new Sphere(new Point3D(20+ height, 9, 35), 5, 8, Color.Coral),
             "Basis"
             );
            Primitives.Add(basis);


        }
    }
}
