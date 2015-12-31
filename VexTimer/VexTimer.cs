using System;

using Xamarin.Forms;

namespace VexTimer
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			var currentInterval = new Label { Text = "0.0" , XAlign = TextAlignment.Center};
			var slyder = new Slider { 
				Minimum = 0.0,
				Maximum = 6.0,
				Value = 0.0,
			
				
			};

			var start = new Button { Text = "Start", HorizontalOptions = LayoutOptions.Center };

			var counter = new Label { Text = "0.0",
				XAlign = TextAlignment.Center,
			};

			var reset = new Button { Text = "Reset", HorizontalOptions = LayoutOptions.Center };

			var blueElephant = 0.0; //double

			var slideValue = 0.0;

			slyder.ValueChanged += (object sender, ValueChangedEventArgs e) => {
				currentInterval.Text = e.NewValue.ToString("##.##");
				slideValue = e.NewValue;
				System.Diagnostics.Debug.WriteLine(slideValue);

				
			};
				
			//button on click function to run
			start.Clicked += (object sender, EventArgs e) => {
				Xamarin.Forms.Device.StartTimer (TimeSpan.FromMilliseconds(10), () => {
		
					blueElephant = blueElephant + 0.01;

					if (blueElephant >= slideValue )
					{
						blueElephant = 0.0;
					}

					counter.Text = blueElephant.ToString("#0.###");
					return true;

				});
			};

			reset.Clicked += (object sender, EventArgs e) => {
				Xamarin.Forms.Device.StartTimer (TimeSpan.FromMilliseconds(10), () => {
					
					if (blueElephant >= 0.0)
					{
						blueElephant = 0.0;
					}

					return true;
				});
			};


	



				

			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label { Text = "Vex Internal Time", XAlign = TextAlignment.Center},
						counter,
						slyder,
						currentInterval,
						start,
						reset,
					}
				}
			};
		}

		void Reset_Clicked (object sender, EventArgs e)
		{
			
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

