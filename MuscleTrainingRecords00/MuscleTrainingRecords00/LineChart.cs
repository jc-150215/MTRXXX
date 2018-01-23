﻿ using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Xamarin.Forms;
using MuscleTrainingRecords;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;
using System;
using System.Diagnostics;

namespace MuscleTrainingRecords00
{
    class LineChart
    {
        public PlotModel Model { get; private set; }

        public LineChart()
        {
            
            DataPoint[] BWeightList = getItemList();

            this.Model = new PlotModel { Title = "" };




            var BweightLine = new LineSeries　//体重線
            {
                Title = "体重",
                StrokeThickness = 1,

                MarkerType = MarkerType.Circle,

                MarkerStroke = OxyColors.Blue,

                MarkerFill = OxyColors.SkyBlue,

                DataFieldX = DateTime.Now.ToString(),
               // DataFieldX = "Date",
                DataFieldY = "Value",

                LineStyle = LineStyle.Automatic,
                

               

            };
            BweightLine.Color = OxyColors.Red;

            foreach (DataPoint dp in BWeightList)
            {
                BweightLine.Points.Add(dp);
                BweightLine.MarkerType = MarkerType.Circle;
            }
       
            Model.Series.Add(BweightLine);

            DataPoint[] BFattList = getBFatList();


            var BfatLine = new LineSeries    //体脂肪線
            {
                Title = "体脂肪率",
                StrokeThickness = 1,

                MarkerType = MarkerType.Circle, 

                MarkerStroke = OxyColors.GreenYellow,

                MarkerFill = OxyColors.SkyBlue,

                DataFieldX = DateTime.Now.ToString(),

                DataFieldY = "Value",

                LineStyle = LineStyle.Automatic,

            };

            BfatLine.Color = OxyColors.Blue;

            foreach (DataPoint dp in BFattList)
            {
                BfatLine.Points.Add(dp);
               

            }
           
            Model.Series.Add(BfatLine);


            var axisY = new LinearAxis() //Y軸　線
            {
                Title = "体重(kg)　体脂肪率(%)",
                IsZoomEnabled = false,
                Position = AxisPosition.Left,
                Maximum = 150,
                Minimum = 50,
                MajorStep = 10,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                ExtraGridlines = new double[] { 1, 2, 3, 8, 9, 10 },
                ExtraGridlineThickness = 3,
                ExtraGridlineColor = OxyColors.SkyBlue,
                
                
                



            };
            Model.Axes.Add(axisY);

            /*
            var axisX = new LinearAxis() //Y軸　線
            {
                Title = "体脂肪率(%)",
                IsZoomEnabled = false,
                Position = AxisPosition.Left,
                Maximum = 40,
                Minimum = 20,
                MajorStep = 1,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot,
                ExtraGridlines = new double[] { 1, 2, 3, 8, 9, 10 },
                ExtraGridlineThickness = 3,
                ExtraGridlineColor = OxyColors.SkyBlue,






            };
            Model.Axes.Add(axisX);
            */



         
                        var startDate = DateTime.Today.AddDays(-10);
                        var endDate = DateTime.Today;

                        var minValue = DateTimeAxis.ToDouble(startDate);
                        var maxValue = DateTimeAxis.ToDouble(endDate);


                        Model.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, Minimum = minValue, Maximum = maxValue, StringFormat = "M/d" }); //X軸日付
            




        }

        private static DataPoint[] getItemList()
        {
            TodoItemDatabase itemDataBase = TodoItemDatabase.getDatabase();
            Task<List<TodoItem>> taskItemList = itemDataBase.GetItemsAsync();
            List<TodoItem> itemList = taskItemList.Result;
            DataPoint[] points = new DataPoint[itemList.Count];
            

            int i = 0;

            double s = DateTimeAxis.ToDouble(DateTime.Today);


            foreach (TodoItem item in itemList)
            {
             
                points[i++] = new DataPoint(s, item.Bweight);// X軸　Y軸

            }
            return points;
        }


       private static DataPoint[] getBFatList()
        {
            TodoItemDatabase itemDataBase = TodoItemDatabase.getDatabase();
            Task<List<TodoItem>> taskItemList = itemDataBase.GetItemsAsync();
            List<TodoItem> itemList = taskItemList.Result;
            DataPoint[] points = new DataPoint[itemList.Count];
            
            int i = 0;
            double s = DateTimeAxis.ToDouble(DateTime.Today);
            foreach ( TodoItem item in itemList)
            {
                points[i++] = new DataPoint(s, item.Bfat);//　　X軸　Y軸
            }
            return points;
        }
    }
}