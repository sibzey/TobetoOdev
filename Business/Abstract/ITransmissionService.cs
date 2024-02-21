using Business.Requests.Transmission;
using Business.Responses.Transmission;

namespace Business.Abstract;

public interface ITransmissionService
{
    public GetTransmissionListResponse GetList(GetTransmissionListRequest request);
    public AddTransmissionResponse Add(AddTransmissionRequest request);
}