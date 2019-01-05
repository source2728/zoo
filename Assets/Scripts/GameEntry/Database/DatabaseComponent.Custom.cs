public partial class DatabaseComponent
{
    public CurrencyDatabase Currency { get; private set; }
    public ActorDatabase Actor { get; private set; }
    public ZooDatabase Zoo { get; private set; }
    public StaffDatabase Staff { get; private set; }
    public ShopDatabase Shop { get; private set; }
    public FenceAreaDatabase FenceArea { get; private set; }
    public FacilityDatabase Facility { get; private set; }
    public LandDatabase Land { get; private set; }
    public EventDatabase Event { get; private set; }

    private void Start()
    {
        Currency = AddDatabase<CurrencyDatabase>();
        Actor = AddDatabase<ActorDatabase>();
        Zoo = AddDatabase<ZooDatabase>();
        Staff = AddDatabase<StaffDatabase>();
        Shop = AddDatabase<ShopDatabase>();
        FenceArea = AddDatabase<FenceAreaDatabase>();
        Facility = AddDatabase<FacilityDatabase>();
        Land = AddDatabase<LandDatabase>();
        Event = AddDatabase<EventDatabase>();
    }
}
