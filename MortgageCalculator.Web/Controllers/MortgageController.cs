using MortgageCalculator.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MortgageCalculator.Web.Controllers
{
    public class MortgageController : Controller
    {
        IList<Mortgage> mortageList = new List<Mortgage>() {
                    new Mortgage(){ MortgageId=1, MortgageType="Fixed",Interest=12},

                    new Mortgage(){ MortgageId=2, MortgageType="Variable",Interest=12},

                    new Mortgage(){ MortgageId=3, MortgageType="Fixed",Interest=18},

                    new Mortgage(){ MortgageId=4, MortgageType="Variable",Interest=15},

                    new Mortgage(){ MortgageId=5, MortgageType="Fixed",Interest=15},

                    new Mortgage(){ MortgageId=6, MortgageType="Variable",Interest=15}
                };
        // GET: Mortgage
        public ActionResult Mortgage()
        {
            var GenreLst = new List<string>();

            var GenreQry = from d in mortageList
                           orderby d.MortgageType, d.Interest
                           select d;

            return View(GenreQry);
        }

        public ActionResult MortgageResult()
        {
            var GenreLst = new List<string>();

            var GenreQry = from d in mortageList
                           orderby d.MortgageType, d.Interest
                           select d;

            


            return View(GenreQry);
        }

        public ActionResult Edit(int id)
        {
            //Get the student from studentList sample collection for demo purpose.
            //You can get the student from the database in the real application
            var std = mortageList.Where(s => s.MortgageId == id).FirstOrDefault();


            
            ViewBag.InterestandPrinciple = Convert.ToDouble( 0);


            ViewBag.Interesttopay = Convert.ToDouble(0);

            List<DataRow> list = new List<DataRow>();

            ViewBag.List = list;

            return View(std);
        }

        [HttpPost]
        public ActionResult Edit(Mortgage std)
        {

            
            if (ModelState.IsValid)
            {
                

                // Loan Amount
                double l = std.LoanAmount;

                // Percentage
                double p = getPercentage(Convert.ToDouble(std.Interest));

                // Terms
                int t = getTerms(std.TermsInYear);

                // Motgage

                double m = Math.Round(calculateMortgage(l, p, t), 2);

                //Total Principal
                double InterestandPrinciple = Math.Round(m, 2) * t;

                // Total Interest
                double Interest = Math.Round(InterestandPrinciple - l, 2);


                ViewBag.Mi = m;
                ViewBag.pi =  InterestandPrinciple;
                ViewBag.ip = Interest;

                //Mortgage details

                DataTable d= MortgageDetails(l, p, t, m);

                List<DataRow> list = new List<DataRow>();


                foreach(DataRow datarow in d.Rows)
                {
                    list.Add(datarow);
                }

                ViewBag.List = list;

                return View(std);
               
            }

            return View(std);
        }

        private DataTable MortgageDetails(double l, double p, int t,double m)
        {
            DataTable dtMortgageDetails = new DataTable();

            

            
            dtMortgageDetails.Columns.Add("Principal Amount", typeof(double));
            dtMortgageDetails.Columns.Add("Monthly Due", typeof(double));
            dtMortgageDetails.Columns.Add("Interest To Pay", typeof(double));
            dtMortgageDetails.Columns.Add("Principal To Pay", typeof(double));
            
            
            dtMortgageDetails.Columns.Add("Outstanding", typeof(double));
            
            
            double PrincipalAmount = l;

            for (int i = 1; i <= t; i++)
            {
                DataRow dr = dtMortgageDetails.NewRow();
                dr["Principal Amount"] =Math.Round( l,2);

                dr["Monthly Due"] = m;

                dr["Interest To Pay"] = Math.Round(l * p, 2);

                dr["Principal To Pay"] = Math.Round(m - (l * p), 2);

                dr["Outstanding"] = Math.Round(l - ( m - (l * p)), 2) <0 ?0: Math.Round(l - (m - (l * p)), 2);

                l = Math.Round(l - (m - (l * p)), 2);

                dtMortgageDetails.Rows.Add(dr);

               
            }

            return dtMortgageDetails;
        }
        
        public double calculateMortgage(double l, double p, int t)
        {
            // interest
            //double i = Math.Pow(3, 3);

            //Formula

            // = loan amount * monthly interest(1 + monthly interest) ^ terms in month / ((1 + monthly interest) ^ terms in month -1)

            double F = Formula(p, t);

            return l * ((p * F) / (F - 1));
        }

        public double Formula(double p, int t)
        {

            return Math.Pow(1 + p, t);
        }

        public int getTerms(int termsInYear)
        {
            int t = termsInYear * 12;
            return t;
        }

        public double getPercentage(double interest)
        {
            double p = (interest / (12 * 100));
            return p;
        }
    }
}