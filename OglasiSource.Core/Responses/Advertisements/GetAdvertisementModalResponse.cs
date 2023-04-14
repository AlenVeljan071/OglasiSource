using OglasiSource.Core.Enums;

namespace OglasiSource.Core.Responses.Advertisements
{
    public class GetAdvertisementModalResponse
    {
        public List<EnumValue> Colors { get; set; }
        public List<EnumValue> Shifters { get; set; }
        public List<EnumValue> Gears { get; set; }
        public List<EnumValue> Emissions { get; set; }
        public List<EnumValue> Seats { get; set; }
        public List<EnumValue> Fuels { get; set; }
    }
}
