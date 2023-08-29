namespace MiddleEarthAPI.Resources.DataTransferObjects.Response
{
    public record Publisher
    {
        public int PublisherId { get; set; }

        public string Name { get; set; }
    }
}