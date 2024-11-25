using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Healthcare.Module.Attributes;
using System.ComponentModel;

namespace Healthcare.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Contact")]
    [DefaultProperty("Id")]

    public class Prescription : XPCustomObject
    {
        private long _Id;


        private bool _IsActive;

        public Prescription(Session session)
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
       


        private DateTime _DateIssued;
        public DateTime DateIssued
        {
            get { return _DateIssued; }
            set { SetPropertyValue(nameof(DateIssued), ref _DateIssued, value); }
        }

        [Association("MedicalRecord-Prescriptions")]
        public MedicalRecord MedicalRecord
        {
            get { return _MedicalRecord; }
            set { SetPropertyValue(nameof(MedicalRecord), ref _MedicalRecord, value); }
        }
        private string _Dosage;
        private MedicalRecord _MedicalRecord;

        public string Dosage
        {
            get { return _Dosage; }
            set { SetPropertyValue(nameof(Dosage), ref _Dosage, value); }
        }



    }

}
