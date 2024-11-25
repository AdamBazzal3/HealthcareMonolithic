using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using Healthcare.Module.Attributes;
using System.ComponentModel;

namespace Healthcare.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Contact")]
    [DefaultProperty("Id")]

    public class MedicalRecord : XPCustomObject
    {
        private long _Id;


        private bool _IsActive;

        public MedicalRecord(Session session)
            : base(session)
        {

        
        }
       

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            IsActive = true;
        }

        [DefaultValue(true)]
        public bool IsActive
        {
            get { return _IsActive; }
            set { SetPropertyValue(nameof(IsActive), ref _IsActive, value); }
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
        [Browsable(false)]
        [Key(AutoGenerate = true), ModelDefault("AllowEdit", "False")]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue(nameof(Id), ref _Id, value); }
        }
        private Patient _Patient;
        [Association("Patient-MedicalRecords")]
        [RuleRequiredField("RuleRequiredField for MedicalRecord.Patient", DefaultContexts.Save,
      "Patient must be specified")]
        public Patient Patient
        {
            get { return _Patient; }
            set { SetPropertyValue(nameof(Patient), ref _Patient, value); }
        }

        private Doctor _Doctor;
        [RuleRequiredField("RuleRequiredField for MedicalRecord.Doctor", DefaultContexts.Save,
      "Doctor must be specified")]
        public Doctor Doctor
        {
            get { return _Doctor; }
            set { SetPropertyValue(nameof(Doctor), ref _Doctor, value); }
        }

        private DateTime _DateOfVisit;
        [RuleRequiredField("RuleRequiredField for MedicalRecord.DateOfVisit", DefaultContexts.Save,
"Date of visit must be specified")]
        public DateTime DateOfVisit
        {
            get { return _DateOfVisit; }
            set { SetPropertyValue(nameof(DateOfVisit), ref _DateOfVisit, value); }
        }

        private string _ClinicalNotes;
        [RuleRequiredField("RuleRequiredField for MedicalRecord.ClinicalNotes", DefaultContexts.Save,
"Clinical Notes must be specified")]
        public string ClinicalNotes
        {
            get { return _ClinicalNotes; }
            set { SetPropertyValue(nameof(ClinicalNotes), ref _ClinicalNotes, value); }
        }

        private string _TestResults;
        public string TestResults
        {
            get { return _TestResults; }
            set { SetPropertyValue(nameof(TestResults), ref _TestResults, value); }
        }

        private XPCollection<Prescription> _Prescriptions;
        [Association("MedicalRecord-Prescriptions")]
        public XPCollection<Prescription> Prescriptions
        {
            get
            {
                return GetCollection<Prescription>(nameof(Prescriptions));
            }
        }

    }

}
