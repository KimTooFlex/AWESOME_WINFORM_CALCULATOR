using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AWESOME_CALCULATOR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// Evaluates the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static double Evaluate(string expression)
        {
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }

        string Expression = "";

        public double LastAns { get; private set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
          
            lblExpression.Text =  Expression="";
            lblAns.Text = "0";
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            LastAns = Evaluate(Expression);
            timeAnimate.Start();
        }


        /// <summary>
        /// Gets the random nums.
        /// </summary>
        /// <param name="Ans">The ans.</param>
        /// <returns></returns>
        string GetRandomNums(int Length)
        {

          
            string tmp = "";
            Random ran = new Random();
            for (int i = 0; i < Length; i++)
            {
                tmp += ran.Next(0,10);
            }
            return tmp;
        }

        

        int i = 0;
        private void timeAnimate_Tick(object sender, EventArgs e)
        {
            if (i<25)
            {
                lblAns.Text = GetRandomNums(this.LastAns.ToString().Length);
                i++;
            }
            else
            {
                i = 0;
                lblAns.Text = LastAns.ToString();
                timeAnimate.Stop();
            }
        }

        private void btnNums_Click(object sender, EventArgs e)
        {
            lblAns.Text = 0.ToString();
           lblExpression.Text= ( Expression += ((Control)sender).Tag.ToString());
        }

        private void bunifuImageButton18_Click(object sender, EventArgs e)
        {
            try
            {
                lblExpression.Text = Expression = Expression.Substring(0, Expression.Length - 1);

            }
            catch (Exception)
            {
                 
            }    
        }
    }
}
