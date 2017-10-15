using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace oopRestaurant
{
    public class Category
    {   
        /// <summary>
        /// Az adatbázisba írás miatt kell a primary key -> Id
        /// Codefirst tudja, hogy ő a PK
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
    }
}