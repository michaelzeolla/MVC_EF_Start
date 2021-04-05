using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Start.Models
{

    //this following code is for LINQ practice in class
  public class Student
    {
        public int StudentID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<Course> courses { get; set; }
    }

  public class Course
    {
        public float CourseID { get; set; }
        public int credits {  get; set; }
        public string courseName { get; set; }
        //list needed here too?
    }

    public class StudentCourse
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
    //this is code from the original repository
  public class Company
  {
    [Key]
    public string symbol { get; set; }
    public string name { get; set; }
    public string date { get; set; }
    public bool isEnabled { get; set; }
    public string type { get; set; }
    public string iexId { get; set; }
    public List<Quote> Quotes { get; set; }
  }

  public class Quote
  {
    public int QuoteId { get; set; }
    public string date { get; set; }
    public float open { get; set; }
    public float high { get; set; }
    public float low { get; set; }
    public float close { get; set; }
    public int volume { get; set; }
    public int unadjustedVolume { get; set; }
    public float change { get; set; }
    public float changePercent { get; set; }
    public float vwap { get; set; }
    public string label { get; set; }
    public float changeOverTime { get; set; }
    public string symbol { get; set; }
  }

  public class ChartRoot
  {
    public Quote[] chart { get; set; }
  }

 //this following code is practice in class, example along with Assignment 3 for Assignment 4
 public class Arrests
    {
        [Key]
        public string year { get; set; }
        public string offenseType { get; set; }
        public float numberOfArrests { get; set; }
    }


}