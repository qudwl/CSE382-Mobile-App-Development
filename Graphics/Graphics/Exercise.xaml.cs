namespace Graphics;
using Graphics.Drawables;
public partial class Exercise : ContentPage
{
	
	public Exercise()
	{
		InitializeComponent();
	}

    void plotBtn_Clicked(System.Object sender, System.EventArgs e)
	{
		ExerciseDrawable exercise = (ExerciseDrawable)graphics.Drawable;
		Console.WriteLine("hello");
        exercise.Labels = labels.Text.Split(",");
        exercise.Data = data.Text.Split(',').Select(x => int.Parse(x)).ToArray();
		graphics.Invalidate();
    }
}
