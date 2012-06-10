using CSS.OpusForce.Services.Messaging;

namespace CSS.OpusForce.Services.Interfaces
{
    public interface IFinancialServices
    {
        CreateFinancialActivityTypeResponse CreateFinancialActivityType(CreateFinancialActivityTypeRequest request);
        ReadFinancialActivityTypeResponse ReadFinancialActivityType(ReadFinancialActivityTypeRequest request);
        UpdateFinancialActivityTypeResponse UpdateFinancialActivityType(UpdateFinancialActivityTypeRequest request);
        DeleteFinancialActivityTypeResponse DeleteFinancialActivityType(DeleteFinancialActivityTypeRequest request);
        ListFinancialActivityTypesResponse ListFinancialActivityTypes(ListFinancialActivityTypesRequest request);

        CreatePaymentTypeResponse CreatePaymentType(CreatePaymentTypeRequest request);
        ReadPaymentTypeResponse ReadPaymentType(ReadPaymentTypeRequest request);
        UpdatePaymentTypeResponse UpdatePaymentType(UpdatePaymentTypeRequest request);
        DeletePaymentTypeResponse DeletePaymentType(DeletePaymentTypeRequest request);
        ListPaymentTypesResponse ListPaymentTypes(ListPaymentTypesRequest request);
    }
}
