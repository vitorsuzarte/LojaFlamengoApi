namespace LojaFlamengoApi.BaseResponses
{
   public class ItemResponse
   {
      public long Id { get; set; }
      public string Description { get; set; }
      public double Price { get; set; }
      public string Tag { get; set; }
      public string Image { get; set; }
      public bool IsActive { get; set; }
   }
}