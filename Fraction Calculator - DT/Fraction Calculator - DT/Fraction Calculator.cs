using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fraction_Calculator___DT
{
    public partial class formFractionCalculator : Form
    {
        public formFractionCalculator()
        {
            InitializeComponent();
        }
        public struct Fraction //declare structure with numerator and denominator as encapsulated variables
        {
            public int num;
            public int denom;
        }
        public int FindGCF(Fraction FResult) //method to find Greatest Common Factor
        {
            int iRemainder, a, b;
            a = FResult.num;
            b = FResult.denom;
            while(b != 0) //using the Euclidean algorithm; repeat while b does not equal 0, stop when zero is remainder
            {
                iRemainder = a % b; //find the remainder between two numbers
                a = b; //replace the dividend with divisor
                b = iRemainder; //replace divisor with recently found remainder
            }
            return a; //a will get you the GCF, therefore return
        }
        public void ClearAll() //method to clear all textboxes
        {
            txtNum1.Clear();
            txtDenom1.Clear();
            txtNum2.Clear();
            txtDenom2.Clear();
            txtResultNum.Clear();
            txtResultDenom.Clear();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Fraction F1, F2, FResult;
                int iGCF; 

                F1.num = Convert.ToInt32(txtNum1.Text);
                F1.denom = Convert.ToInt32(txtDenom1.Text);
                F2.num = Convert.ToInt32(txtNum2.Text);
                F2.denom = Convert.ToInt32(txtDenom2.Text);
                if ((F1.denom == 0) || (F2.denom == 0)) //denominator in either fraction cannot equal 0
                {
                    MessageBox.Show("Denominator cannot equal 0");
                    ClearAll();
                    return;
                }
                if ((F1.denom == F2.denom)) //denominator is the same thus no GCD is needed
                {
                    FResult.num = F1.num + F2.num;
                    FResult.denom = F1.denom;
                    iGCF = FindGCF(FResult); //find GCF of final fraction
                    FResult.num = FResult.num / iGCF; //reduce numertaor by dividing by GCF
                    FResult.denom = FResult.denom / iGCF; //redcue denominator by dividing the GCF
                }
                else //denominator is not the same
                {
                    F1.num = F1.num * F2.denom; //cross multiply first, then add
                    F2.num = F2.num * F1.denom;
                    F1.denom = F1.denom * F2.denom;
                    FResult.num = F1.num + F2.num;
                    FResult.denom = F1.denom;
                    iGCF = FindGCF(FResult); //find the GCF of the final fraction
                    FResult.num = FResult.num / iGCF; //reduce the numerator by dividing by GCF
                    FResult.denom = FResult.denom / iGCF; //reduce the denominator by dividing by GCF
                }
                if (FResult.denom < 0) //denominator is a negative number
                {
                    FResult.denom = -FResult.denom; //turn into positive by cancelling the negative with a negative
                    FResult.num = -FResult.num; //add the negative sign to the numerator instead
                }
                txtResultNum.Text = FResult.num.ToString(); 
                txtResultDenom.Text = FResult.denom.ToString(); 
            }
            catch
            {
                MessageBox.Show("Please enter a number");
                ClearAll();
                return;
            }
        }
        private void btnMultiply_Click(object sender, EventArgs e)
        {
            try
            {
                Fraction F1, F2, FResult;
                int iGCF;

                F1.num = Convert.ToInt32(txtNum1.Text);
                F1.denom = Convert.ToInt32(txtDenom1.Text);
                F2.num = Convert.ToInt32(txtNum2.Text);
                F2.denom = Convert.ToInt32(txtDenom2.Text);
                if ((F1.denom == 0) || (F2.denom == 0)) //denominator cannot equal 0
                {
                    MessageBox.Show("Denominator cannot equal 0");
                    ClearAll();
                    return;
                }
                FResult.num = F1.num * F2.num; 
                FResult.denom = F1.denom * F2.denom;
                iGCF = FindGCF(FResult); //find GCF of final fraction
                FResult.num = FResult.num / iGCF; //reduce numertaor by dividing by GCF
                FResult.denom = FResult.denom / iGCF; //redcue denominator by dividing the GCF
                if (FResult.denom < 0) //denominator is a negative number
                {
                    FResult.denom = -FResult.denom; //turn into positive by cancelling the negative with a negative
                    FResult.num = -FResult.num; //add the negative sign to the numerator instead
                }
                txtResultNum.Text = FResult.num.ToString();
                txtResultDenom.Text = FResult.denom.ToString();
            }
            catch
            {
                MessageBox.Show("Please enter a number");
                ClearAll();
                return;
            }
        }
        private void btnSubtract_Click(object sender, EventArgs e)
        {
            try
            {
                Fraction F1, F2, FResult;
                int iGCF;

                F1.num = Convert.ToInt32(txtNum1.Text);
                F1.denom = Convert.ToInt32(txtDenom1.Text);
                F2.num = Convert.ToInt32(txtNum2.Text);
                F2.denom = Convert.ToInt32(txtDenom2.Text);
                if ((F1.denom == 0) || (F2.denom == 0)) //denominator cannot equal 0
                {
                    MessageBox.Show("Denominator cannot equal 0");
                    ClearAll();
                    return;
                }
                if ((F1.denom == F2.denom)) //denominator is the same thus no GCD is needed
                {
                    FResult.num = F1.num - F2.num;
                    FResult.denom = F1.denom;
                    iGCF = FindGCF(FResult); //find GCF of final fraction
                    FResult.num = FResult.num / iGCF; //reduce numertaor by dividing by GCF
                    FResult.denom = FResult.denom / iGCF; //redcue denominator by dividing the GCF
                }
                else
                {
                    F1.num = F1.num * F2.denom; //cross multiply first, then subtract
                    F2.num = F2.num * F1.denom;
                    F1.denom = F1.denom * F2.denom;
                    FResult.num = F1.num - F2.num;
                    FResult.denom = F1.denom;
                    iGCF = FindGCF(FResult); //find GCF of final fraction
                    FResult.num = FResult.num / iGCF; //reduce numertaor by dividing by GCF
                    FResult.denom = FResult.denom / iGCF; //redcue denominator by dividing the GCF
                }
                if (FResult.denom < 0) //denominator is a negative number
                {
                    FResult.denom = -FResult.denom; //turn into positive by cancelling the negative with a negative
                    FResult.num = -FResult.num; //add the negative sign to the numerator instead
                }
                txtResultNum.Text = FResult.num.ToString();
                txtResultDenom.Text = FResult.denom.ToString();

            }
            catch
            {
                MessageBox.Show("Please enter a number");
                ClearAll();
                return;
            }
        }
        private void btnDivide_Click(object sender, EventArgs e)
        {
            try
            {
                Fraction F1, F2, FResult;
                int iGCF;

                F1.num = Convert.ToInt32(txtNum1.Text);
                F1.denom = Convert.ToInt32(txtDenom1.Text);
                F2.num = Convert.ToInt32(txtNum2.Text);
                F2.denom = Convert.ToInt32(txtDenom2.Text);
                if ((F1.denom == 0) || (F2.denom == 0)) //denominator cannot equal 0
                {
                    MessageBox.Show("Denominator cannot equal 0"); 
                    ClearAll();
                    return;
                }
                FResult.num = F1.num * F2.denom; //cross multiply
                FResult.denom = F2.num * F1.denom;
                iGCF = FindGCF(FResult); //find GCF of final fraction
                FResult.num = FResult.num / iGCF; //reduce numertaor by dividing by GCF
                FResult.denom = FResult.denom / iGCF; //redcue denominator by dividing the GCF
                if (FResult.denom < 0) //denominator is a negative number
                {
                    FResult.denom = -FResult.denom; //turn into positive by cancelling the negative with a negative
                    FResult.num = -FResult.num; //add the negative sign to the numerator instead
                }
                txtResultNum.Text = FResult.num.ToString();
                txtResultDenom.Text = FResult.denom.ToString();
            }
            catch
            {
                MessageBox.Show("Please enter a number");
                ClearAll();
                return;
            }
        }

        private void btnReset_Click(object sender, EventArgs e) //reset button
        {
            ClearAll();
        }
    }
}
