# 说明

华为物联网平台北向接口.Net Standard(.Net Core)SDK

# 介绍

内部采用一个线程来自动刷新令牌，目前只提供异步方法，并且提供了依赖注入扩展，具体使用方法可参考源码中的Demo

# 功能列表

> 获取令牌

> 刷新令牌

> 注册设备（验证码方式）

```csharp
var model = new DeviceRegisterModel
{
    EndUserId = "",
    Imsi = "",
    NodeId = "",
    Timeout = 0,
    DeviceInfo = new DeviceRegisterInfo
    {
        DeviceType = "",
        ManufacturerId = "",
        ManufacturerName = "",
        Model = "",
        Name = "测试",
        ProtocolType = ProtocolType.CoAP
    }
};

await _client.DeviceRegister(model);
```

> 注册设备（密码方式）

> 刷新设备密钥

```csharp
var model = new DeviceRefreshModel
{
    DeviceId = _deviceId,
    NodeId = ""
};

await _client.DeviceRefresh(model);
```

> 修改设备信息

```csharp
var model = new DeviceModifyModel
{
    DeviceId = _deviceId,
    Name = "测试"
};

await _client.DeviceModify(model);
```

> 删除设备

```csharp
await _client.DeviceDelete(_deviceId);
```

> 查询设备激活状态

```csharp
await _client.DeviceActivated(_deviceId);
```

> 查询单个设备信息

```csharp
await _client.DeviceGet(_deviceId);
```

> 批量查询设备信息

```csharp
var model = new DeviceInfoQueryModel
{
    StartTime = DateTime.Now.AddDays(-7)
};

await _client.DeviceQuery(model);
```

> 查询设备历史数据

```csharp
var model = new DeviceDataHistoryQueryModel
{
    DeviceId = _deviceId
};

await _client.DeviceDataHistory(model);
```

> 订阅平台业务数据

```csharp
var model = new SubscribeModel
{
    NotifyType = NotifyType.DeviceDataChanged,
    CallbackUrl = "http://api.text.com"
};

await _client.Subscribe(model);
```

> 查询单个订阅

```csharp
var model = new SubscribeModel
{
    NotifyType = NotifyType.DeviceDataChanged,
    CallbackUrl = "http://api.text.com"
};

var result = await _client.Subscribe(model);

await _client.SubscriptionGet(result.Data.SubscriptionId);
```

> 批量查询订阅

```csharp
var model = new SubscriptionQueryModel
{
    NotifyType = NotifyType.DeviceDataChanged
};

return (await _client.SubscriptionQuery(model)).Data;
```

> 删除单个订阅

```csharp
await _client.SubscriptionDelete("")
```

> 批量删除订阅

> 订阅平台管理数据

> 创建设备命令

```csharp
var model = new CommandCreateModel
{
    DeviceId = _deviceId,
    Command = new CommandBody
    {
        ServiceId = "DTU",
        Method = "SETCommand",
        Paras = new
        {
            Value = "1111"
        }
    }
};

await _client.CommandCreate(model);
```

> 查询设备命令

```csharp
await _client.CommandQuery();
```

> 撤销设备命令