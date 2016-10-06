using ATT.Evolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATT.Evolution.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Grid universe;

        public MainWindow()
        {
            InitializeComponent();
            this.DrawBeings();
        }

        private void DrawBeings()
        {
            Entities.Evolution evolution = new Entities.Evolution(10, 3000, 9);
            evolution.Start();
            universe = this.Universe;
            double startX = 150;
            double startY = 150;

            this.DrawBeing(evolution.Beings[0], startX, startY);

            for (int index = 2990; index < evolution.Beings.Count; index++)
            {
                this.DrawBeing(evolution.Beings[index], startX, startY);
                startX += 100;
            }
        }

        private void DrawBeing(Being being, double startCoordX, double startCoordY)
        {
            int cellCount = 0;
            int count = 0;
            foreach (Cell cell in being.Cells)
            {
                cellCount++;

                Line cellLine = new Line();
                cellLine.Stroke = Brushes.LightSteelBlue;
                cellLine.X1 = startCoordX;
                cellLine.Y1 = startCoordY;
               
                var angleGenes = cell.Genes.Where(g => g.GeneType == GeneType.Angle);

                if (startCoordX - angleGenes.ToList()[count].Value < 0)
                {
                    cellLine.X2 = startCoordX + angleGenes.ToList()[count].Value;
                }
                else
                {
                    cellLine.X2 = startCoordX - angleGenes.ToList()[count].Value;
                }

                if (count == angleGenes.Count() - 1) { count = 0; }

                var lengthGenes = cell.Genes.Where(g => g.GeneType == GeneType.Length);
                int lineLength = lengthGenes.Sum(g => g.Value) + (count * 2);

                if (startCoordY - lineLength < 0)
                {
                    cellLine.Y2 = startCoordY + lineLength;
                }
                else
                {
                    cellLine.Y2 = startCoordY - lineLength;
                }

                cellLine.HorizontalAlignment = HorizontalAlignment.Left;
                cellLine.VerticalAlignment = VerticalAlignment.Center;

                var thicknessGenes = cell.Genes.Where(g => g.GeneType == GeneType.Thickness);
                cellLine.StrokeThickness = (double)(thicknessGenes.Sum(g => g.Value) / 2);
                universe.Children.Add(cellLine);

                startCoordX = cellLine.X2;
                startCoordY = cellLine.Y2;

                count++;
            }
        }
    }
}
