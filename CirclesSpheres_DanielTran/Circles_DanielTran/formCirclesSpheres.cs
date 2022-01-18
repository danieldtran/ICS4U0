using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circles_DanielTran
{
    public partial class formCirclesSpheres : Form
    {
        //declare global circles
        Circle C1, C2;
        //Circle Object
        public class Circle
        {
            protected int centerX;
            protected int centerY;
            protected int radius;
            public Color clr;
            //Operator Overloading Methods
            //compares the circles based on their radii
            //less than operator
            public static bool operator <(Circle C1, Circle C2)
            {
                if (C1.radius < C2.radius)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //greater than operator
            public static bool operator >(Circle C1, Circle C2)
            {
                if (C1.radius > C2.radius)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //Constructors
            //default circle constructor with no parameters
            public Circle()
            {
                centerX = 0;
                centerY = 0;
                radius = 0;
                clr = Color.Black;
            }
            //constructor method with three parameters with point being one
            public Circle(Point pnt, int rad, Color col)
            {
                setX(pnt.X);
                setY(pnt.Y);
                setRadius(rad);
                clr = col;
            }
            //constructor with parameter type Circle
            public Circle(Circle other)
            {
                this.centerX = other.centerX;
                this.centerY = other.centerY;
                this.radius = other.radius;
                this.clr = other.clr;
            }
            //Getter for centerX
            public int getX()
            {
                return centerX;
            }
            //Getter for centerY
            public int getY()
            {
                return centerY;
            }
            //Getter for radius
            public int getRadius()
            {
                return radius;
            }
            //Setter for centerX
            public void setX(int x)
            {
                if (x < 0)
                {
                    centerX = -x;
                }
                else
                {
                    centerX = x;
                }
            }
            //Setter for centerY
            public void setY(int y)
            {
                if (y < 0)
                {
                    centerY = -y;
                }
                else
                {
                    centerY = y;
                }
            }
            //Setter for radius
            public void setRadius(int rad)
            {
                if (rad < 0)
                {
                    radius = -rad;
                }
                else
                {
                    radius = rad;
                }
            }
            //returns the area of the Circle as a double
            public double GetArea()
            {
                double dArea;
                dArea = Math.Round(Math.PI * Math.Pow(((double)radius), 2));
                return dArea;
            }
            //returns the perimeter of the Circle as a double
            public double GetPerimeter()
            {
                double dPerimeter;
                dPerimeter = Math.Round(2 * Math.PI * (double)radius, 2);
                return dPerimeter;
            }
            //Inputs the point and checks if the point is in the circle or not
            //returns an int
            public int IsInside(Point pnt)
            {
                double dLength;
                dLength = Math.Sqrt(Math.Pow(centerX - pnt.X, 2) + Math.Pow(centerY - pnt.Y, 2));
                if (dLength == radius)
                {
                    return 0;
                }
                else if (dLength < radius)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            //Inputs the point as two separate integers and checks if the point is in or not
            //returns as int
            public int IsInside(int a, int b)
            {
                double dLength;
                dLength = Math.Sqrt(Math.Pow(centerX - (double)a, 2) + Math.Pow(centerY - (double)b, 2));
                if (dLength == radius)
                {
                    return 0;
                }
                else if (dLength < radius)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            //Compare method
            //compares the radii between the two circles
            public int Compare(Circle other)
            {
                if (this.radius == other.radius)
                {
                    return 0;
                }
                else if (this.radius > other.radius)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            //Draw method for Circles
            public void Draw(Graphics g)
            {
                Pen myPen = new Pen(clr, 3);
                Brush myBrush = new SolidBrush(clr);
                g.DrawEllipse(myPen, centerX - radius, centerY - radius, 2 * radius, 2 * radius);
                g.FillEllipse(myBrush, centerX - radius, centerY - radius, 2 * radius, 2 * radius);
            }
            
        }
        //declares two global spheres
        Sphere S1, S2;
        //Sphere inherits the variables of the circle
        //Sphere Object
        public class Sphere : Circle
        {
            //Constructor methods for Sphere Object
            //constructor with no parameters, sets all values to 0 and has the colour black
            public Sphere() : base()
            {
                centerX = 0;
                centerY = 0;
                radius = 0;
                clr = Color.Black;
            }
            //constructor with three parameters which inputs point object
            public Sphere(Point pnt, int rad, Color col)
            {
                setX(pnt.X);
                setY(pnt.Y);
                setRadius(rad);
                clr = col;
            }
            //constructor with Sphere parameter which clones the other Sphere
            public Sphere(Sphere other)
            {
                this.centerX = other.centerX;
                this.centerY = other.centerY;
                this.radius = other.radius;
                this.clr = other.clr;
            }
            //Get Surface Area method
            //returns the Surface Area as a double
            public double getArea()
            {
                double dArea;
                dArea = Math.Round(4* Math.PI * Math.Pow(((double)radius), 2), 2);
                return dArea;
            }
            //Get Perimeter method
            //does not return a value because finding perimeter for a 3D shape is pointless
            //throws an exception 
            public double GetPerimeter()
            {
                throw new InvalidOperationException();
            }
            //Get Volume Method
            //returns volume as a double
            public double getVolume()
            {
                double dVolume;
                dVolume = Math.Round(4 * Math.PI * Math.Pow(((double)radius), 3) / 3);
                return dVolume;
            }
            //Draw method for Spheres
            public void Draw(Graphics g)
            {
                Pen myPen = new Pen(clr, 3);
                Brush myBrush = new SolidBrush(clr);
                //creates the negative colour of the sphere's colour
                Color col = Color.FromArgb(255, 255 - clr.R, 255 - clr.G, 255 - clr.B);
                //stores the negative colour into negPen
                Pen negPen = new Pen(col, 3);
                //dotPen is to create the dotted line that shows the radius
                Pen dotPen = new Pen(col, 3);
                dotPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                g.DrawEllipse(myPen, centerX - radius, centerY - radius, 2 * radius, 2 * radius);
                g.FillEllipse(myBrush, centerX - radius, centerY - radius, 2 * radius, 2 * radius);
                g.DrawEllipse(negPen, centerX - radius, centerY - radius / 2, 2 * radius, radius);
                g.DrawLine(dotPen, new Point(centerX, centerY), new Point(centerX + radius, centerY));
            }
            //compares the radii between the two spheres
            //returns an int
            public int Compare(Sphere other)
            {
                if (this.radius == other.radius)
                {
                    return 0;
                }
                else if (this.radius > other.radius)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }
        public formCirclesSpheres()
        {
            InitializeComponent();
            //initialize both circles and spheres
            C1 = new Circle();
            C2 = new Circle();
            S1 = new Sphere();
            S2 = new Sphere();
        }
        //Compare Button for Circles
        private void btnCompare_Click(object sender, EventArgs e)
        {
            int iResult;
            iResult = C1.Compare(C2);
            if (C1 > C2)
            {
                MessageBox.Show("Circle One is bigger than Circle Two");
            }
            else if (C1 < C2)
            {
                MessageBox.Show("Circle One is smaller than Circle Two");
            }
            else
            {
                MessageBox.Show("Circle One is equal to Circle Two");
            }
        }
        //Buttons for Circle One
        //First Circle Canvas
        //draws Circle One
        private void pbCircle1_Paint(object sender, PaintEventArgs e)
        {
            C1.Draw(e.Graphics);
        }
        //Initializes Circle One and stores the data
        private void btnInitialize1_Click(object sender, EventArgs e)
        {
            try
            {
                C1.setX(Convert.ToInt32(nudCenterX1.Text));
                C1.setY(Convert.ToInt32(nudCenterY1.Text));
                C1.setRadius(Convert.ToInt32(nudRadius1.Text));
                pbCircle1.Invalidate();
            }
            catch
            {
                MessageBox.Show("Input Error!");
            }
        }
        //Change Colour button
        //changes the colour of Circle One
        private void btnColour1_Click(object sender, EventArgs e)
        {
            ColorDialog clrDlg = new ColorDialog();
            if(clrDlg.ShowDialog() == DialogResult.OK)
            {
                C1.clr = clrDlg.Color;
                pbCircle1.Invalidate(); 
            }
        }
        //Get Area Button
        //shows the area of Circle One
        private void btnArea1_Click(object sender, EventArgs e)
        {
            double dResult;
            dResult = C1.GetArea();
            MessageBox.Show("The Area of Circle One is " + dResult + " units squared");
        }
        //Get Perimeter Button
        //shows the perimeter of Circle One
        private void btnPerimeter1_Click(object sender, EventArgs e)
        {
            double dResult;
            dResult = C1.GetPerimeter();
            MessageBox.Show("The Perimeter of Circle One is " + dResult + " units");
        }
        //Is Inside Button
        //inputs the users point as two integers and uses the IsInside method to compare
        //shows if the point is inside, outside, or on Circle One
        private void btnInside1_Click(object sender, EventArgs e)
        {
            try
            {
                int iResult; 
                int x, y;
                x = Convert.ToInt32(nudPointX1.Text);
                y = Convert.ToInt32(nudPointY1.Text);
                iResult = C1.IsInside(x, y);
                if (iResult == 1)
                {
                    MessageBox.Show("Point is inside Circle One");
                }
                else if (iResult == -1)
                {
                    MessageBox.Show("Point is outside Circle One");
                }
                else
                {
                    MessageBox.Show("Point is on Circle One");
                }
            }
            catch
            {
                MessageBox.Show("Input Error");
            }
        }
        //Buttons for Circle Two
        //Circle Two Canvas
        //draws Circle Two
        private void pbCircle2_Paint(object sender, PaintEventArgs e)
        {
            C2.Draw(e.Graphics);
        }
        //Initializes Circle Two and stores the data
        private void btnInitialize2_Click(object sender, EventArgs e)
        {
            try
            {
                C2.setX(Convert.ToInt32(nudCenterX2.Text));
                C2.setY(Convert.ToInt32(nudCenterY2.Text));
                C2.setRadius(Convert.ToInt32(nudRadius2.Text));
                pbCircle2.Invalidate();
            }
            catch
            {
                MessageBox.Show("Input Error!");
            }

        }
        //Change Colour button
        //changes the colour of Circle Two
        private void btnColour2_Click(object sender, EventArgs e)
        {
            ColorDialog clrDlg = new ColorDialog();
            if (clrDlg.ShowDialog() == DialogResult.OK)
            {
                C2.clr = clrDlg.Color;
                pbCircle2.Invalidate();
            }
        }
        //Get Area Button
        //shows the area of Circle Two
        private void btnArea2_Click(object sender, EventArgs e)
        {
            double dResult;
            dResult = C2.GetArea();
            MessageBox.Show("The Area of Circle Two is " + dResult + " units squared");
        }
        //Get Perimeter Button
        //shows the perimeter of Circle Two
        private void btnPerimeter2_Click(object sender, EventArgs e)
        {
            double dResult;
            dResult = C2.GetPerimeter();
            MessageBox.Show("The Perimeter of Circle Two is " + dResult + " units");
        }
        //Is Inside Button
        //inputs the users point as two integers and uses the IsInside method to compare
        //shows if the point is inside, outside, or on Circle Two
        private void btnInside2_Click(object sender, EventArgs e)
        {
            try
            {
                int iResult;
                int x, y;
                x = Convert.ToInt32(nudPointX2.Text);
                y = Convert.ToInt32(nudPointY2.Text);
                iResult = C2.IsInside(x, y);
                if (iResult == 1)
                {
                    MessageBox.Show("Point is inside Circle 2");
                }
                else if (iResult == -1)
                {
                    MessageBox.Show("Point is outside Circle 2");
                }
                else
                {
                    MessageBox.Show("Point is on Circle 2");
                }
            }
            catch
            {
                MessageBox.Show("Input Error");
            }
        }
        //Compare Button for Spheres
        private void btnSCompare_Click(object sender, EventArgs e)
        {
            int iResult;
            iResult = S1.Compare(S2);
            if (S1 > S2)
            {
                MessageBox.Show("Sphere 1 is bigger than Sphere 2");
            }
            else if (S1 < S2)
            {
                MessageBox.Show("Sphere 1 is smaller than Sphere 2");
            }
            else
            {
                MessageBox.Show("Sphere 1 is equal to Sphere 2");
            }
        }
        //Buttons for Sphere One
        //Sphere One Canvas
        //draws Sphere One
        private void pbSphere1_Paint(object sender, PaintEventArgs e)
        {
            S1.Draw(e.Graphics);
        }
        //Initializes Sphere One and stores the data
        private void btnSInitialize1_Click(object sender, EventArgs e)
        {
            try
            {
                S1.setX(Convert.ToInt32(nudSCenterX1.Text));
                S1.setY(Convert.ToInt32(nudSCenterY1.Text));
                S1.setRadius(Convert.ToInt32(nudSRadius1.Text));
                pbSphere1.Invalidate();
            }
            catch
            {
                MessageBox.Show("Input Error!");
            }
        }
        //Change Colour button
        //changes the colour of Sphere One
        private void btnSColour1_Click(object sender, EventArgs e)
        {
            ColorDialog clrDlg = new ColorDialog();
            if (clrDlg.ShowDialog() == DialogResult.OK)
            {
                S1.clr = clrDlg.Color;
                pbSphere1.Invalidate();
            }
        }
        //Get Surface Area Button
        //shows the surface area of Sphere One
        private void btnSArea1_Click(object sender, EventArgs e)
        {
            double dResult;
            dResult = S1.getArea();
            MessageBox.Show("The Surface Area of Circle One is " + dResult + " units squared");
        }
        //Get Volume Button
        //shows the volume of Sphere One
        private void btnVolume1_Click(object sender, EventArgs e)
        {
            double dResult;
            dResult = S1.getVolume();
            MessageBox.Show("The Surface Area of Circle One is " + dResult + " units cubed");
        }
        //Buttons for Sphere Two
        //Sphere Two Canvas
        //draws Sphere Two
        private void pbSphere2_Paint(object sender, PaintEventArgs e)
        {
            S2.Draw(e.Graphics);
        }
        //Initializes Sphere Two and stores the data
        private void btnSInitialize2_Click(object sender, EventArgs e)
        {
            try
            {
                S2.setX(Convert.ToInt32(nudSCenterX2.Text));
                S2.setY(Convert.ToInt32(nudSCenterY2.Text));
                S2.setRadius(Convert.ToInt32(nudSRadius2.Text));
                pbSphere2.Invalidate();
            }
            catch
            {
                MessageBox.Show("Input Error!");
            }
        }
        //Change Colour button
        //changes the colour of Sphere Two
        private void btnSColour2_Click(object sender, EventArgs e)
        {
            ColorDialog clrDlg = new ColorDialog();
            if (clrDlg.ShowDialog() == DialogResult.OK)
            {
                S2.clr = clrDlg.Color;
                pbSphere2.Invalidate();
            }
        }
        //Get Surface Area Button
        //shows the surface area of Sphere Two
        private void btnSArea2_Click(object sender, EventArgs e)
        {
            double dResult;
            dResult = S2.getArea();
            MessageBox.Show("The Surface Area of Circle Two is " + dResult + " units squared");
        }
        //Get Volume Button
        //shows the volume of Sphere Two
        private void btnVolume2_Click(object sender, EventArgs e)
        {
            double dResult;
            dResult = S2.getVolume();
            MessageBox.Show("The Volume of Circle Two is " + dResult + " units cubed");
        }

    }
}
