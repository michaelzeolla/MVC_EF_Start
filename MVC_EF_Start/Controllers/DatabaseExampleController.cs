using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
    public class DatabaseExampleController : Controller
    {
        public ApplicationDbContext dbContext;

        public DatabaseExampleController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult> DatabaseOperations()
        {
            //Populate some data into student and course tables for LINQ Practice in class
            Student Student1 = new Student();
            Student1.StudentID = 12345;
            Student1.firstName = "Michael";
            Student1.lastName = "Zeolla";

            Student Student2 = new Student();
            Student2.StudentID = 12346;
            Student2.firstName = "Samrat";
            Student2.lastName = "Korupolu";

            Course DIS = new Course();
            DIS.CourseID = "ISM6225";
            DIS.courseName = "Distributed Information Systems";
            DIS.credits = 3;
            
            Course SDM = new Course();
            DIS.CourseID = "ISM6137";
            DIS.courseName = "Statistical Data Mining";
            DIS.credits = 3;

            Course DVIZ = new Course();
            DVIZ.CourseID = "ISM6419";
            DVIZ.courseName = "Data Visualization";
            DVIZ.credits = 3;

            StudentCourse sc1 = new StudentCourse();
            sc1.Student = Student1;
            sc1.Course = DIS;

            dbContext.Students.Add(Student1);
            dbContext.Students.Add(Student2);
            dbContext.Courses.Add(DIS);
            dbContext.Courses.Add(SDM);
            dbContext.Courses.Add(DVIZ);

            dbContext.SaveChanges();
            


            // CREATE operation
            //For my simple Arrests example:
            Arrests USA = new Arrests();
            USA.year = "2019";
            USA.offenseType = "Drug";
            USA.numberOfArrests = 1239909;

            dbContext.Arrests.Add(USA);

            dbContext.SaveChanges();

            Company MyCompany = new Company();
            MyCompany.symbol = "MCOB";
            MyCompany.name = "ISM";
            MyCompany.date = "ISM";
            MyCompany.isEnabled = true;
            MyCompany.type = "ISM";
            MyCompany.iexId = "ISM";

            Quote MyCompanyQuote1 = new Quote();
            //MyCompanyQuote1.EquityId = 123;
            MyCompanyQuote1.date = "11-23-2018";
            MyCompanyQuote1.open = 46.13F;
            MyCompanyQuote1.high = 47.18F;
            MyCompanyQuote1.low = 44.67F;
            MyCompanyQuote1.close = 47.01F;
            MyCompanyQuote1.volume = 37654000;
            MyCompanyQuote1.unadjustedVolume = 37654000;
            MyCompanyQuote1.change = 1.43F;
            MyCompanyQuote1.changePercent = 0.03F;
            MyCompanyQuote1.vwap = 9.76F;
            MyCompanyQuote1.label = "Nov 23";
            MyCompanyQuote1.changeOverTime = 0.56F;
            MyCompanyQuote1.symbol = "MCOB";

            Quote MyCompanyQuote2 = new Quote();
            //MyCompanyQuote1.EquityId = 123;
            MyCompanyQuote2.date = "11-23-2018";
            MyCompanyQuote2.open = 46.13F;
            MyCompanyQuote2.high = 47.18F;
            MyCompanyQuote2.low = 44.67F;
            MyCompanyQuote2.close = 47.01F;
            MyCompanyQuote2.volume = 37654000;
            MyCompanyQuote2.unadjustedVolume = 37654000;
            MyCompanyQuote2.change = 1.43F;
            MyCompanyQuote2.changePercent = 0.03F;
            MyCompanyQuote2.vwap = 9.76F;
            MyCompanyQuote2.label = "Nov 23";
            MyCompanyQuote2.changeOverTime = 0.56F;
            MyCompanyQuote2.symbol = "MCOB";

            dbContext.Companies.Add(MyCompany);
            dbContext.Quotes.Add(MyCompanyQuote1);
            dbContext.Quotes.Add(MyCompanyQuote2);

            dbContext.SaveChanges();

            // READ operation
            //Read for my Arrests Example
            
            Company CompanyRead1 = dbContext.Companies
                                    .Where(c => c.symbol == "MCOB")
                                    .First();

            Company CompanyRead2 = dbContext.Companies
                                    .Include(c => c.Quotes)
                                    .Where(c => c.symbol == "MCOB")
                                    .First();

            // UPDATE operation
            CompanyRead1.iexId = "MCOB";
            dbContext.Companies.Update(CompanyRead1);
            //dbContext.SaveChanges();
            await dbContext.SaveChangesAsync();

            // DELETE operation
            //dbContext.Companies.Remove(CompanyRead1);
            //await dbContext.SaveChangesAsync();

            return View();
        }

        public ViewResult LINQOperations()
        {
            Company CompanyRead1 = dbContext.Companies
                                            .Where(c => c.symbol == "MCOB")
                                            .First();

            Company CompanyRead2 = dbContext.Companies
                                            .Include(c => c.Quotes)
                                            .Where(c => c.symbol == "MCOB")
                                            .First();

            Quote Quote1 = dbContext.Companies
                                    .Include(c => c.Quotes)
                                    .Where(c => c.symbol == "MCOB")
                                    .FirstOrDefault()
                                    .Quotes
                                    .FirstOrDefault();

            return View();


            Student Student1 = dbContext.Students
                                        .Include(s => s.Courses)
                                        .Where
        }

    }
}