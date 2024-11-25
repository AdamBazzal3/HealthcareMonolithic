using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Contact")]
    [DefaultProperty("Id")]
    public class Bill :XPCustomObject
    {


        private bool _IsActive;

        public Bill(Session session)
            : base(session)
        {


        }


        public override void AfterConstruction()
        {
            base.AfterConstruction();
            IsActive = true;
            PaymentStatus = BillStatus.Initiated;
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
        private long _Id;
        [Browsable(false)]
        [Key(AutoGenerate = true), ModelDefault("AllowEdit", "False")]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue(nameof(Id), ref _Id, value); }
        }
        private Patient _Patient;
        [RuleRequiredField("RuleRequiredField for Bill.Patient", DefaultContexts.Save,
      "A Patient must be specified")]
        public Patient Patient
        {
            get { return _Patient; }
            set { SetPropertyValue(nameof(Patient), ref _Patient, value); }
        }

        private Doctor _Doctor;
        [RuleRequiredField("RuleRequiredField for Bill.Doctor", DefaultContexts.Save,
      "A Doctor must be specified")]
        public Doctor Doctor
        {
            get { return _Doctor; }
            set { SetPropertyValue(nameof(Doctor), ref _Doctor, value); }
        }

        private string _ServiceDetails;
        [RuleRequiredField("RuleRequiredField for Bill.ServiceDetails", DefaultContexts.Save,
      "Service Details must be specified")]
        public string ServiceDetails
        {
            get { return _ServiceDetails; }
            set { SetPropertyValue(nameof(ServiceDetails), ref _ServiceDetails, value); }
        }

        private decimal _Amount;
        [RuleRequiredField("RuleRequiredField for Bill.Amount", DefaultContexts.Save,
      "Bill Amount must be specified")]
        public decimal Amount
        {
            get { return _Amount; }
            set { SetPropertyValue(nameof(Amount), ref _Amount, value); }
        }

        private BillStatus _PaymentStatus;
        public BillStatus PaymentStatus
        {
            get { return _PaymentStatus; }
            set { SetPropertyValue(nameof(PaymentStatus), ref _PaymentStatus, value); }
        }

        private string _InsuranceClaims;
        public string InsuranceClaims
        {
            get { return _InsuranceClaims; }
            set { SetPropertyValue(nameof(InsuranceClaims), ref _InsuranceClaims, value); }
        }

    }
}
