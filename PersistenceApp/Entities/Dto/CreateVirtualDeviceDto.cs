using FluentValidation;

namespace Entities.Dto
{
    public class CreateVirtualDeviceDto
    {
        public string Name { get; set; }
        public int PortId { get; set; }
    }

    public class CreateVirtualDeviceDtoValidator : AbstractValidator<CreateVirtualDeviceDto>
    {
        public CreateVirtualDeviceDtoValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.PortId).GreaterThan(0);
        }
    }
}
