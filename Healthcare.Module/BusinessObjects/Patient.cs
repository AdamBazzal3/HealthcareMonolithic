using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using Healthcare.Module.Attributes;
using System.ComponentModel;

namespace Healthcare.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Contact")]
    [DefaultProperty("Name")]
    public class Patient : XPObject
    {

        private DateTime _DateOfBirth;

        [RuleRequiredField("RuleRequiredField for Patient.FirstName", DefaultContexts.Save,
"Patient first name must be specified")]
        public string FirstName { get; set; }
        [RuleRequiredField("RuleRequiredField for Patient.LastName", DefaultContexts.Save,
"Patient last name must be specified")]
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


        public Patient(Session session)
            : base(session)
        {

        
        }
       

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Activate();
        }


        public void Deactivate()
        {
            IsActive = false;
        }

        //[DevExpress.Xpo.Aggregated]
        //[Association("Passenger-Rides")]
        //[IgnoreConvertToJson]
        //public XPCollection<Ride> PassengerRides
        //{
        //    get { return GetCollection<Ride>(nameof(PassengerRides)); }
        //}
        public void Activate()
        {
            IsActive = true;
        }
        //[Browsable(false)]
        //[Key(AutoGenerate = true), ModelDefault("AllowEdit", "False")]
        //public long Id
        //{
        //    get { return _Id; }
        //    set { SetPropertyValue(nameof(Id), ref _Id, value); }
        //}



        private Gender _Gender;
        [RuleRequiredField("RuleRequiredField for Patient.Gender", DefaultContexts.Save,
"Gender must be specified")]
        public Gender Gender
        {
            get { return _Gender; }
            set { SetPropertyValue(nameof(Gender), ref _Gender, value); }
        }

        private string _ContactInformation;
        [RuleRequiredField("RuleRequiredField for Patient.ContactInformation", DefaultContexts.Save,
"ContactInformation must be specified")]
        public string ContactInformation
        {
            get { return _ContactInformation; }
            set { SetPropertyValue(nameof(ContactInformation), ref _ContactInformation, value); }
        }

        private XPCollection<MedicalRecord> _MedicalHistory;
        [Association("Patient-MedicalRecords")]
        public XPCollection<MedicalRecord> MedicalHistory
        {
            get
            {
                return GetCollection<MedicalRecord>(nameof(MedicalHistory));
            }
        }

        private string _CurrentMedications;
        public string CurrentMedications
        {
            get { return _CurrentMedications; }
            set { SetPropertyValue(nameof(CurrentMedications), ref _CurrentMedications, value); }
        }

        private string _InsuranceDetails;
        public string InsuranceDetails
        {
            get { return _InsuranceDetails; }
            set { SetPropertyValue(nameof(InsuranceDetails), ref _InsuranceDetails, value); }
        }


    }

}
