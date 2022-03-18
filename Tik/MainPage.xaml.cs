using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tik
{
    public partial class MainPage : ContentPage
    {
        Button uus_btn, kes_btn, tee_btn;
        Grid grid4X1, grid3X3;
        Image a;
        bool esi=false;
        public MainPage()
        {
            grid4X1 = new Grid
            {
                BackgroundColor = Color.LightBlue,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition{Height=new GridLength(3,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)}
                }
            };
            //Uss_mang();
            uus_btn = new Button
            {
                Text = "Uss Mang"
            };
            uus_btn.Clicked += Uus_btn_Clicked;
            kes_btn = new Button
            {
                Text = "Kes on esimene"
            };
            kes_btn.Clicked += Kes_btn_Clicked;
            tee_btn = new Button
            {
                Text = "Teema"
            };
            
            grid4X1.Children.Add(uus_btn, 0, 1);
            grid4X1.Children.Add(kes_btn, 0, 2);
            grid4X1.Children.Add(tee_btn, 0, 3);
            Content = grid4X1;
        }

        private async void Kes_btn_Clicked(object sender, EventArgs e)
        {
            string e_valik = await DisplayPromptAsync("Kes on esimene", "Tee oma valik 1-cross,2-round", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (e_valik=="1")
            {
                esi = true;
            }
            else
            {
                esi = false;
            }
        }

        public async void Kes_esm()
        {
            string e_valik = await DisplayPromptAsync("Kes on esimene", "Tee oma valik 1-cross,2-round", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (e_valik == "1")
            {
                esi = true;
            }
            else
            {
                esi = false;
            }
        }

        private void Uus_btn_Clicked(object sender, EventArgs e)
        {
            Kes_esm();
            Uss_mang();
        }

        public void Uss_mang()
        {
            grid3X3 = new Grid
            {
                BackgroundColor = Color.Violet,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)}
                }
            };
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    a = new Image { Source = "white2.png" };
                    grid3X3.Children.Add(a, j, i);
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    a.GestureRecognizers.Add(tap);
                }
            }
            grid4X1.Children.Add(grid3X3, 0, 0);
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            var a = (Image)sender;
            var r = Grid.GetRow(a);
            var c = Grid.GetColumn(a);
            if (esi)
            {
                a.Source = "cross.png";
                esi = false;
            }
            else
            {
                a.Source = "round.png";
                esi = true;
            }
            
        }
    }
}
