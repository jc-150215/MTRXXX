using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MuscleTrainingRecords00
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenudetaliPage : ContentPage
    {
        string t;

        //今日の日付
        DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        public MenudetaliPage(string m, string d, string i)//String m
        {
            InitializeComponent();


            Transition.Text = m.Trim();

            Description.Text = d;

            Image1.Source = new FileImageSource { File = i};

            t = m;
        }

        private void addItemButton_Clicked(object sender, EventArgs e)
        {

            RecordsModel.InsertRe(1,t,0,0,0,now);

            Navigation.PushAsync(new RecordListPage());

        }

        /*public MenudetaliPage(String l)
        {
        this.l = l;
        }*/
    }
}