using System.Collections.Generic;
using UnityGameFramework.Runtime;

public partial class ServiceComponent : GameFrameworkComponent
{
    protected List<BaseService> Services = new List<BaseService>();
    
    public void AddService(BaseService service)
    {
        Services.Add(service);
    }

    public void Start()
    {
        AddCustomServices();

        foreach (var service in Services)
        {
            service.Start();
        }
    }

    private void Update()
    {
        foreach (var service in Services)
        {
            service.Update();
        }
    }
}
