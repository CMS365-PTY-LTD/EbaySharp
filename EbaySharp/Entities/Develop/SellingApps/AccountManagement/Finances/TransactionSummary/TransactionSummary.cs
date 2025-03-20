using EbaySharp.Entities.Common;

namespace EbaySharp.Entities.Develop.SellingApps.AccountManagement.Finances.TransactionSummary
{
    public class TransactionSummary
    {
        public Amount? AdjustmentAmount { get; set; }
        public BookingEntryEnum? AdjustmentBookingEntry { get; set; }
        public int? AdjustmentCount { get; set; }
        public Amount? BalanceTransferAmount { get; set; }
        public BookingEntryEnum? BalanceTransferBookingEntry { get; set; }
        public int? BalanceTransferCount { get; set; }
        public Amount? CreditAmount { get; set; }
        public BookingEntryEnum? CreditBookingEntry { get; set; }
        public int? CreditCount { get; set; }
        public Amount? DisputeAmount { get; set; }
        public BookingEntryEnum? DisputeBookingEntry { get; set; }
        public int? DisputeCount { get; set; }
        public Amount? LoanRepaymentAmount { get; set; }
        public BookingEntryEnum? LoanRepaymentBookingEntry { get; set; }
        public int? LoanRepaymentCount { get; set; }
        public Amount? NonSaleChargeAmount { get; set; }
        public BookingEntryEnum? NonSaleChargeBookingEntry { get; set; }
        public int? NonSaleChargeCount { get; set; }
        public Amount? OnHoldAmount { get; set; }
        public BookingEntryEnum? OnHoldBookingEntry { get; set; }
        public int? OnHoldCount { get; set; }
        public Amount? PurchaseAmount { get; set; }
        public BookingEntryEnum? PurchaseBookingEntry { get; set; }
        public int? PurchaseCount { get; set; }
        public Amount? RefundAmount { get; set; }
        public BookingEntryEnum? RefundBookingEntry { get; set; }
        public int? RefundCount { get; set; }
        public Amount? ShippingLabelAmount { get; set; }
        public BookingEntryEnum? ShippingLabelBookingEntry { get; set; }
        public int? ShippingLabelCount { get; set; }
        public Amount? TransferAmount { get; set; }
        public BookingEntryEnum? TransferBookingEntry { get; set; }
        public int? TransferCount { get; set; }
        public Amount? WithdrawalAmount { get; set; }
        public BookingEntryEnum? WithdrawalBookingEntry { get; set; }
        public int? WithdrawalCount { get; set; }
    }
}
