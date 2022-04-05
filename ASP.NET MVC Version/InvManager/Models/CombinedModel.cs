namespace InvManager.Models
{
    public class CombinedModel
    {
        public IEnumerable<ContainerModel> Containers { get; set; }
        public IEnumerable<ItemModel> Items { get; set; }
    }
}
