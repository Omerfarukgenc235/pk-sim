using Microsoft.AspNetCore.Mvc;
using SimApi.Base;
using SimApi.Operation;
using SimApi.Schema;

namespace SimApi.Service;


[EnableMiddlewareLogger]
[ResponseGuid]
[Route("simapi/v1/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService service;

    public CustomerController(ICustomerService service)
    {
        this.service = service;
    }

    [HttpGet]
    public ApiResponse<List<CustomerResponse>> GetAll()
    {
        var list = service.GetAll();
        return list;
    }

    [HttpGet("{id}")]
    public ApiResponse<CustomerResponse> GetById(int id)
    {
        var model = service.GetById(id);
        return model;
    }

    [HttpPost]
    public ApiResponse Post([FromBody] CustomerRequest request)
    {
       return service.Insert(request);
    }

    [HttpPut("{id}")]
    public ApiResponse Put(int id, [FromBody] CustomerRequest request)
    {
        return service.Update(id,request);
    }

    [HttpDelete("{id}")]
    public ApiResponse Delete(int id)
    {
        return service.Delete(id);
    }
}
