﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureValueProject {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private string IsNotBlank(string value, string name) {
            if(value == string.Empty) {
                return $"{name} is required!\n";
            }
            return string.Empty;
        }

        private void btnCalculate_Click(object sender, EventArgs e) {
            try {

             string message = IsNotBlank(txtMonthlyInvestment.Text, "Monthly Investment");
                message += IsNotBlank(txtInterestRate.Text, "Interest Rate");
                message += IsNotBlank(txtYears.Text, "Years");
            if (message != string.Empty) {
                    MessageBox.Show(message, "Entry Error");
                    return;
                }

            decimal monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
            decimal yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
            int years = Convert.ToInt32(txtYears.Text);

            int months = years * 12;
            decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;

            
            decimal futureValue = 0m;
            for (int i = 0; i< months; i++) {
                futureValue = (futureValue + monthlyInvestment)
                    * (1 + monthlyInterestRate);
            }
            txtFutureValue.Text = futureValue.ToString("c");
            txtMonthlyInvestment.Focus();
            }
            catch(FormatException) {
                MessageBox.Show(
                    "Invalid numeric format. Please check all entries.",
                    "Entry Error"
                    );
            } catch (OverflowException) {
                MessageBox.Show(
                    "Overflow Error. Please use smaller values",
                    "Entry Error"
                    );
            }
            catch(Exception ex) {
                MessageBox.Show(
                    ex.Message, 
                    ex.GetType().ToString()
                  );
            }
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }
            private void ClearFutureValue(object sender, EventArgs e) { txtFutureValue.Text = String.Empty;
            }

    }
    }
    

