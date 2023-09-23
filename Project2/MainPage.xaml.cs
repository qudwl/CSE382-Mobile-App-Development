using Windows.Media.Protection.PlayReady;

namespace Project2
{
    public partial class MainPage : ContentPage
    {
        // Picker list
        string[] typesOfNumeralsArr =
        {
            "Decimal",
            "Binary",
            "Octal",
            "Hexadecimal"
        };
        int curBase = 10;
        int curNum = 0;
        Button[] buttons = new Button[16]; // Input buttons array for easier manipulation.
        public MainPage()
        {
            InitializeComponent();
            mainLabel.Text = Convert.ToString(curNum, curBase);
            typeOfNumeral.ItemsSource = typesOfNumeralsArr;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int index = i * 4 + j;
                    buttons[index] = new Button();
                    buttons[index].Clicked += Button_Clicked;
                    buttons[index].Text = Convert.ToString(index, 16).ToUpper();
                    inputGrid.Add(buttons[index], j, i);
                }
            }

            // Set default to decimal
            typeOfNumeral.SelectedIndex = 0;
            DisableButtons(10);
            SetNumbers();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (curNum == 0)
            {
                curNum = Convert.ToInt32((sender as Button).Text, curBase);
                mainLabel.Text = Convert.ToString(curNum, curBase).ToUpper();
            }
            else
            {
                string tmp = Convert.ToString(curNum, curBase) + (sender as Button).Text;
                if (Convert.ToInt64(tmp, curBase) > Int32.MaxValue)
                {
                    DisplayAlert("Error", "Cannot input value larger than int max value", "OK");
                }
                else
                {
                    mainLabel.Text = tmp.ToUpper();
                    curNum = Convert.ToInt32(tmp, curBase);
                }
            }
            SetNumbers();
        }

        private void ChangeBase(object sender, EventArgs e)
        {
            int changedBase = (sender as Picker).SelectedIndex;
            switch (changedBase)
            {
                case 0:
                    curBase = 10;
                    break;
                case 1:
                    curBase = 2;
                    break;
                case 2:
                    curBase = 8;
                    break;
                case 3:
                    curBase = 16;
                    break;
                default:
                    throw new Exception("Wrong input!");
            }

            DisableButtons(curBase);

            curNum = 0;
            mainLabel.Text = Convert.ToString(curNum, curBase).ToUpper();
            SetNumbers();
        }

        private void DisableButtons(int index)
        {
            ResetButtons();
            for (int i = index; i < buttons.Length; i++)
            {
                if (buttons[i] != null) buttons[i].IsEnabled = false;
            }
        }

        private void ResetButtons()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i] != null) buttons[i].IsEnabled = true;
            }
        }

        private void Clear(object sender, EventArgs e)
        {
            curNum = 0;
            mainLabel.Text = Convert.ToString(curNum, curBase);
            SetNumbers();
        }

        private void Delete(object sender, EventArgs e)
        {
            if (curNum >= 1)
            {
                curNum /= curBase;
            }
            mainLabel.Text = Convert.ToString(curNum, curBase).ToUpper();
            SetNumbers();
        }

        private void SetNumbers()
        {
            BinaryLabel.Text = Convert.ToString(curNum, 2);
            OctalLabel.Text = Convert.ToString(curNum, 8);
            DecimalLabel.Text = Convert.ToString(curNum, 10);
            HexadecimalLabel.Text = Convert.ToString(curNum, 16).ToUpper();
        }
    }
}