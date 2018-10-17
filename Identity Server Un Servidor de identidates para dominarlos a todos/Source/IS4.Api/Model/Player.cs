using IS4.Api.Enum;

namespace IS4.Api.Model
{
  public class Player :Base
  {
    public string FistName { get; set; }
    public string LastName { get; set; }
    public string DateBirthday { get; set; }
   // public Position CurrentPosition { get; set; }
    public string Photo { get; set; }
    public string Country { get; set; }
    public int Score { get; set; }
    public virtual Team Team { get; set; }
    public virtual int TeamID { get; set; }
        public string Equipo { get; set; }
    
  }
}
