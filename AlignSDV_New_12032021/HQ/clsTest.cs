using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace validateForm
{
    class Customer
    {

        public Customer() { }

        [Required(ErrorMessage = "This field is required.")]
        public string Name
        {
            get;
            set;
        }
        [Required(ErrorMessage = "This field is required.")]
        public string UserName
        {
            get;
            set;
        }
        [DataType(DataType.Password, ErrorMessage = "Invalid password.")]
        [Required(ErrorMessage = "This field is required.")]
        public string Password
        {
            get;
            set;
        }
        [Range(20, 120, ErrorMessage = "Enter the age between 20 and 100.")]
        public int Age
        {
            get;
            set;
        }
        [Required(ErrorMessage = "This field is required.")]
        public string EMail
        {
            get;
            set;
        }
        public string Phone
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }

    }
}