using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MVVM.ViewModels;
public class SimpleMultiplierViewModel : INotifyPropertyChanged {
	double multiplicand, multiplier, product;
    int num1, num2, sum;

    public event PropertyChangedEventHandler PropertyChanged;

	public SimpleMultiplierViewModel() {
		Multiplicand = 0.5;
		Multiplier = 0.5;
        Num1 = 0;
        Num2 = 0;
	}
	public double Multiplicand {
		set {
			if (multiplicand != value) {
				multiplicand = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Multiplicand"));
				UpdateProduct();
			}
		}
		get {
			return multiplicand;
		}
	}
	public double Multiplier {
		set {
			if (multiplier != value) {
				multiplier = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Multiplier"));
				UpdateProduct();
			}
		}
		get {
			return multiplier;
		}
	}

	public double Product {
		protected set {
			if (product != value) {
				product = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Product"));
			}
		}
		get {
			return product;
		}
	}
	void UpdateProduct() {
		Product = Multiplicand * Multiplier;
	}
    

    public int Num1
    {
        set
        {
            if (num1 != value)
            {
                num1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Num1"));
                UpdateSum();
            }
        }
        get { return num1; }
    }

    public int Num2
    {
        set
        {
            if (num2 != value)
            {
                num2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Num2"));
                UpdateSum();
            }
        }
        get { return num2; }
    }

    public int Sum
    {
        set
        {
            if (sum != value)
            {
                sum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sum"));
            }
        }
        get { return sum; }
    }

    void UpdateSum()
    {
        Sum = Num1 + Num2;
    }
}