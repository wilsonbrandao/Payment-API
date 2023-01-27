using System.ComponentModel;

namespace Payment_API.Enums
{
    public enum EStatusSale : int
    {
        [Description("Awaiting Payment")]
        AwaitingPayment = 1,

        [Description("Payment accept")]
        PaymentAccept = 2,

        [Description("Send to carrier")]
        SendToCarrier = 3,

        [Description("Delivered")]
        Delivered = 4,

        [Description("Canceled")]
        Canceled = 5
    }
}
