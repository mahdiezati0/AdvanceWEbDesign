using Admin_Panel.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Admin_Panel.Areas.Admin.Models;

public class CustomerViewModel
{
    [BindNever]
    /// <summary>
    /// Primary key for Customer records.
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// A courtesy title. For example, Mr. or Ms.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// First name of the person.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Middle name or middle initial of the person.
    /// </summary>
    public string? MiddleName { get; set; }

    /// <summary>
    /// Last name of the person.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Surname suffix. For example, Sr. or Jr.
    /// </summary>
    public string? Suffix { get; set; }

    /// <summary>
    /// The customer&apos;s organization.
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// The customer&apos;s sales person, an employee of AdventureWorks Cycles.
    /// </summary>
    public string? SalesPerson { get; set; }

    /// <summary>
    /// E-mail address for the person.
    /// </summary>
    public string? EmailAddress { get; set; }

    /// <summary>
    /// Phone number associated with the person.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    public DateTime ModifiedDate { get; set; }
    /// <summary>
    /// Convert CustomerViewModel To Customer
    /// </summary>
    /// <param name="model">Customer Model</param>
    public static implicit operator Customer(CustomerViewModel model)
    {
        return new Customer
        {
            Title=model.Title,
            FirstName=model.FirstName,
            MiddleName=model.MiddleName,
            LastName=model.LastName,
            Suffix=model.Suffix,
            CompanyName=model.CompanyName,
            SalesPerson=model.SalesPerson,
            EmailAddress=model.EmailAddress,
            Phone=model.Phone,
            ModifiedDate=model.ModifiedDate,
            NameStyle=false,
            Rowguid=Guid.NewGuid(),
            
        };
    }
}
