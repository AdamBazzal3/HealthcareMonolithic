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

    public class Appointment : XPCustomObject
    {
        private long _Id;


        private bool _IsActive;

        public Appointment(Session session)
            : base(session)
        {

        
        }
       

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            IsActive = true;
            Status = AppointmentStatus.Scheduled;
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
        [RuleRequiredField("RuleRequiredField for Appointment.ServiceDetails", DefaultContexts.Save,
      "Patient must be specified")]
        public Patient Patient
        {
            get { return _Patient; }
            set { SetPropertyValue(nameof(Patient), ref _Patient, value); }
        }

        private Doctor _Doctor;
        [RuleRequiredField("RuleRequiredField for Appointment.Doctor", DefaultContexts.Save,
      "Doctor must be specified")]
        public Doctor Doctor
        {
            get { return _Doctor; }
            set { SetPropertyValue(nameof(Doctor), ref _Doctor, value); }
        }

        private DateTime _DateTime;
        [RuleRequiredField("RuleRequiredField for Appointment.DateTime", DefaultContexts.Save,
      "DateTime must be specified")]
        public DateTime DateTime
        {
            get { return _DateTime; }
            set { SetPropertyValue(nameof(DateTime), ref _DateTime, value); }
        }
        private AppointmentStatus _Status;

        public AppointmentStatus Status
        {
            get { return _Status; }
            set { SetPropertyValue(nameof(Status), ref _Status, value); }
        }
        private string _Location;
        [RuleRequiredField("RuleRequiredField for Appointment.Location", DefaultContexts.Save,
      "Location must be specified")]
        public string Location
        {
            get { return _Location; }
            set { SetPropertyValue(nameof(Location), ref _Location, value); }
        }

        private string _Reason;
        [RuleRequiredField("RuleRequiredField for Appointment.Reason", DefaultContexts.Save,
      "Reason must be specified")]
        public string Reason
        {
            get { return _Reason; }
            set { SetPropertyValue(nameof(Reason), ref _Reason, value); }
        }

    }

}
