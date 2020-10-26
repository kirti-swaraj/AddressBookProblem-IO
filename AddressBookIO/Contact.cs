// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contact.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
// --------------------------------------------------------------------------------------------------------------------
namespace AddressBookIO
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// UC 1 : CREATED CONTACT CLASS WITH PROPER REQUIRED FIELDS
    /// </summary>
    public class Contact
    {
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public double zip;
        public double phoneNumber;
        public string email;

        /// <summary>
        /// INITIALIZES A NEW INSTANCE OF CONTACT CLASS
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="address">The address.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="email">The email.</param>
        public Contact(string firstName, string lastName, string address, string city, string state, double zip, double phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        /// <summary>
        /// UC 7 : OVERRIDES Equals() METHOD TO CHECK FOR DUPLICATES
        /// DETERMINES WHETHER THE FIRST NAME AND LAST NAME OF SPECIFIED OBJECT
        /// IS EQUAL TO THE FIRST NAME AND LAST NAME OF CURRENT OBJECT
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>
        ///   <see langword="true" /> if the first name and last name of specified object is equal to that of current object; otherwise, <see langword="false" />.
        /// </returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Contact))
            {
                return false;
            }
            return (this.firstName == ((Contact)obj).firstName)
                && (this.lastName == ((Contact)obj).lastName);
        }

        /// <summary>
        /// OVERRODE GetHashCode() METHOD ALONG WITH Equals() METHOD TO AVOID COMPILER WARNING
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return firstName.GetHashCode() ^ lastName.GetHashCode();
        }
    }
}