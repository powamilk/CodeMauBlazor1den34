namespace DemoMauHocSinhBlazor.Service
{
    public class SelectedHocSinhService
    {
        public List<int> SelectedHocSinhIds { get; private set; } = new List<int>();

        public void SetSelectedHocSinhIds(List<int> ids)
        {
            SelectedHocSinhIds = ids;
        }
    }

}
