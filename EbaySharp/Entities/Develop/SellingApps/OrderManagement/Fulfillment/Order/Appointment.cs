namespace EbaySharp.Entities.Develop.SellingApps.OrderManagement.Fulfillment.Order
{
    public class Appointment
    {
        public string AppointmentEndTime { get; set; }
        public string AppointmentStartTime { get; set; }
        public AppointmentStatusEnum? AppointmentStatus { get; set; }
        public AppointmentTypeEnum? AppointmentType { get; set; }
        public AppointmentWindowEnum? AppointmentWindow { get; set; }
        public string ServiceProviderAppointmentDate { get; set; }
    }
}
