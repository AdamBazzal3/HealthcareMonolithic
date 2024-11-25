using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.MiddleTier;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using Healthcare.Module.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Healthcare.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Contact")]
    [DefaultProperty("Name")]
    public class Doctor : XPObject
    {

        private DateTime _DateOfBirth;

        [RuleRequiredField("RuleRequiredField for Doctor.FirstName", DefaultContexts.Save,
"Doctor first name must be specified")]
        public string FirstName { get; set; }
        [RuleRequiredField("RuleRequiredField for Doctor.LastName", DefaultContexts.Save,
"Doctor last name must be specified")]
        public string LastName { get; set; }

        public string ContactName { get; set; }


        public string MobilePhone { get; set; }
  
        public string Fax { get; set; }
        public string Email { get; set; }

        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public bool IsActive
        {
            get; set;
        } = true;
        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set
            {

                if (_DateOfBirth.Equals(value))
                    return;

                _DateOfBirth = value;
            }
        }
        public Doctor(Session session)
            : base(session)
        {
         
        }
        //[Association("SelectedRides-SelectedDrivers")]
        //[IgnoreConvertToJson]
        //public XPCollection<Ride> SelectedRides
        //{
        //    get { return GetCollection<Ride>(nameof(SelectedRides)); }
        //}

        public override void AfterConstruction()
        {
            base.AfterConstruction();


        }
        
        //private long _Id;
        //[Browsable(false)]
        //[Key(AutoGenerate = true), ModelDefault("AllowEdit", "False")]
        //public long Id
        //{
        //    get { return _Id; }
        //    set { SetPropertyValue(nameof(Id), ref _Id, value); }
        //}


        private string _Specialty;
        [RuleRequiredField("RuleRequiredField for Doctor.Specialty", DefaultContexts.Save,
"Patient specialty must be specified")]
        public string Specialty
        {
            get { return _Specialty; }
            set { SetPropertyValue(nameof(Specialty), ref _Specialty, value); }
        }

        private string _ContactInformation;
        public string ContactInformation
        {
            get { return _ContactInformation; }
            set { SetPropertyValue(nameof(ContactInformation), ref _ContactInformation, value); }
        }

        private string _EmploymentDetails;
        public string EmploymentDetails
        {
            get { return _EmploymentDetails; }
            set { SetPropertyValue(nameof(EmploymentDetails), ref _EmploymentDetails, value); }
        }

        private string _Schedule;
        public string Schedule
        {
            get { return _Schedule; }
            set { SetPropertyValue(nameof(Schedule), ref _Schedule, value); }
        }


        private bool _IsAvailable;
        public bool IsAvailable
        {
            get { return _IsAvailable; }
            set { SetPropertyValue(nameof(IsAvailable), ref _IsAvailable, value); }
        }
        private string _LicenseNumber;
        public string LicenseNumber
        {
            get { return _LicenseNumber; }
            set { SetPropertyValue(nameof(LicenseNumber), ref _LicenseNumber, value); }
        }



    }


}
