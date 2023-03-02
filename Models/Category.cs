using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebApplication8.Models
{
    public class Country
    {
        public int id { get; set; } 
        public string name { get; set; }    
    }
    public class State
    {
        public int id { get; set; }
        public string name { get; set; }
        [ForeignKey("cty")]
        public int cid { get; set; }
        public Country cty { get; set; }

    }
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        [ForeignKey("cty")]
        public int countryID { get; set; }    
        public Country cty { get; set; }
        [ForeignKey("state")]
        public int stateID { get; set; }
        public State state { get; set; }
      
    }
    public class Category
    {

        public int id { get; set; }
        [Display(Name = "Product Name")]
        public string name { get; set; }
        [NotMapped]
        public bool check { get; set; }
        public string imgPath { get; set; }
       
    }
    
    public class Product
    {
        public int id { get; set; }
        [Display(Name = "Product Name")]
        public string name { get; set; }
        [ForeignKey("cid")]
        public int categid { get; set; }
        public Category cid { get; set; }
        public string imgPath { get; set; }


    }
   
    public class Sale
    {
        public int id { get; set; }
        [ForeignKey("cid")]
        public int userid { get; set; }
        [Display(Name = "Sale ProductsSold")]
        public string ProductsSold { get; set; }
        [Display(Name = "Sale dateTimeofsale")]
        public DateTime dateTimeofsale { get; set; }
        public Category cid { get; set; }
    }
    public class EcomContext : DbContext
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Sale> sales { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<Employee> employees { get; set; }
    }
}
    
