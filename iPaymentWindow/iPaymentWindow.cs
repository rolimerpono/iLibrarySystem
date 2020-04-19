using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace iPaymentWindow
{
    public partial class iPaymentWindow : UserControl
    {
        public iPaymentWindow()
        {
            InitializeComponent();

        }
        Model.Transaction oTransaction = new Transaction();
        List<Model.Transaction> oTransactionList = new List<Model.Transaction>();
      
        public List<Model.Transaction> TransactionList
        {
            get { return oTransactionList;}
            set { oTransactionList =value;}
        }

        private double? iPenaltyInterest = 0;
        private double? iLDIntereset = 0;
        private double? iTotalDueInterest = 0;
        private double? iTotalLDInterest = 0;
        private double? iTotalInterest = 0;
        private double? iReceiveAmount = 0;
        private double? iChange = 0;
        private double? iTotalDue = 0;
        private double? iBookPrice = 0;
        private double? iRentPrice = 0;
        private int iNoOfDaysDue = 0;
        private DateTime dDateBorrowed;
        private int iDaysCount = 0;

        public TransactionType TranType;

        public enum TransactionType : int
        { 
            Checkout = 0,
            Return =  1,
            Pay = 2            
        }
        

        public double? PenaltyInterest
        {
            get { return iPenaltyInterest; }
            set { iPenaltyInterest = value; }
        }

        public double? LDInterest
        {
            get { return iLDIntereset; }
            set { iLDIntereset = value; }
        }

        public double? TotalDueInterest
        {
            get { return iTotalDueInterest; }
            set { iTotalDueInterest = value; }
        }

        public double? TotalLDInterest
        {
            get { return iTotalLDInterest; }
            set { iTotalLDInterest = value; }
        }

        public double? TotalInterest
        {
            get { return iTotalInterest; }
            set { iTotalInterest = value; }
        }

        public double? ReceiveAmount
        {
            get { return iReceiveAmount; }
            set { iReceiveAmount = value; }
        }

        public double? Change
        {
            get { return iChange; }
            set { iChange = value; }
        }

        public double? TotalDue
        {
            get { return iTotalDue; }
            set { iTotalDue = value; }
        }

        public double? BookPrice
        {
            get { return iBookPrice; }
            set { iBookPrice = value; }
        }

        public double? RentPrice
        {
            get { return iRentPrice; }
            set { iRentPrice = value; }
        }

        public DateTime DateBorrowed
        {
            get { return dDateBorrowed; }
            set { dDateBorrowed = value; }
        }

        public void GetNoOfDaysDue()
        {
            try
            {


                foreach (var oData in TransactionList)
                {
                    iDaysCount = (int)(DateTime.Now - Convert.ToDateTime(oData.ADDED_DATE)).TotalDays;
                    if (iDaysCount > Convert.ToInt32(oData.TOTAL_DAYS))
                    {
                        iNoOfDaysDue += iDaysCount - Convert.ToInt32(oData.TOTAL_DAYS);
                    }
                    else
                    {
                        iNoOfDaysDue = 0;
                    }

                }
            }
            catch (Exception ex)
            { }

        }        

        private void GetTotalDueInterest()
        {
            try
            {
                foreach (var oData in TransactionList)
                {
                    if (oData.BFLAG == true)
                    {
                        iTotalDueInterest += (Convert.ToDouble(oData.RENT_PRICE) * (Convert.ToDouble(oData.DUE_INTEREST / 100) * iNoOfDaysDue));
                    }
                }
                TotalDueInterest = iTotalDueInterest;

                lblTotalDueInterest.Text = iTotalDueInterest.ToString();
                iTotalDueInterest = 0;
            }
            catch (Exception ex)
            { }
        }

        private void GetTotalLDInterest()
        {
            try
            {
                foreach (var oData in TransactionList)
                {
                    if (oData.BFLAG == true)
                    {
                        iTotalLDInterest += Convert.ToDouble(oData.BOOK_PRICE) + (Convert.ToDouble(oData.BOOK_PRICE) * Convert.ToDouble(oData.LD_INTEREST / 100));
                    }
                }

                TotalLDInterest = iTotalLDInterest;
                if (TranType == TransactionType.Pay)
                {
                    lblTotalLDInterest.Text = iTotalLDInterest.ToString();
                }
                iTotalLDInterest = 0;
            }
            catch (Exception ex)
            { }
        }

        public void DisplayDetails()
        {
            try
            {

                GetNoOfDaysDue();
                GetTotalDueInterest();
                GetTotalLDInterest();

                lblTotalInterest.Text = (Convert.ToDouble(lblTotalDueInterest.Text) + Convert.ToDouble(lblTotalLDInterest.Text)).ToString();

                if (TranType == TransactionType.Checkout)
                {
                    foreach (var oData in TransactionList)
                    {
                        iRentPrice += Convert.ToDouble(oData.RENT_PRICE);
                    }
                }
                if (TranType == TransactionType.Return)
                {
                    iRentPrice = 0;
                }            

                lblTotalDue.Text = lblTotalInterest.Text;                
                lblTotalDue.Text = (Convert.ToDouble(lblTotalDue.Text) + iRentPrice).ToString();
                TotalDue = Convert.ToDouble(lblTotalDue.Text);

            }
            catch (Exception ex)
            { }
        }

        private void txtRecievedAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sChange = (Convert.ToDouble(txtRecievedAmount.Text == string.Empty ? "0" : txtRecievedAmount.Text) - Convert.ToDouble(lblTotalDue.Text)).ToString();

                if (Convert.ToDouble(sChange) < 0)
                {
                    lblChange.Text = "0";
                }
                else
                {
                    lblChange.Text = sChange;
                }
            }
            catch (Exception ex)
            { }
        }

        private void txtRecievedAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != '\b')
                {
                    if (txtRecievedAmount.Text == "" && e.KeyChar == '0')
                    {
                        e.Handled = true;
                        return;
                    }
                    if (e.KeyChar < '0' || e.KeyChar > '9')
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        public void clearText()
        {
            

            lblTotalDueInterest.Text = "0";
            lblTotalLDInterest.Text = "0";
            lblTotalInterest.Text = "0";
            txtRecievedAmount.Text = "0";
            lblChange.Text = "0";
            lblTotalDue.Text = "0";

            iDaysCount = 0;
            iNoOfDaysDue = 0;

            iPenaltyInterest = 0;
            iRentPrice = 0;
            iBookPrice = 0;
            iChange = 0;            

            iTotalDue = 0;
            iTotalDueInterest = 0;
            iTotalInterest = 0;
            iTotalLDInterest = 0;

            ReceiveAmount = 0;
            TotalDue = 0;
            TotalDueInterest = 0;
            TotalInterest = 0;
            TotalLDInterest = 0;
            
        }

        private void txtRecievedAmount_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                ReceiveAmount = Convert.ToDouble(txtRecievedAmount.Text == string.Empty ? "0" : txtRecievedAmount.Text);
            }
            catch (Exception ex)
            { }
        }


    }
}
