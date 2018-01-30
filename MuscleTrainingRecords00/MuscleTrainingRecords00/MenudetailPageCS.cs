using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MuscleTrainingRecords00
{
    public class MenudetailPageCS : ContentPage
    {
        public MenudetailPageCS()
        {
            Title = "メニュー詳細";
            Content = new StackLayout
            
            {
                Children = {
                    new Label {
                     Text = "Welcome to メニュー詳細Page!",
                     HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }
    }
}